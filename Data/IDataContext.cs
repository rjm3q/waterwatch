using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using waterwatch.Models;

namespace waterwatch.Data
{
    public interface IDataContext
    {
        DbSet<WaterConsumption> Consumptions {get; set;}
        int SaveChanges();
        
    }
}