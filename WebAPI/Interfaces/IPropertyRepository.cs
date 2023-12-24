using System.Threading.Tasks;
using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface IPropertyRepository
    {
        Task<IEnumerable<Property>> GetPropertiesAsync(int sellRent);
        Task<Property> GetPropertyDetailAsync(int id);
        Task<Property> GetPropertyIdAsync(int id);

        void AddProperty(Property property);
        void DeleteProperty(int id);
    }
}