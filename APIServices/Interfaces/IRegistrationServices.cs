using APIServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Models;

namespace APIServices.Interfaces
{
    public partial interface IRegistrationServices
    {
        Task<List<T>> GetRegistrationDetails<T>(string spName, Registration registrationParam);
    }
}
