using System.Collections.Generic;
using System.Threading.Tasks;
using Harness_WPF.Repositories;

namespace Harness_WPF.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IRepository _repository;

        public Service(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<T>> GetDataAsync()
        {
            return await _repository.GetAllAsync<T>();
        }
    }
}