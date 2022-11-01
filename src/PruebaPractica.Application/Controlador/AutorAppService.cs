using PruebaPractica.Application.Modelo;
using PruebaPractica.Domain.Controlador;
using PruebaPractica.Domain.Modelo;

namespace PruebaPractica.Application.Controlador;

public class AutorAppService : IAutorAppService
{
    private readonly IAutorRepository repository;

    public AutorAppService(IAutorRepository repository)
    {
        this.repository = repository;
    }

    public async Task<AutorDto> CreateAsync(AutorCrearActualizarDto autorDto)
    {
         //Reglas Validaciones... 
        var existeNombreautor = await repository.ExisteNombre(autorDto.Nombre);
        if (existeNombreautor){
            throw new ArgumentException($"Ya existe un editorial con el nombre {autorDto.Nombre}");
        }
 
        //Mapeo Dto => Entidad
        var autor = new Autor();
        autor.Nombre = autorDto.Nombre;
 
        //Persistencia objeto
        autor = await repository.AddAsync(autor);
        //await unitOfWork.SaveChangesAsync();

        //Mapeo Entidad => Dto
        var autorCreada = new AutorDto();
        autorCreada.Nombre = autor.Nombre;
        autorCreada.Id = autor.Id;
        autorCreada.CuidadNacimiento = autor.CuidadNacimiento;

        //TODO: Enviar un correo electronica... 

        return autorCreada;
    }

    public async Task<bool> DeleteAsync(int autorid)
    {
        //Reglas Validaciones... 
        var autor = await repository.GetByIdAsync(autorid);
        if (autor == null){
            throw new ArgumentException($"La marca con el id: {autorid}, no existe");
        }

        repository.Delete(autor);
        //await unitOfWork.SaveChangesAsync();

        return true;
    }

    public ICollection<AutorDto> GetAll()
    {
        var autorList = repository.GetAll();

        var autorListDto =  from m in autorList
                            select new AutorDto(){
                                Id = m.Id,
                                Nombre = m.Nombre,
                                CuidadNacimiento = m.CuidadNacimiento
                            };

        return autorListDto.ToList();
    }

    public async Task UpdateAsync(int id, AutorCrearActualizarDto autorDto)
    {
        var autor = await repository.GetByIdAsync(id);
        if (autor == null){
            throw new ArgumentException($"La marca con el id: {id}, no existe");
        }
        
        var existeNombreAutor = await repository.ExisteNombre(autorDto.Nombre,id);
        if (existeNombreAutor){
            throw new ArgumentException($"Ya existe una marca con el nombre {autorDto.Nombre}");
        }

        //Mapeo Dto => Entidad
        autor.Nombre = autorDto.Nombre;

        //Persistencia objeto
        await repository.UpdateAsync(autor);
        //await unitOfWork.SaveChangesAsync();

        return;
    }
    
}