using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server.Interfaces
{
    [ServiceContract]
  public interface IEventService
   {

        [OperationContract]
        string GetData();

        [OperationContract]
        List<Event> GetEvents();

        [OperationContract]
        void AddEvent(Event newEvent);

        [OperationContract]
        void UpdateEvent(Event updatedEvent);

        [OperationContract]
        void DeleteEvent(int eventId);
    }
}
