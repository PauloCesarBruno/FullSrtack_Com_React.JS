using ProAtividade.domain.Entities;

namespace ProAtividade.Domain.Interfaces.Repositories
{
    public interface IAtividadeRepoGetDados : IGeralRepoManipulaDados // Principio de RESPONSABILIDADE ÚNICA.
    {
        // Contrato de Interface de LEITURA de Dados
        Task<Atividade[]> PegaTodasAsync();
        Task<Atividade> PegaPorIdAsync(int id);
        Task<Atividade> PegaPorTituloAsync(string titulo);
    }
}