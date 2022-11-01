using Microsoft.AspNetCore.Mvc;
using PruebaPractica.Application.Controlador;
using PruebaPractica.Application.Modelo;
using PruebaPractica.Domain.Controlador;

namespace PruebaPractica.HttpApi.Controllers;
[ApiController]
[Route("[controller]")]
public class LibroController :ControllerBase{

    private readonly IEditorialAppService repository;

    public LibroController(IEditorialAppService repository)
    {
        this.repository = repository;
    }

     [HttpGet]
    public ICollection<LibroDto> GetAll()
    {

        return editorialAppService.GetAll();
    }

    [HttpPost]
    public async Task<LibroDto> CreateAsync(LibroCrearActualizarDto libro)
    {

        return await librolAppService.CreateAsync(libro);

    }

    [HttpPut]
    public async Task UpdateAsync(int id, LibroCrearActualizarDto libro)
    {

        await editorialAppService.UpdateAsync(id, editorial);

    }

    [HttpDelete]
    public async Task<bool> DeleteAsync(int libroId)
    {

        return await libroAppService.DeleteAsync(libroId);

    }
  

}