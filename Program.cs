using BibliotecaAPI.Services;
using BibliotecaAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Registrando serviços da aplicação
builder.Services.AddSingleton<LivroService>();
builder.Services.AddSingleton<UsuarioService>();
builder.Services.AddSingleton<EmprestimoService>();
builder.Services.AddSingleton<RelatorioService>();
builder.Services.AddSingleton<PromptService>(); 

builder.Services.AddControllers();

// --- ADICIONAR SWAGGER ---
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// --- HABILITAR SWAGGER EM DEV ---
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();