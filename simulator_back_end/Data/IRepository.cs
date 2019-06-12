using System.Threading.Tasks;
using simulator_back_end.Models;

namespace simulator_back_end.Data
{
    public interface IRepository
    {
         void Add<T>(T entity) where T: class;

         void Update<T>(T entity) where T: class;

         void Delete<T>(T entity) where T: class;

         Task<bool> SaveChangesAsync();

         Task<Usuario> GetUserAsync(string email, string pass);

         Task<Simulacao[]> GetSimulationsByUserIdAsync(int simId);

         Task<Simulacao> GetSimulationByIdAsync(int simId);

        //GetAllSimulationsAsync

        //GetSimulationAsync
    }
}