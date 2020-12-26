namespace Catstagram.Server.Features.Search
{
    using Catstagram.Server.Features.Search.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISearchService
    {
        Task<IEnumerable<ProfileSearchServiceModel>> Profiles(string query);
    }
}
