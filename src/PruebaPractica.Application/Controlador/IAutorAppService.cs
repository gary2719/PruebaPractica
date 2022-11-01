using PruebaPractica.Application.Modelo;

namespace PruebaPractica.Application.Controlador;

public interface IAutorAppService
{
    ICollection<AutorDto> GetAll();

    Task<AutorDto> CreateAsync(AutorCrearActualizarDto autor);

    Task UpdateAsync (int id, AutorCrearActualizarDto autor);

    Task<bool> DeleteAsync(int autorid);
    
}
