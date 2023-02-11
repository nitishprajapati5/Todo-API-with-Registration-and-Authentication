using APIServices.Interfaces;
using APIServices.Models;
using APIServices.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static APIServices.Models.Request.DataRequest;

namespace APIServices.Services
{
    public class StaticService
    {
        public readonly IDataService _dataService;
        public readonly IRegistrationServices _registrationService;

        public StaticService(IDataService dataService, IRegistrationServices registrationService)
        {
            _dataService = dataService;
            _registrationService = registrationService;
        }

        public async Task<int?> ExecuteNonQuery<T>(T obj)
        {
            try
            {
                if(obj.GetType() == typeof(SPBase))
                {
                    //SP call without param
                    return await _dataService.ExecuteNonQueryBySPName((obj as SPBase).Procedure);
                }
                else
                {

                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> ExecuteScalar<T>(string Spname,T obj)
        {
            //string procedureName = GetProcedureName(obj);

            try
            {
                if(Spname == ProcedureConstants.GetRegistrationDetails)
                {
                    return _registrationService.GetRegistrationDetails<T>(Spname, obj as Registration);
                }

                return null;

            }
            
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<List<T>> ExecuteSP<T, Y>(string Spname, Y obj)
        {
            try
            {
                //string procedureName = GetProcedureName(obj);

                //if (obj.GetType() == typeof(SPBase))
                //{
                //    //SP call without param
                //    return await _dataService.GetAllBySPName<T>((obj as SPBase).Procedure);
                //}
                //else
                //{
                //    return null;
                //}
                if (Spname == ProcedureConstants.GetRegistrationDetails)
                {
                    return await _registrationService.GetRegistrationDetails<T>(Spname, obj as Registration);
                }
                return null;
            }
            catch (Exception)
            {

            }

            return null;
        }

        public T ExecuteProc<T,Y>(Y obj)
        {
            try
            {
                //string procedureName = GetProcedureName(obj);

                //return null;
            }
            catch (Exception)
            {
                throw;
            }
            return default(T);
        }

        public async Task Create<T>(T obj)where T : class
        {
            try
            {
                await _dataService.Create<T>(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Update<T>(T obj)where T : class
        {
            try
            {
                await _dataService.Update<T>(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public APIServices.GenericRepository.GenericRepository<T> ServiceRepository<T>()where T : class
        {
            try
            {
                return _dataService.ServiceRepository<T>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //private string GetProcedureName<T>(T obj)
        //{
        //    try
        //    {
        //        System.Reflection.PropertyInfo propertyInfo = obj.GetType().GetProperty(nameof(SPBase.Procedure));
        //        return propertyInfo.GetValue(obj, null).IsNullString();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

    }
}
