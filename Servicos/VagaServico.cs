using CatalogoEmprego.Data;
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
        return _contexto.Vagas.AsNoTracking().ProjectToType<VagaResponseDto>().ToList();
    }

}
