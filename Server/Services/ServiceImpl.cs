using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Services
{
    public class ServiceImpl : IService
    {
        public string GetData()
        {
            return "We are connected!";
        }

        /*
         * private EventsEntities db = new EventsEntities();

        public List<Event> GetEvents()
        {
            return db.Events.ToList();
        }

        public void AddEvent(Event newEvent)
        {
            db.Events.Add(newEvent);
            db.SaveChanges();
        }

        public void UpdateEvent(Event updatedEvent)
        {
            db.Entry(updatedEvent).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteEvent(int eventId)
        {
            var eventToDelete = db.Events.Find(eventId);
            if (eventToDelete != null)
            {
                db.Events.Remove(eventToDelete);
                db.SaveChanges();
            }
        }

        
         */
    }
}
