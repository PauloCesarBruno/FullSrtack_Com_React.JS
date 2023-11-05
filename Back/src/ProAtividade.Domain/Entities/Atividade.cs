namespace ProAtividade.domain.Entities
{
    public class Atividade
    { 
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataConclusao { get; set; }
        public Prioridade Prioridade { get; set; } // Que é o Enum que foi Criado na pasta Models

        public Atividade() 
        {
            DataCriacao = DateTime.Now;
            DataConclusao = null;
        }
        
        public Atividade(int id, string titulo, string descricao) : this()
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Descricao = descricao;
        }      

        public void Concluir()
        {
            if (DataConclusao == null)
                DataConclusao = DateTime.Now;
            else
                throw new Exception($"Atividade já Concluida em: {DataConclusao?.ToString("dd/MM/yyyy hh:mm")}");  
        } 
    }
}