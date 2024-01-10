using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using waterwatch.Models;

namespace waterwatch.Data
{
    public class DataContext :DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }

        public DbSet<WaterConsumption> Consumptions {get; set;}
    }
}