using Microsoft.EntityFrameworkCore;
using PruebaPractica.Domain;
using PruebaPractica.Domain.Modelo;

namespace PruebaPractica.Infraestructure;

public class PruebaPracticaDbContext : DbContext, IUnitOfWork
{
    
    public DbSet<Libro> Libros1 {get; set;}
    public DbSet<Autor> Autores {get; set;}
    public DbSet<Editorial> Editoriales {get; set;}

    public string DbPath { get; set; }

    public PruebaPracticaDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "biblioteca.v1.db");

    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}
