using Common.Classes;
using Database.RepositoryLayer;
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

        public void AddNewEntity(Event entity)
        {
            var repository = _unitOfWork.Repository<Event>();
            repository.Add(entity);
            _unitOfWork.Commit();
        }

        public IEnumerable<Event> GetAllEntities()
        {
            var repository = _unitOfWork.Repository<Event>();
            return repository.GetAll();
        }

        public Event GetEntityById(int id)
        {
            var repository = _unitOfWork.Repository<Event>();
            return repository.GetById(id);
        }

        public void UpdateEntity(Event entity)
        {
            var repository = _unitOfWork.Repository<Event>();
            repository.Update(entity);
            _unitOfWork.Commit();
        }

        public void DeleteEntity(Event entity)
        {
            var repository = _unitOfWork.Repository<Event>();
            repository.Delete(entity);
            _unitOfWork.Commit();
        }

    }
}
