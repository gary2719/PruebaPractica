using PruebaPractica.Application.Modelo;
using PruebaPractica.Domain.Controlador;
using PruebaPractica.Domain.Modelo;

namespace PruebaPractica.Application.Controlador;

public class EditorialAppService : IEditorialAppService
{
    private readonly IEditorialRepository repository;

    public EditorialAppService(IEditorialRepository repository)
    {
        this.repository = repository;
    }

    public async Task<EditorialDto> CreateAsync(EditorialCrearActualizarDto editorialDto)
    {
         //Reglas Validaciones... 
        var existeNombreEditorial = await repository.ExisteNombre(editorialDto.Nombre);
        if (existeNombreEditorial){
            throw new ArgumentException($"Ya existe un editorial con el nombre {editorialDto.Nombre}");
        }
 
        //Mapeo Dto => Entidad
        var editorial = new Editorial();
        editorial.Nombre = editorialDto.Nombre;
 
        //Persistencia objeto
        editorial = await repository.AddAsync(editorial);
        //await unitOfWork.SaveChangesAsync();

        //Mapeo Entidad => Dto
        var editorialCreada = new EditorialDto();
        editorialCreada.Nombre = editorial.Nombre;
        editorialCreada.Id = editorial.Id;
        editorialCreada.Cuidad = editorial.Cuidad;

        //TODO: Enviar un correo electronica... 

        return editorialCreada;
    }

    public async Task<bool> DeleteAsync(int editorialId)
    {
         //Reglas Validaciones... 
        var editorial = await repository.GetByIdAsync(editorialId);
        if (editorial == null){
            throw new ArgumentException($"La marca con el id: {editorialId}, no existe");
        }

        repository.Delete(editorial);
        //await unitOfWork.SaveChangesAsync();

        return true;
    }

    public ICollection<EditorialDto> GetAll()
    {
         var editorialList = repository.GetAll();

        var editorialListDto =  from m in editorialList
                            select new EditorialDto(){
                                Id = m.Id,
                                Nombre = m.Nombre,
                                Cuidad = m.Cuidad
                            };

        return editorialListDto.ToList();
    }


    public async Task UpdateAsync(int id, EditorialCrearActualizarDto editorialDto)
    {
        var editorial = await repository.GetByIdAsync(id);
        if (editorial == null){
            throw new ArgumentException($"La marca con el id: {id}, no existe");
        }
        
        var existeNombreEditorial = await repository.ExisteNombre(editorialDto.Nombre,id);
        if (existeNombreEditorial){
            throw new ArgumentException($"Ya existe una marca con el nombre {editorialDto.Nombre}");
        }

        //Mapeo Dto => Entidad
        editorial.Nombre = editorialDto.Nombre;

        //Persistencia objeto
        await repository.UpdateAsync(editorial);
        //await unitOfWork.SaveChangesAsync();

        return;
    }
}