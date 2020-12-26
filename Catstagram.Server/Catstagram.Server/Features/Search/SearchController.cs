namespace Catstagram.Server.Features.Search
{
    using Catstagram.Server.Features.Search.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class SearchController : ApiContoller
    {
        private readonly ISearchService search;

        public SearchController(ISearchService search) 
            => this.search = search;

        [AllowAnonymous]
        [HttpGet]
        [Route(nameof(Profiles))]
        public async Task<IEnumerable<ProfileSearchServiceModel>> Profiles(string query)
            => await this.search.Profiles(query);
    }
}
