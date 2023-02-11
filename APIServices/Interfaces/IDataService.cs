using APIServices.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices.Interfaces
{
    public partial interface IDataService
    {
        //Task<string> GetStatusMessageByStatusCodeLanguage(StatusMessageParam request);
        Task<List<T>> GetAllBySPName<T>(string spName);
        Task<int> ExecuteNonQueryBySPName(string spName);
        Task Create<T>(T obj) where T : class;
        Task Update<T>(T obj) where T : class;
        GenericRepository<T> ServiceRepository<T>() where T : class;
    }
}
