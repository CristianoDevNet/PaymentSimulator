using System.Threading.Tasks;

namespace simulator_back_end.Data
{
    public interface IRepository
    {
         void Add<T>(T entity) where T: class;

         void Update<T>(T entity) where T: class;

         void Delete<T>(T entity) where T: class;

         Task<bool> SaveChangesAsync();

         Task<object> GetUserAsync(string email, string pass);

         Task<object[]> GetSimulationsByUserIdAsync(int simId);

         Task<object> GetSimulationByIdAsync(int simId);

        //GetAllSimulationsAsync

        //GetSimulationAsync
    }
}