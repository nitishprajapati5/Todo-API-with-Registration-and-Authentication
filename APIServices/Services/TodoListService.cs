using APIServices.Interfaces;
using APIServices.Models.Request;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices.Services
{
    public class TodoListService : ITodoList
    {
        private readonly UnitOfWork _unitofWork;
        public TodoListService(UnitOfWork unitOfWork) { _unitofWork = unitOfWork; }
        public Task<List<T>> PostList<T>(string spName, TodoList param)
        {
            try
            {
                if (param != null)
                {
                    List<SqlParameter> parameters = new List<SqlParameter>
                    {
                        new SqlParameter(){ParameterName = "userId",SqlDbType=SqlDbType.BigInt,Value = param.userId},
                        new SqlParameter(){ParameterName = "Title",SqlDbType=SqlDbType.NVarChar,Value = param.Title},
                        new SqlParameter(){ParameterName = "Description",SqlDbType=SqlDbType.NVarChar,Value = param.Description},
                        new SqlParameter(){ParameterName = "ExpiresAt",SqlDbType=SqlDbType.DateTime,Value = param.ExpiresAt},
                        new SqlParameter(){ParameterName = "Type", SqlDbType = SqlDbType.NVarChar, Value = param.Type },
                        new SqlParameter(){ParameterName = "Tags", SqlDbType = SqlDbType.NVarChar, Value = param.Tag },
                        new SqlParameter(){ParameterName = "Priority",SqlDbType=SqlDbType.NVarChar,Value = param.Priority}
                };

                    return _unitofWork.ExecuteSP<T>(spName, parameters);
                }
            }
            catch
            {

            }

            return null;
        }
    }
}
