using PruebaPractica.Domain.Modelo;

namespace PruebaPractica.Application.Modelo;

public class LibroDto
{
    public int Id { get; set; }
    public string? Titulo { get; set; }
    public int AnioPublicacion { get; set; }

    public int AutorId { get; set; }
    public virtual Autor Autor { get; set; }

    public int EditorialId { get; set; }
    public virtual Editorial Editorial { get; set; }
}
