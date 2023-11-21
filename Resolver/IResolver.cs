using GameGraphQLAPI.Interface;

namespace GameGraphQLAPI.Resolver
{
    public interface IResolver<T>
    {
        /// <summary>
        /// For getting the list of entities
        /// </summary>
        /// <returns>List of entities of type T</returns>
        Task<List<T>> GetAll();

        /// <summary>
        /// For getting only one entity from the database identifying by the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>An instance of T</returns>
        Task<T> GetByID(int id);
    }
}
