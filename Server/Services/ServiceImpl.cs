using Common.ServiceContracts;
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

    }
}
