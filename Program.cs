using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using minimal_api.Domains.DTO;
using minimal_api.Domains.Interfaces;
using minimal_api.Domains.Services;
using minimal_api.Structure.DB;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAdminServices, AdministratorService>();

builder.Services.AddDbContext<DbContexto>(
  options => options.UseMySql(
    builder.Configuration.GetConnectionString("mysql"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql"))
  )
);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/login", ([FromBody]LoginDTO loginDTO, IAdminServices administratorService) => {
  if(administratorService.Login(loginDTO) != null){
    return Results.Ok("Login com sucesso");
  }
  else{
    return Results.Unauthorized();
  }
});

app.Run();



