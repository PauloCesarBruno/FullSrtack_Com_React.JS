using Microsoft.AspNetCore.Mvc;
using ProAtividade.domain.Entities;
using ProAtividade.Domain.Interfaces.Services;

namespace ProAtividade.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtividadeController : ControllerBase
    { 
        private readonly IAtividadeService _atividadeService;
        public AtividadeController(IAtividadeService atividadeService)
        {
            _atividadeService = atividadeService;                       
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
           try
           {
                var atividades = await _atividadeService.PegarTodasAtividadesAsync();
                if (atividades == null) return NoContent();

                return Ok(atividades);
           }
           catch (System.Exception ex)
           {
            return this.StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError,
            $"Erro ao tentar recuperar Atividades. Erro: {ex.Message}");
           }
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> GetById(int id)
        {
           try
           {
                var atividade = await _atividadeService.PegarAtividadePorIdsAsync(id);
                if (atividade == null) return NoContent();

                return Ok(atividade);
           }
           catch (System.Exception ex)
           {
            return this.StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError,
            $"Erro ao tentar recuperar Atividade com Id: ${id}. Erro: {ex.Message}");
           }
        }

        [HttpPost]
        public async Task <IActionResult> Post(Atividade model) 
        {
           try
           {
                var atividade = await _atividadeService.AdicionarAtividade(model);
                if (atividade == null) return NoContent();

                return Ok(atividade);
           }
           catch (System.Exception ex)
           {
            return this.StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError,
            $"Erro ao tentar adicionar atividade. Erro: {ex.Message}");
           }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Atividade model)
        {
           try
           {
                if(model.Id == id) 
                 this.StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status409Conflict,
                 "Você esta tentando alterar uma atividade errada !!!");

                var atividade = await _atividadeService.AtualizarAtividade(model);
                if (atividade == null) return NoContent();

                return Ok(atividade);
           }
           catch (System.Exception ex)
           {
            return this.StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError,
            $"Erro ao tentar atualizar atividade com Id: ${id}. Erro: {ex.Message}");
           }
        }

        [HttpDelete("{id}")]
        public async Task <IActionResult> Delete(int id)
        {
          try
           {    
                var atividade = await _atividadeService.PegarAtividadePorIdsAsync(id);
                if (atividade == null)
                 this.StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status409Conflict,
                     "Você esta tentando deletar uma atividade que não existe !!!");

                    if (await _atividadeService.DeletarAtividade(id)) 
                    {
                        // O (SalvarMudancasAsync já está no AtividadeService)
                        return Ok(new { message = "Deletado" });
                    }
                    else
                    {
                        return BadRequest("Ocorreu um problema não especifico ao tentar deletar atividade !");
                    }

           }
           catch (System.Exception ex)
           {
            return this.StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError,
            $"Erro ao tentar deletar tividade com Id: ${id}. Erro: {ex.Message}");
           }
        }
    }
}