using GameGraphQLAPI.Models;

namespace GameGraphQLAPI.Interface
{
    public interface IFilter<T>
    {
        /// <summary>
        /// Method used to filter a list depending on a Filter Element
        /// </summary>
        /// <param name="filter">The instance of a filter that contains data which will filter a list of object</param>
        /// <returns>An object that contain a list filtered</returns>
        T GetListFiltered(FilterElement filter);
    }
}
