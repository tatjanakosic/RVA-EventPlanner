using Server.RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Server.Services
{
    public class EventServiceDI
    {

        private readonly IUnitOfWork _unitOfWork;

        public EventServiceDI(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Event>> GetAllEntitiesAsync()
        {
            return await _unitOfWork.Repository<Event>().GetAllAsync();
        }

        public async Task<Event> GetEntityByIdAsync(int id)
        {
            return await _unitOfWork.Repository<Event>().GetByIdAsync(id);
        }

        public async Task AddEntityAsync(Event entity)
        {
            await _unitOfWork.Repository<Event>().AddAsync(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateEntityAsync(Event entity)
        {
            await _unitOfWork.Repository<Event>().UpdateAsync(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteEntityAsync(Event entity)
        {
            await _unitOfWork.Repository<Event>().DeleteAsync(entity);
            await _unitOfWork.CompleteAsync();
        }
    }
}
