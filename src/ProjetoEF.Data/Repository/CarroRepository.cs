using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class CarroRepository : ICarroRepository {
    private readonly EfDataContext _context;
    public CarroRepository(EfDataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Carro>> GetCars()
    {
        return await _context.Carros.ToListAsync();
    }

    public async Task<bool> InsertCars()
    {
        var carros = new List<Carro>{
            new Carro { Modelo = "Agile",Marca="Chevrolet"},
            new Carro { Modelo = "Celta",Marca="Chevrolet"}
        };
        _context.Carros.AddRange(carros);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ClearCars(){
        var removes = await _context.Carros.ToListAsync();
        _context.Carros.RemoveRange(removes);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Carro> GetById(int id){
        return await _context.Carros.FirstOrDefaultAsync(f=>f.Id == id);
    }
}