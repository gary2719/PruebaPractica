using PruebaPractica.Application.Controlador;
using PruebaPractica.Domain.Controlador;
using PruebaPractica.Infraestructure;
using PruebaPractica.Infraestructure.Controlador;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<PruebaPracticaDbContext>();


//autor
builder.Services.AddTransient<IAutorRepository, AutorRepository>();
builder.Services.AddTransient<IAutorAppService, AutorAppService>();


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
