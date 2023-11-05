using Microsoft.EntityFrameworkCore;
using ProAtividade.Data.Context;
using ProAtividade.domain.Entities;
using ProAtividade.Domain.Interfaces.Repositories;

namespace ProAtividade.data.Repositories
{
    //OUTRA MANOBRA DE PRINCIPIO DE RESPONSABILIDADE  ÚNICA...!                       
    public class AtividadeRepoGetDados : GeralRepoManipulaDados, IAtividadeRepoGetDados
    {
    private readonly DataContext _context;
       public AtividadeRepoGetDados(DataContext context) : base(context)
       {
            _context = context;
        
       }

        public async Task<Atividade> PegaPorIdAsync(int id)
        {
           IQueryable<Atividade> query = _context.Atividades;
           
           query = query.AsNoTracking()
                        .OrderBy(ativ => ativ.Id)
                        .Where (a => a.Id == id);

           return await query.FirstOrDefaultAsync();
        }

        public async Task<Atividade> PegaPorTituloAsync(string titulo)
        {
            IQueryable<Atividade> query = _context.Atividades;
           
           query = query.AsNoTracking()
                        .OrderBy(ativ => ativ.Id);

           return await query.FirstOrDefaultAsync(a => a.Titulo == titulo);
        }

        public async Task<Atividade[]> PegaTodasAsync()
        {
             IQueryable<Atividade> query = _context.Atividades;
           
           query = query.AsNoTracking()
                        .OrderBy(ativ => ativ.Id);

           return await query.ToArrayAsync();
        }
    }
}