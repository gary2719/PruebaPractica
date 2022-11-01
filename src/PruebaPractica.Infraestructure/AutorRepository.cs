using PruebaPractica.Domain.Controlador;
using Microsoft.EntityFrameworkCore;
namespace PruebaPractica.Infraestructure;

public class AutorRepository: EfRepository<Autor>, IAutorRepository{

    public AutorRepository(PruebaPracticaDbContext context) : base(context)
    {
    }

    public async Task<bool> ExisteNombre(string nombre) {

        var resultado = await this._context.Set<Autor>()
                       .AnyAsync(x => x.Nombre.ToUpper() == nombre.ToUpper());

        return resultado;
    }

    public async Task<bool> ExisteNombre(string nombre, int idExcluir)  {

        var query =  this._context.Set<Autor>()
                       .Where(x => x.Id != idExcluir)
                       .Where(x => x.Nombre.ToUpper() == nombre.ToUpper())
                       ;

        var resultado = await query.AnyAsync();

        return resultado;
    }


}