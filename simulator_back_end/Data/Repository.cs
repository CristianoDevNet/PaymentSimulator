using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using simulator_back_end.Models;

namespace simulator_back_end.Data
{
    public class Repository : IRepository
    {
        public DataContext _context { get; }
        
        public Repository(DataContext context)
        {
            _context = context;

        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }        

        public async Task<SimDet[]> GetSimulationByIdAsync(int simId)
        {
            IQueryable<SimDet> query = _context.SimDets;

            query = query.AsNoTracking();

            return await query.Where(s => s.SimCabId == simId).ToArrayAsync();
        }

        public async Task<Usuario> GetUserAsync(string email, string pass)
        {
            IQueryable<Usuario> query = _context.Usuarios;

            query = query.AsNoTracking();

            return await query.Where(u => u.Email == email && u.Senha == pass).FirstOrDefaultAsync();
        }
    }
}