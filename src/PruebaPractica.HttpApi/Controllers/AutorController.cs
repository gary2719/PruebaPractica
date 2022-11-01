using Microsoft.AspNetCore.Mvc;
using PruebaPractica.Application.Controlador;
using PruebaPractica.Application.Modelo;
using PruebaPractica.Domain.Controlador;

namespace PruebaPractica.HttpApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AutorController : ControllerBase
{
    private readonly IAutorAppService repository;

    public AutorController(IAutorAppService repository)
    {
        this.repository = repository;
    }

    [HttpGet]
    public ICollection<AutorDto> GetAll()
    {
        return repository.GetAll();
    }

    [HttpPost]
    public async Task<bool> CreateAsync(AutorCrearActualizarDto tp)
    {
        return await repository.CreateAsync(tp);
    }

    [HttpPut]
    public async Task<bool> UpdateAsync(int id, AutorCrearActualizarDto tp)
    {
        return await repository.UpdateAsync(id, tp);
    }

    [HttpDelete]
    public async Task<bool> DeleteAsync(int marcaId)
    {
        return await repository.DeleteAsync(marcaId);
    }
}
