using Microsoft.EntityFrameworkCore;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Data.Repo
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly DataContext dataContext;


        public PropertyRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;

        }

        public void AddProperty(Property property)
        {
            dataContext.Properties.Add(property);
        }

        public void DeleteProperty(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Property>> GetPropertiesAsync(int sellRent)
        {
            var properties = await dataContext.Properties
            .Include(p => p.PropertyType)
            .Include(p => p.FurnishingType)
            .Include(p => p.City)
            .Include(p => p.Photos)
            .Where(p => p.SellRent == sellRent).ToListAsync();
            return properties;
        }

        public async Task<Property> GetPropertyDetailAsync(int id)
        {
            var properties = await dataContext.Properties
            .Include(p => p.PropertyType)
            .Include(p => p.FurnishingType)
            .Include(p => p.City)
            .Include(p => p.Photos)
            .Where(p => p.Id == id).FirstAsync();

            return properties;
        }

        public async Task<Property> GetPropertyIdAsync(int id)
        {
            var properties = await dataContext.Properties
            .Include(p => p.Photos)
            .Where(p => p.Id == id).FirstOrDefaultAsync();

            return properties;
        }

    }
}