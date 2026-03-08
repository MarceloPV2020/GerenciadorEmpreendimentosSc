<<<<<<< Updated upstream
=======
using FluentValidation;
using GerenciadorEmpreendimentosSc.Api.Data;
using GerenciadorEmpreendimentosSc.Api.Dtos;
using Microsoft.EntityFrameworkCore;

>>>>>>> Stashed changes
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
<<<<<<< Updated upstream
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
=======

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddProblemDetails();
builder.Services.AddHealthChecks();

builder.Services.AddValidatorsFromAssemblyContaining<EmpreendimentoCreateDto.Validator>();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    var cs = builder.Configuration.GetConnectionString("Default");
    opt.UseSqlite(cs);
});
>>>>>>> Stashed changes

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
