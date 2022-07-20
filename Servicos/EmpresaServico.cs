using CatalogoEmprego.Data;
using CatalogoEmprego.Dtos.Empresa;
using CatalogoEmprego.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogoEmprego.Serviços;

public class EmpresaServico
{
    //Reservado para qualquer regra de negocio do sistema
    //readonly quer dizer somente para leitura

    private readonly CatalogoContexto _contexto;

    public EmpresaServico([FromServices] CatalogoContexto contexto)
    {
        _contexto = contexto;
    }

    public List<EmpresaResponseDto> RecuperarEmpresas()
    {
        //qualquer regra de negocio  pra aplicaçao

        return _contexto.Empresas.AsNoTracking().ProjectToType<EmpresaResponseDto>().ToList();
        
        //Outra maneira de fazer
        //var empresas = _contexto.Empresas.ToList();
        //var empresaResposta = empresas.Adapt<List<EmpresaResponseDto>>().ToList();
        //return empresaResposta;

        //return _contexto.Empresas.ToList();
    }

    public EmpresaResponseDto RecuperarEmpresa(int id)
    {
        var empresa = _contexto.Empresas.AsNoTracking().SingleOrDefault(empresa => empresa.Id == id);

        if (empresa is null)
            throw new Exception("Empresa não encontrada");

        //Mapear do objeto Empresa para EmpresaRespondeDto
        EmpresaResponseDto empresaResposta = empresa.Adapt<EmpresaResponseDto>();


        // var empresaResposta = new EmpresaResponseDto(){      
        // Id = empresa.Id,
        // RazaoSocial = empresa.RazaoSocial,
        // NomeFantasia = empresa.NomeFantasia,
        // Cnpj = empresa.Cnpj,
        // Cidade = empresa.Cidade,
        // Estado = empresa.Endereco,
        // Endereco  = empresa.Endereco,
        // Telefone = empresa.Telefone,
        // Email = empresa.Email,
        // Senha = empresa.Senha
        // };

        return empresaResposta;
    }

    public EmpresaResponseDto AdicionarEmpresa(EmpresaCreateUpdateDto empresaDto)
    {
        //Mapear de EmpresaCreateUpdateDto para empresa
        var empresa = empresaDto.Adapt<Empresa>();

       // var empresa = new Empresa()
       // {
       //     RazaoSocial = empresaDto.RazaoSocial,
       //     NomeFantasia = empresaDto.NomeFantasia,
       //     Cnpj = empresaDto.Cnpj,
       //     Cidade = empresaDto.Cidade,
       //     Estado = empresaDto.Endereco,
       //     Endereco = empresaDto.Endereco,
       //     Telefone = empresaDto.Telefone,
       //     Email = empresaDto.Email,
       //    Senha = empresaDto.Senha
       // };



        //espaço para regra de negocio, caso a gente precise no futuro tratar alguma propriedade 
        //calculo de imposto,etc
        //tem que ser feita no serviço e não no controlador

        //Salvar o empresa no banco de dados
        //adicionadno a empresa no contexto na memoria
        _contexto.Empresas.Add(empresa);

        //Comando para salvar que realmente salva no banco de dados
        _contexto.SaveChanges();

        //Mapear de Empresa para EmpresaDto
        var empresaResposta = empresa.Adapt<EmpresaResponseDto>();

        //var empresaResposta = new EmpresaResponseDto()
        //{
        //    RazaoSocial = empresaDto.RazaoSocial,
        //    NomeFantasia = empresaDto.NomeFantasia,
        //    Cnpj = empresaDto.Cnpj,
        //    Cidade = empresaDto.Cidade,
        //    Estado = empresaDto.Endereco,
        //    Endereco = empresaDto.Endereco,
        //    Telefone = empresaDto.Telefone,
        //    Email = empresaDto.Email,
        //    Senha = empresaDto.Senha
       // };

        return empresaResposta;

    }

    public EmpresaResponseDto AtualizarEmpresa(int id, EmpresaCreateUpdateDto EmpresaEditado)
    {
        //Buscar a empresa no bd
        var empresa = _contexto.Empresas.SingleOrDefault(empresa => empresa.Id == id);

        if (empresa is null)
            throw new Exception("Empresa não encontrada");

        //Copiar od dados que vieram do cliente
        //Mapeando do EmpresaCreateUpdateDto para Empresa (objeto ja existente)
        EmpresaEditado.Adapt(empresa);

        //empresa.RazaoSocial = EmpresaEditado.RazaoSocial;
        //empresa.NomeFantasia = EmpresaEditado.NomeFantasia;
        //empresa.Cnpj = EmpresaEditado.Cnpj;
        //empresa.Cidade = EmpresaEditado.Cidade;
        //empresa.Estado = EmpresaEditado.Estado;
        //empresa.Endereco = EmpresaEditado.Endereco;
        //empresa.Telefone = EmpresaEditado.Telefone;
        //empresa.Email = EmpresaEditado.Email;
        //empresa.Senha = EmpresaEditado.Senha;

        //salvar as alterações no banco de dados
        _contexto.SaveChanges();

        //Mapear de Empresa para EmpresaRespondeDto
        var empresaResposta = empresa.Adapt<EmpresaResponseDto>();


        return empresaResposta;

    }

    public void DeletarEmpresa(int id)
    {
        //Buscar a empresa no bd
        var empresa = _contexto.Empresas.SingleOrDefault(empresa => empresa.Id == id);

        if (empresa is null)
            throw new Exception("Empresa não encontrada");

        //Deletar no contexto na memoria
        _contexto.Remove(empresa);

        //Salvar a deleção do banco de dados
        _contexto.SaveChanges();

    }

}
