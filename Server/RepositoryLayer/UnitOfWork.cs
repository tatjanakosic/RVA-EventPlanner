using Server.DBCRUD;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.RepositoryLayer
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DbContext _context;
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();


        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public IRepository<T> Repository<T>() where T : class
        {
            if (!_repositories.ContainsKey(typeof(T)))
            {
                _repositories[typeof(T)] = new Repository<T>(_context);
            }

            return (IRepository<T>)_repositories[typeof(T)];
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
