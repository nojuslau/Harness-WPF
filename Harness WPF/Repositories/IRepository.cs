namespace Harness_WPF.Repositories;
public interface IRepository
{
    Task<List<T>> GetAllAsync<T>() where T : class;
}
