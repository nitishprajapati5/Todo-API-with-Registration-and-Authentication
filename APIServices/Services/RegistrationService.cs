using APIServices.Interfaces;
using APIServices.Models;
using APIServices.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Models;

namespace APIServices.Services
{
    public partial class RegistrationService: IRegistrationServices
    {
        private readonly UnitOfWork _unitOfWork;

        public RegistrationService(UnitOfWork unitOfWork,IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<T>> GetRegistrationDetails<T>(string Spname,Registration registrationParam)
        {
            try
            {
                if (registrationParam != null)
                {
                    List<SqlParameter> parameters = new List<SqlParameter>
                    {
                        new SqlParameter(){ParameterName = "Registration",SqlDbType=SqlDbType.UniqueIdentifier,Value=new System.Data.SqlTypes.SqlGuid(registrationParam.RegistrationUniqueId)},
                        new SqlParameter(){ ParameterName = "Name",SqlDbType=SqlDbType.NVarChar,Value=registrationParam.Name},
                        new SqlParameter(){ParameterName="Email",SqlDbType=SqlDbType.NVarChar,Value=registrationParam.Email},
                        new SqlParameter(){ParameterName="Gender",SqlDbType=SqlDbType.NVarChar,Value=registrationParam.Gender},
                        new SqlParameter(){ParameterName="DateofBirth",SqlDbType=SqlDbType.NVarChar,Value=registrationParam.DateofBirth},
                        new SqlParameter(){ParameterName="Password",SqlDbType=SqlDbType.NVarChar,Value=registrationParam.Password},
                        new SqlParameter(){ParameterName="ConfirmPassword",SqlDbType=SqlDbType.NVarChar,Value=registrationParam.ConfirmPassword},
                        new SqlParameter(){ParameterName="IsDeleted",SqlDbType=SqlDbType.Bit,Value=registrationParam.IsDeleted},
                        new SqlParameter(){ParameterName="Username",SqlDbType=SqlDbType.NVarChar,Value=registrationParam.Username},
                        new SqlParameter(){ParameterName="Lastname",SqlDbType= SqlDbType.NVarChar,Value=registrationParam.Lastname}

                    };

                    var res = await _unitOfWork.ExecuteSP<T>(ProcedureConstants.GetRegistrationDetails, parameters);
                    return res;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
