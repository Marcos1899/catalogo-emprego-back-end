using CatalogoEmprego.Data;
using CatalogoEmprego.Models;
using CatalogoEmpregoBack.Dtos.Vaga;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogoEmpregoBack.Servicos;

public class VagaServico
{
    private readonly CatalogoContexto _contexto;

    public VagaServico([FromServices] CatalogoContexto contexto)
    {
        _contexto = contexto;
    }

    public List<VagaResponseDto> RecuperarVagas(){
        return _contexto.Vagas.AsNoTracking().Include(vaga => vaga.Empresa).ProjectToType<VagaResponseDto>().ToList();
    }
    public VagaResponseDto RecuperarVaga(int id){

        var vaga = _contexto.Vagas.AsNoTracking().Include(vaga => vaga.Empresa).SingleOrDefault(vaga => vaga.Id == id);

        if (vaga is null)
            throw new Exception("Vaga não encontrada");

        //Mapear do objeto Vaga para VagaRespondeDto
        VagaResponseDto vagaResposta = vaga.Adapt<VagaResponseDto>();

        return vagaResposta;
    }
    public VagaResponseDto AdicionarVaga(VagaCreateUpdateDto vagaDto)
    {
        //Mapear de VagaCreateUpdateDto para vaga
        var vaga = vagaDto.Adapt<Vaga>();

        //Adicionar no contexto
        _contexto.Vagas.Add(vaga);

        //Comando para salvar que realmente salva no banco de dados
        _contexto.SaveChanges();

        //Mapear de Vaga para VagaDto
        var vagaResposta = vaga.Adapt<VagaResponseDto>();
        return vagaResposta; 
    } 
      public VagaResponseDto AtualizarVaga(int id, VagaCreateUpdateDto vagaEditada){
      //Buscar a vaga no bd
        var vaga = _contexto.Vagas.SingleOrDefault(vaga => vaga.Id == id);

        if (vaga is null)
            throw new Exception("Vaga não encontrada");

        //Copiar os dados que vieram 
        //Mapeando do VagaCreateUpdateDto para Vaga (objeto ja existente)
        vagaEditada.Adapt(vaga);

        //salvar as alterações no banco de dados
        _contexto.SaveChanges();

        //Mapear de Vaga para VagaRespondeDto
        var VagaResposta = vaga.Adapt<VagaResponseDto>();

        return VagaResposta;
      }
    public void DeletarVaga(int id){
        //Buscar a vaga no bd
        var vaga = _contexto.Vagas.SingleOrDefault(vaga => vaga.Id == id);

        if (vaga is null)
            throw new Exception("Vaga não encontrado");

        //Deletar no contexto na memoria
        _contexto.Remove(vaga);

        //Salvar a deleção do banco de dados
        _contexto.SaveChanges();

    }


}
