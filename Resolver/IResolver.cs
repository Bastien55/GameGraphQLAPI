using GameGraphQLAPI.Interface;

namespace GameGraphQLAPI.Resolver
{
    public interface IResolver<T>
    {
        Task<List<T>> GetAll();

        Task<T> GetByID(int id);
    }
}
