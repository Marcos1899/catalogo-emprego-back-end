using CatalogoEmpregoBack.Dtos.Vaga;
using CatalogoEmpregoBack.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoEmpregoBack.Controllers;

[ApiController]
[Route("vagas")]

public class VagaController :  ControllerBase
{
     private readonly VagaServico _vagaServico;
     
     public VagaController([FromServices] VagaServico vagaServico)
     {
        _vagaServico = vagaServico;
     }

     [HttpGet]
       public ActionResult<List<VagaResponseDto>> GetVagas()
    {
       var vagas = _vagaServico.RecuperarVagas();
       return Ok(vagas) ;
    }
   
     [HttpGet("{id:int}")]
    public ActionResult<VagaResponseDto> GetVaga([FromRoute] int id)
    {
        
      try
      {
         var vaga = _vagaServico.RecuperarVaga(id);
         return Ok(vaga);
      }
      catch(Exception)
      {
         return NotFound();
      }
   }
   [HttpPost]
   public ActionResult<VagaResponseDto> PostVaga([FromBody] VagaCreateUpdateDto VagaNova)
    {

        var vaga = _vagaServico.AdicionarVaga(VagaNova);

        // retornar o usurio
        return CreatedAtAction(nameof(GetVaga),new{id = vaga.Id}, vaga); 
    }
   [HttpPut("{id:int}")]

   public ActionResult<VagaCreateUpdateDto> PutVaga([FromRoute] int id, [FromBody] VagaCreateUpdateDto vagaEditada){
   
    try{
      var  vaga = _vagaServico.AtualizarVaga(id, vagaEditada);
      return Ok(vaga);
    }  
    catch(Exception){
      return NotFound();
    }

   }
[HttpDelete("{id:int}")]
    public ActionResult DeleteVaga([FromRoute] int id)
    {
       try
       {
         //mandar o serviço deletar
         _vagaServico.DeletarVaga(id);

         return NoContent();
       }
       catch (Exception)
       {
          return NotFound();
       }
    }
}
