using System.ComponentModel.DataAnnotations;

namespace PruebaPractica.Domain.Modelo;

public class Autor
{
    [Required]

    public int Id {get;set;}

    public string? Nombre{get;set;}

    public string CuidadNacimiento {get;set;}
}
