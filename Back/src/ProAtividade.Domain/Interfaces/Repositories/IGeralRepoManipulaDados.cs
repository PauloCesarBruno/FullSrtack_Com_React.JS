namespace ProAtividade.Domain.Interfaces.Repositories
{
    public interface IGeralRepoManipulaDados
    {
         // Contrato de Interface de MANIPULAÇÃO de Dados
        void Adicionar<T> (T Entity) where T : class;
        void Atualizar<T> (T Entity) where T : class;
        void Deletar<T> (T Entity) where T : class;
        void DeletarVarias<T> (T[] Entity) where T : class;

        Task <bool> SalvarMudancasAsync();  
    }
}