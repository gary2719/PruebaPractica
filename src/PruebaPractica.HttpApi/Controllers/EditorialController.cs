using Microsoft.AspNetCore.Mvc;
using PruebaPractica.Application.Controlador;
using PruebaPractica.Application.Modelo;
using PruebaPractica.Domain.Controlador;

namespace PruebaPractica.HttpApi.Controllers;
[ApiController]
[Route("[controller]")]
public class EditorialController :ControllerBase{

    private readonly IEditorialAppService repository;

    public EditorialController(IEditorialAppService repository)
    {
        this.repository = repository;
    }

     [HttpGet]
    public ICollection<EditorialDto> GetAll()
    {

        return editorialAppService.GetAll();
    }

    [HttpPost]
    public async Task<EditorialDto> CreateAsync(EditorialCrearActualizarDto editorial)
    {

        return await editorialAppService.CreateAsync(editorial);

    }

    [HttpPut]
    public async Task UpdateAsync(int id, EditorialCrearActualizarDto editorial)
    {

        await editorialAppService.UpdateAsync(id, editorial);

    }

    [HttpDelete]
    public async Task<bool> DeleteAsync(int editorialId)
    {

        return await meditorialAppService.DeleteAsync(editorialId);

    }
  

}