
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server.Services
{
  // [ServiceBehavior]
  //public  class EventService : IEventService
  //  {

  //      private EventsEntities db = new EventsEntities();

  //      public List<Event> GetEvents()
  //      {
  //          return db.Events.ToList();
  //      }

  //      public void AddEvent(Event newEvent)
  //      {
  //          db.Events.Add(newEvent);
  //          db.SaveChanges();
  //      }

  //      public void UpdateEvent(Event updatedEvent)
  //      {
  //          db.Entry(updatedEvent).State = System.Data.Entity.EntityState.Modified;
  //          db.SaveChanges();
  //      }

  //      public void DeleteEvent(int eventId)
  //      {
  //          var eventToDelete = db.Events.Find(eventId);
  //          if (eventToDelete != null)
  //          {
  //              db.Events.Remove(eventToDelete);
  //              db.SaveChanges();
  //          }
  //      }

  //      public string GetData()
  //      {
  //          string data = "We are connected!";
  //          return data;
  //      }
  //  }
}
