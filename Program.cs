using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalsAPIs_Projeto.Dominio.DTOs;
using MinimalsAPIs_Projeto.Dominio.Interfaces;
using MinimalsAPIs_Projeto.Dominio.Servicos;
using MinimalsAPIs_Projeto.Infraestrutura.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAdministradorServico, AdministradorServico>();

builder.Services.AddDbContext<DbContexto>(options => 
    {
        options.UseMySql(builder.Configuration.GetConnectionString("mysql"), 
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql"))
        );
    }
);
    
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/login", ([FromBody]LoginDTO loginDTO, IAdministradorServico administradorServico) => {
    if (administradorServico.Login(loginDTO) != null)
    {
        return Results.Ok("Login efetuado com sucesso!");
    }
    else
    {
        return Results.Unauthorized();
    }
});

app.Run();


