using MaeGestante.Data.Repositories;
using MaeGestante.Services;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Configuração da cadeia de conexão do banco de dados
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


// Adicione seus serviços personalizados aqui, incluindo serviços de repositório e serviço
builder.Services.AddSingleton(connectionString);

// Repositórios
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<GestanteRepository>();
builder.Services.AddScoped<ProfissionalSaudeRepository>();
builder.Services.AddScoped<HistoricoMedicoRepository>();
builder.Services.AddScoped<ReceitaRepository>();
builder.Services.AddScoped<ExameRepository>();
builder.Services.AddScoped<CartaoGestanteRepository>();
builder.Services.AddScoped<AgendaEspecialistaRepository>();
builder.Services.AddScoped<DiasFolgaRepository>();
builder.Services.AddScoped<ConsultaRepository>();
builder.Services.AddScoped<EspecialidadeRepository>();
builder.Services.AddScoped<StatusConsultaRepository>();
builder.Services.AddScoped<TipoUsuarioRepository>();

// Serviços
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<GestanteService>();
builder.Services.AddScoped<ProfissionalSaudeService>();
builder.Services.AddScoped<HistoricoMedicoService>();
builder.Services.AddScoped<ReceitaService>();
builder.Services.AddScoped<ExameService>();
builder.Services.AddScoped<CartaoGestanteService>();
builder.Services.AddScoped<AgendaEspecialistaService>();
builder.Services.AddScoped<DiasFolgaService>();
builder.Services.AddScoped<ConsultaService>();
builder.Services.AddScoped<EspecialidadeService>();
builder.Services.AddScoped<StatusConsultaService>();
builder.Services.AddScoped<TipoUsuarioService>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Mãe Gestante", Version = "v1" });
});

var app = builder.Build();

// Configurar o pipeline de solicitação HTTP
if (app.Environment.IsDevelopment() || true)
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sua API V1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
