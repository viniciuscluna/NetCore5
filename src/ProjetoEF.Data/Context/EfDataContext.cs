
using Microsoft.EntityFrameworkCore;

public class EfDataContext : DbContext{
    public EfDataContext(DbContextOptions options)
    :base(options)
    {
        
    }
    public DbSet<Carro> Carros {get;set;}
}