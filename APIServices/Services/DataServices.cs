using APIServices.GenericRepository;
using APIServices.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices.Services
{
    public partial class DataServices : IDataService
    {
        private readonly UnitOfWork _unitOfWork;

        public DataServices(IConfiguration configuration, UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<T>> GetAllBySPName<T>(string spName)
        {
            try
            {
                return await _unitOfWork.ExecuteSP<T>(spName, null);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> ExecuteNonQueryBySPName(string spName)
        {
            try
            {
                return await _unitOfWork.ExcuteNonQueryAsync(spName, null);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Create<T>(T obj) where T : class
        {
            try
            {
                await _unitOfWork.Repository<T>().Create(obj);
                await _unitOfWork.Save();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Update<T>(T obj) where T : class
        {
            try
            {
                await _unitOfWork.Repository<T>().Update(obj);
                await _unitOfWork.Save();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public GenericRepository<T> ServiceRepository<T>() where T : class
        {
            try
            {
                return _unitOfWork.Repository<T>();
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
