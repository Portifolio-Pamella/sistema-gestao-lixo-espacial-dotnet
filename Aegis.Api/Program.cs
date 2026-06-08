using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Aegis.Api.Data;
using Aegis.Api.Repositories;
using Aegis.Api.Repositories.Interfaces;
using Aegis.Api.Services;
using Aegis.Api.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuração do Banco de Dados Oracle
var connectionString = builder.Configuration.GetConnectionString("OracleConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(connectionString));

// 2. Registro de Repositórios (Injeção de Dependência)
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<ISateliteRepository, SateliteRepository>();
builder.Services.AddScoped<IDetritoRepository, DetritoRepository>();
builder.Services.AddScoped<IChaserRepository, ChaserRepository>();
builder.Services.AddScoped<IAlertaRepository, AlertaRepository>();
builder.Services.AddScoped<IMissaoRepository, MissaoRepository>();

// 3. Registro de Services (Injeção de Dependência)
builder.Services.AddScoped<IEmpresaService, EmpresaService>();
builder.Services.AddScoped<ISateliteService, SateliteService>();
builder.Services.AddScoped<IDetritoService, DetritoService>();
builder.Services.AddScoped<IChaserService, ChaserService>();
builder.Services.AddScoped<IAlertaService, AlertaService>();
builder.Services.AddScoped<IMissaoService, MissaoService>();

// 4. Configuração de Controllers e JSON
builder.Services.AddControllers()
    .AddJsonOptions(x =>
        x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// 5. Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    int maxRetries = 15;
    bool connected = false;

    while (maxRetries > 0 && !connected)
    {
        try
        {
            Console.WriteLine($"Tentando conectar ao banco... ({maxRetries} tentativas restantes)");
            context.Database.OpenConnection();
            context.Database.EnsureCreated(); // Cria as tabelas se necessário
            context.Database.CloseConnection();
            Console.WriteLine("Banco de dados pronto!");
            connected = true;
        }
        catch (Exception ex)
        {
            maxRetries--;
            Console.WriteLine($"Aguardando banco Oracle subir... Erro: {ex.Message.Substring(0, 30)}...");
            Thread.Sleep(10000); // Espera 10 segundos antes de tentar de novo
        }
    }
}
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
