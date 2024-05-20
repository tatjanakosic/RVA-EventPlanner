using Server.DBCRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.RepositoryLayer
{
    //IUnitOfWork defines methods for committing and rolling back transactions
    //Repositories interact with the UnitOfWork to ensure all operations are part of a single transaction
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
        void Commit();
        void RollBack();
    }
}
