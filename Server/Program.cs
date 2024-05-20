﻿using Common.Interfaces;
using Server.Interfaces;
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

           string baseAddress = "net.tcp://localhost:4000/ServiceImpl";
           // Uri baseAddress = new Uri("net.tcp://localhost:4000/EventService");

            using (ServiceHost host = new ServiceHost(typeof(ServiceImpl)))
            {

                host.AddServiceEndpoint(typeof(IService), new NetTcpBinding(), baseAddress);

               // Enable metadata exchange
               // ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
               // smb.HttpGetEnabled = false;
               // smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
               // host.Description.Behaviors.Add(smb);
               // host.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexTcpBinding(), "mex");

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
        }
    }
}
