using System.ComponentModel.DataAnnotations;

namespace PruebaPractica.Domain.Modelo;

public class Libro
{
    [Required]
    public int Id { get; set; }
    public string? Titulo { get; set; }
    public int Observaciones { get; set; }

    [Required]
    public int AutorId { get; set; }
    public virtual Autor Autor { get; set; }

    [Required]
    public int EditorialId { get; set; }
    public virtual Editorial Editorial { get; set; }
}
