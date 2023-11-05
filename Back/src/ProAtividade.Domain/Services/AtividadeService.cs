using ProAtividade.domain.Entities;
using ProAtividade.Domain.Interfaces.Repositories;
using ProAtividade.Domain.Interfaces.Services;

namespace ProAtividade.Domain.Services
{
    public class AtividadeService : IAtividadeService
    {
        private readonly IAtividadeRepoGetDados _atividadeRepoGetDados;
        public AtividadeService(IAtividadeRepoGetDados atividadeRepoGetDados)
        {
            _atividadeRepoGetDados = atividadeRepoGetDados;       
        }

        public async Task<Atividade> AdicionarAtividade(Atividade model)
        {
            if (await _atividadeRepoGetDados.PegaPorTituloAsync(model.Titulo) != null)
            throw new Exception("Já existe uma atividade com esse título !!!");

            if (await _atividadeRepoGetDados.PegaPorIdAsync(model.Id) == null)
            {
                _atividadeRepoGetDados.Adicionar(model);
                if (await _atividadeRepoGetDados.SalvarMudancasAsync())

                return model;
            }

            return null;
        } 

        public async Task<Atividade> AtualizarAtividade(Atividade model)
        {
            if (model.DataConclusao != null)
            throw new Exception ("Não se pode alterar uma atividade que já foi concluida !!!");


            if (await _atividadeRepoGetDados.PegaPorIdAsync(model.Id) != null)
            {
                _atividadeRepoGetDados.Atualizar(model);
                if (await _atividadeRepoGetDados.SalvarMudancasAsync())

                return model;
            }

            return null;

        }

        public async Task<bool> ConcluirAtividade(Atividade model)
        {
            if (model != null)
            {
                model.Concluir();
                _atividadeRepoGetDados.Atualizar<Atividade>(model);
                return await _atividadeRepoGetDados.SalvarMudancasAsync();
            }

            return false;
        }

        public async Task<bool> DeletarAtividade(int atividadeId)
        {
            var atividade = await _atividadeRepoGetDados.PegaPorIdAsync(atividadeId);
            if (atividade == null) throw new Exception ("Atividade não existe para sr Deletada !!");

            _atividadeRepoGetDados.Deletar(atividade);
            return await _atividadeRepoGetDados.SalvarMudancasAsync();
        }

        public async Task<Atividade> PegarAtividadePorIdsAsync(int atividadeId)
        {
            try
            {
                var atividade = await _atividadeRepoGetDados.PegaPorIdAsync(atividadeId);

                if (atividade == null) return null;

                return atividade;
            }
            catch (System.Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Atividade[]> PegarTodasAtividadesAsync()
        {
           try
            {
                var atividades = await _atividadeRepoGetDados.PegaTodasAsync();

                if (atividades == null) return null;

                return atividades;
            }
            catch (System.Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
    }
}