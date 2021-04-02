using System.Collections.Generic;
using System.Threading.Tasks;

public interface ICarroRepository{
    Task<bool> InsertCars();
    Task<IEnumerable<Carro>> GetCars();
    Task<Carro> GetById(int id);
    Task<bool> ClearCars();
}