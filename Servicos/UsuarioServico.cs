using CatalogoEmprego.Data;
using CatalogoEmprego.Models;
using CatalogoEmpregoBack.Dtos.Usuario;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogoEmpregoBack.Servicos;

public class UsuarioServico
{
    private readonly CatalogoContexto _contexto;

    public UsuarioServico([FromServices] CatalogoContexto contexto)
    {
        _contexto = contexto;
    }

 public List<UsuarioResponseDto> RecuperarUsuarios(){

    return _contexto.Usuarios.AsNoTracking().Include(usuario => usuario.Curriculo).ProjectToType<UsuarioResponseDto>()
    .ToList();
 }
 public UsuarioResponseDto RecuperarUsuario(int id){

        var usuario = _contexto.Usuarios.AsNoTracking().Include(usuario => usuario.Curriculo).SingleOrDefault(usuario => usuario.Id == id);

        if (usuario is null)
            throw new Exception("Candidato não encontrada");

        //Mapear do objeto Usuario para UsuarioRespondeDto
        UsuarioResponseDto usuarioResposta = usuario.Adapt<UsuarioResponseDto>();

        return usuarioResposta;

    }

 public UsuarioResponseDto AdicionarUsuario(UsuarioCreateUpdateDto usuarioDto)
    {
        //Mapear de EmpresaCreateUpdateDto para usuario
        var usuario = usuarioDto.Adapt<Usuario>();

        //Adicionar no contexto
        _contexto.Usuarios.Add(usuario);

        //Comando para salvar que realmente salva no banco de dados
        _contexto.SaveChanges();

        //Mapear de Empresa para EmpresaDto
        var usuarioResposta = usuario.Adapt<UsuarioResponseDto>();
        return usuarioResposta; 
    } 

 public UsuarioResponseDto AtualizarUsuario(int id, UsuarioCreateUpdateDto usuarioEditado){
      //Buscar a usuario no bd
        var usuario = _contexto.Usuarios.Include(usuario => usuario.Curriculo).SingleOrDefault(usuario => usuario.Id == id);

        if (usuario is null)
            throw new Exception("Candidato não encontrado");

        //Copiar os dados que vieram 
        //Mapeando do UsuarioCreateUpdateDto para Usuario (objeto ja existente)
        usuarioEditado.Adapt(usuario);

        //salvar as alterações no banco de dados
        _contexto.SaveChanges();

        //Mapear de Usuario para UsuarioRespondeDto
        var UsuarioResposta = usuario.Adapt<UsuarioResponseDto>();

        return UsuarioResposta;
    }
    public void DeletarUsuario(int id)
    {
        //Buscar a empresa no bd
        var usuario = _contexto.Usuarios.SingleOrDefault(usuario => usuario.Id == id);

        if (usuario is null)
            throw new Exception("Candidato não encontrado");

        //Deletar no contexto na memoria
        _contexto.Remove(usuario);

        //Salvar a deleção do banco de dados
        _contexto.SaveChanges();

    }

}
