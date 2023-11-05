using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProAtividade.domain.Entities;

namespace ProAtividade.data.Mappings
{
    public class AtividadeMap : IEntityTypeConfiguration<Atividade>
    {
        public void Configure(EntityTypeBuilder<Atividade> builder)
        {
            builder.ToTable("Atividades");

            builder.Property(a => a.Titulo)
                .HasColumnType("Varchar(100)");

                
            builder.Property(a => a.Descricao)
                .HasColumnType("Varchar(255)");
        }
    }
}