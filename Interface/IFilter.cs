using GameGraphQLAPI.Models;

namespace GameGraphQLAPI.Interface
{
    public interface IFilter<T>
    {
        T GetListFiltered(FilterElement filter);
    }
}
