namespace WebAPI.Interfaces
{
    public interface IUnitOfWork
    {
         ICityRepository CityRepository {get;}  
         IUserRepository UserRepository {get;}
         IPropertyRepository propertyRepository {get;}
         Task<bool> SaveAsync();
    }
}