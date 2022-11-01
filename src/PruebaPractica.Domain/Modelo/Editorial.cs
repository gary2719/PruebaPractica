using System.ComponentModel.DataAnnotations;

namespace PruebaPractica.Domain.Modelo;

public class Editorial
{
    [Required]
    public int Id { get; set; }

    public string Nombre {get; set;}
    public string? Cuidad { get; set; }
    
}
