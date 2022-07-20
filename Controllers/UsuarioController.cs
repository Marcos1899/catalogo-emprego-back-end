using CatalogoEmpregoBack.Dtos.Usuario;
using CatalogoEmpregoBack.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoEmpregoBack.Controllers;


[ApiController]
[Route("usuarios")]
public class UsuarioController : ControllerBase
{
     private readonly UsuarioServico _usuarioServico;
     
     public UsuarioController([FromServices] UsuarioServico usuarioServico)
     {
        _usuarioServico = usuarioServico;
     }
     
     [HttpGet]
      public ActionResult<List<UsuarioResponseDto>> GetUsuarios()
    {
       var usuarios = _usuarioServico.RecuperarUsuarios();
       return Ok(usuarios) ;
    }
    [HttpGet("{id:int}")]
    public ActionResult<UsuarioResponseDto> GetEmpresa([FromRoute] int id)
    {
        
      try
      {
         var usuario = _usuarioServico.RecuperarUsuario(id);
         return usuario;
      }
      catch(Exception)
      {
         return NotFound();
      }

    }
   [HttpPost]
   public ActionResult<UsuarioResponseDto> PostUsuario([FromBody] UsuarioCreateUpdateDto UsuarioNovo)
    {

        var usuario = _usuarioServico.AdicionarUsuario(UsuarioNovo);

        // retornar o usurio
        return CreatedAtAction(nameof(GetUsuarios),new{id = usuario.Id}, usuario);
    
    }
   [HttpPut("{id:int}")]

   public ActionResult<UsuarioCreateUpdateDto> PutUsuario([FromRoute] int id, [FromBody] UsuarioCreateUpdateDto usuarioEditado){
   
    try{
      var  usuario = _usuarioServico.AtualizarUsuario(id, usuarioEditado);
      return Ok(usuario);
    }  
    catch(Exception){
      return NotFound();
    }

   }

   [HttpDelete("{id:int}")]

    public ActionResult DeleteUsuario([FromRoute] int id)
    {
       try
       {
         //mandar o serviço deletar
         _usuarioServico.DeletarUsuario(id);

         return NoContent();
       }
       catch (Exception)
       {
          return NotFound();
       }
    }

}
