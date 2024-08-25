using Harness_WPF.Domain.Entities;
using Harness_WPF.Repositories;

namespace Harness_WPF.Services;

public interface IService<T> where T : class
{
    Task<List<T>> GetDataAsync();
}
