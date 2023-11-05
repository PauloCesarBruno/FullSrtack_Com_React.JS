using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using ProAtividade.data.Repositories;
using ProAtividade.Data.Context;
using ProAtividade.Domain.Interfaces.Repositories;
using ProAtividade.Domain.Interfaces.Services;
using ProAtividade.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//=======================================================================
// No NET 6 a Configuração é assim:
var connection = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<DataContext>(Options => 
                     Options.UseSqlite(connection));
//=======================================================================

// Dependency Injections Necessárias:
builder.Services.AddScoped<IAtividadeRepoGetDados, AtividadeRepoGetDados>();
builder.Services.AddScoped<IGeralRepoManipulaDados, GeralRepoManipulaDados>();
builder.Services.AddScoped<IAtividadeService,   AtividadeService>();

builder.Services.AddControllers()
                .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    }
                );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors (x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.MapControllers();

app.Run();
