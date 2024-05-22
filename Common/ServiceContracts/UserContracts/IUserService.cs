using Common.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common.ServiceContracts.UserContracts
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        User GetUserById(int id);
    }
}
