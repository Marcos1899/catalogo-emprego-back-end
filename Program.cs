using CatalogoEmprego.Data;
using CatalogoEmprego.Serviços;
using CatalogoEmpregoBack.Servicos;
using Microsoft.EntityFrameworkCore;

internal class NewBaseType
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        //Adicionando a configuração para usar o contexto no acesso ao BD
        builder.Services.AddDbContext<CatalogoContexto>(
            //Dizendo que quero usar o MySql
            options => options.UseMySql(
                //Pegando o endereco do servidor Mysql
                builder.Configuration.GetConnectionString("ConexaoBanco"),
                //Detectando automaticamente a versao do servidor instalado
                ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("ConexaoBanco"))
            )
        );

        //Nossas classes de serviços criadas
        builder.Services.AddScoped<EmpresaServico>();
        builder.Services.AddScoped<UsuarioServico>();
        builder.Services.AddScoped<VagaServico>();



        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        //Desabilitando o CORS para o endereco do Front
        //Coloque o endereco do seu front
        app.UseCors(policy => policy.WithOrigins("https://localhost:7108")
        .AllowAnyMethod()
        .AllowAnyHeader()
        );

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
