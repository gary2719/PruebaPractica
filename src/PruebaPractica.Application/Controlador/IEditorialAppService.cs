using PruebaPractica.Application.Modelo;

namespace PruebaPractica.Application.Controlador;

public interface IEditorialAppService {

     ICollection<EditorialDto> GetAll();

    Task<EditorialDto> CreateAsync(EditorialCrearActualizarDto editorial);

    Task UpdateAsync (int id, EditorialCrearActualizarDto editorial);

    Task<bool> DeleteAsync(int editorialId);
}