using APIServices.Models;
using APIServices.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices.Interfaces
{
    public interface ITodoList
    {
        Task<List<T>> PostList<T>(string spName, TodoList param);
    }
}
