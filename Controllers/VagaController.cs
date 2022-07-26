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
     
}
