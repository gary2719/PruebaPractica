using PruebaPractica.Domain.Modelo;

namespace PruebaPractica.Domain.Controlador;

public interface IAutorRepository : IRepository<Autor>
{
    Task<bool> ExisteNombre(string nombre);

    Task<bool> ExisteNombre(string nombre, int idExcluir);
}

