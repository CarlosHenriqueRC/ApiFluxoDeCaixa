using Microsoft.EntityFrameworkCore;
using Web.Api.FluxoDeCaixa.Conta.InfraEstructura.Persistencia;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FluxoDeCaixaContext>((options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))));

builder.Services.AddTransient<Web.Api.FluxoDeCaixa.Conta.Dominio.Servicos.Interfaces.IContas, Web.Api.FluxoDeCaixa.Conta.Dominio.Servicos.Contas>();
builder.Services.AddTransient<Web.Api.FluxoDeCaixa.Conta.Dominio.Repositorios.Interfaces.IContas, Web.Api.FluxoDeCaixa.Conta.InfraEstructura.Repositorios.Contas>();
builder.Services.AddTransient<Web.Api.FluxoDeCaixa.Conta.ServicosDeAplicacao.Interfaces.IConta, Web.Api.FluxoDeCaixa.Conta.ServicosDeAplicacao.Conta>();

var app = builder.Build();

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
