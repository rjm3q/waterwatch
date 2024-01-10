using waterwatch.Models;
using Microsoft.EntityFrameworkCore;

namespace waterwatch.Repositories
{
    public interface IWaterConsumptionRepository
    {
        // function returns a list with a schema the same as the model
        Task<IEnumerable<WaterConsumption>> GetAll();
        
        //function returns avg usage in descending order
        Task<IEnumerable<WaterConsumption>> GetTopTenConsumers();
    }
}
