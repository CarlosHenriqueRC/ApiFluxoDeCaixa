using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Web.Api.FluxoDeCaixa.Lancamento.InfraEstructura.Persistencia;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FluxoDeCaixaContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<Web.Api.FluxoDeCaixa.Lancamento.Dominio.Servicos.Interfaces.IContas, Web.Api.FluxoDeCaixa.Lancamento.Dominio.Servicos.Contas>();
builder.Services.AddTransient<Web.Api.FluxoDeCaixa.Lancamento.Dominio.Repositorios.Interfaces.IContas, Web.Api.FluxoDeCaixa.Lancamento.InfraEstructura.Repositorios.Contas>();
builder.Services.AddTransient<Web.Api.FluxoDeCaixa.Lancamento.Dominio.Servicos.Interfaces.ILancamentos, Web.Api.FluxoDeCaixa.Lancamento.Dominio.Servicos.Lancamentos>();
builder.Services.AddTransient<Web.Api.FluxoDeCaixa.Lancamento.Dominio.Repositorios.Interfaces.ILancamentos, Web.Api.FluxoDeCaixa.Lancamento.InfraEstructura.Repositorios.Lancamentos>();
builder.Services.AddTransient<Web.Api.FluxoDeCaixa.Lancamento.ServicosDeAplicacao.Interfaces.ILancamento, Web.Api.FluxoDeCaixa.Lancamento.ServicosDeAplicacao.Lancamento>();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var ci = new CultureInfo("pt-BR");

    var supportedCultures = new[] {ci};

    options.DefaultRequestCulture = new RequestCulture(culture: ci, uiCulture: ci);
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
    options.RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider()
                };
});


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
app.UseRequestLocalization();
app.Run();
