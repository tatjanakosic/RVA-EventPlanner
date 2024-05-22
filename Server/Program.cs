using Common.ServiceContracts;

using Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zivi smo, da vidimo sta se radi ovde :)");

            #region Stari kod
            string baseAddress = "net.tcp://localhost:4000/ServiceImpl";
           // Uri baseAddress = new Uri("net.tcp://localhost:4000/EventService");

            using (ServiceHost host = new ServiceHost(typeof(ServiceImpl)))
            {

                host.AddServiceEndpoint(typeof(IService), new NetTcpBinding(), baseAddress);

             

                try
                {
                    host.Open();
                    Console.WriteLine("The service is running");
                    Console.WriteLine("Press any key to terminate the service.");
                    Console.ReadKey();

                }
                 catch(CommunicationException ce)
                {
                    Console.WriteLine("An exception occurred: {0}", ce.Message);
                    host.Close();
                }

            }

            #endregion

            #region novi 

           // WCFServiceHost services = new WCFServiceHost();

            //services.Open();

            //Console.ReadKey();

            //services.Close();

            #endregion
        }
    }
}
