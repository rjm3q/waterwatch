using waterwatch.Models;
using waterwatch.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace waterwatch.Repositories
{
    public class WaterConsumptionRepository : IWaterConsumptionRepository
    {
        private readonly IDataContext _context;

        public WaterConsumptionRepository(IDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WaterConsumption>> GetAll()
        {
            SaveData();
            return await _context.Consumptions.ToListAsync();
        }

        public async Task<IEnumerable<WaterConsumption>> GetTopTenConsumers()
        {
            var q = _context.Consumptions
                .OrderByDescending(avgKL => avgKL.averageMonthlyKL)
                .Take(10)
                .ToListAsync();
                
            return await q;
        }

        public void SaveData()
        {
            var res_dataset = _context.Consumptions.ToList();

            if (res_dataset.Count() == 0)
            {
                Console.WriteLine("No Data");

                var geoJSON = File.ReadAllText("C:\\Users\rober\\Workspace\\waterwatch\\water_consumption.geojson");
                dynamic jsonObj = JsonConvert.DeserializeObject(geoJSON);

                foreach (var feature in jsonObj["features"])
                {
                    //Extract values from the file object using the fields
                    string str_neighbourhood = feature["properties"]["neighbourhood"];
                    string str_suburb_group = feature["properties"]["suburb_group"];
                    string str_avgMonthlyKL = feature["properties"]["avgMonthlyKL"];
                    string str_geometry = feature["geometry"]["coordinates"].ToList(Newtonsoft.Json.Formatting.None);

                    //Apply transformation

                    //remove .0's from values
                    string conv_avgMthlyKl = str_avgMonthlyKL.Replace(".0", "");
                    //Convert string
                    int avMthlykl = Convert.ToInt32(conv_avgMthlyKl);

                    //Load data into table
                    WaterConsumption wc = new()
                    {
                        neighbourhood= str_neighbourhood,
                        suburb_group = str_suburb_group,
                        averageMonthlyKL = avMthlykl,
                        coordinates = str_geometry
                    };
                    //use context to write data to table
                    _context.Consumptions.Add(wc);
                    _context.SaveChanges();
                

                }
            }
            else
            {
                Console.WriteLine("Data Loaded");
            }
        }
    }
}