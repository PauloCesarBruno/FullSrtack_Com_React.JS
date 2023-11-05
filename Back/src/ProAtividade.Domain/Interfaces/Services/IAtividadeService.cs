using ProAtividade.domain.Entities;

namespace ProAtividade.Domain.Interfaces.Services
{
    public interface IAtividadeService
    {
        Task<Atividade> AdicionarAtividade(Atividade model);
        Task<Atividade> AtualizarAtividade(Atividade model);

        Task<bool> DeletarAtividade (int atividadeId);
        Task<bool> ConcluirAtividade(Atividade model);

        Task<Atividade[]> PegarTodasAtividadesAsync();
        Task<Atividade> PegarAtividadePorIdsAsync(int atividadeId);
    }
}