using BibliotecaApi.Domain.Repositories;
using BibliotecaApi.Infrastructure.Data;
using BibliotecaApi.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data source = biblioteca.db"));
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(BibliotecaApi.Application.Livros.Commands.CriarLivro.CriarLivroCommand)
        .Assembly));

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();