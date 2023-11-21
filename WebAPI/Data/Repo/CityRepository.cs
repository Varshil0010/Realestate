using Microsoft.EntityFrameworkCore;
using WebAPI.DTOS;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Data.Repo
{
    public class CityRepository : ICityRepository
    {
        private readonly DataContext dataContext;
        public CityRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
            
        }
        public void AddCity(City city)
        {
            dataContext.Cities.AddAsync(city);
        }

        public void AddCity(CityDTO city)
        {
            throw new NotImplementedException();
        }


        public void DeleteCity(int CityId)
        {
            var city = dataContext.Cities.Find(CityId);
            dataContext.Cities.Remove(city);
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await dataContext.Cities.ToListAsync();
        }

    }
}