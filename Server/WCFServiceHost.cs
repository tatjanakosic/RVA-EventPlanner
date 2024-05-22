using Common.ServiceContracts.EventContracts;
using Common.ServiceContracts.UserContracts;
using Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
   public class WCFServiceHost
    {
        private static ServiceHost UserServiceHost;

        private static ServiceHost EventServiceHost;

        public WCFServiceHost()
        {
            NetTcpBinding binding = new NetTcpBinding();
            binding.Security.Mode = SecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;

            UserServiceHost = new ServiceHost(typeof(UserService));
            UserServiceHost.AddServiceEndpoint(typeof(IUserService), binding, new Uri("net.tcp://localhost:4000/IUserService")); 


            EventServiceHost = new ServiceHost(typeof(EventServiceDI));
            UserServiceHost.AddServiceEndpoint(typeof(IEventService), binding, new Uri("net.tcp://localhost:4000/IEventService"));

        }
            public void Open()
            {
                UserServiceHost.Open();
                EventServiceHost.Open();
                Console.WriteLine("Service hosts are opened at " + DateTime.Now);

            }

            public void Close()
            {
                UserServiceHost.Close();
                EventServiceHost.Close();
                Console.WriteLine("Service hosts are closed at " + DateTime.Now);
            }
    }
}
