namespace Catstagram.Server.Features.Search
{
    using Catstagram.Server.Data;
    using Catstagram.Server.Features.Search.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class SearchService : ISearchService
    {
        private readonly CatstagramDbContext data;

        public SearchService(CatstagramDbContext data)
            => this.data = data;

        public async Task<IEnumerable<ProfileSearchServiceModel>> Profiles(string query) 
            => await this.data
                .Users
                .Where(u => u.UserName.ToLower().Contains(query.ToLower()) ||
                    u.Profile.Name.ToLower().Contains(query.ToLower()))
                .Select(u => new ProfileSearchServiceModel
                {
                    UserId = u.Id,
                    UserName = u.UserName,
                    ProfilePhotoUrl = u.Profile.MainPhotoUrl
                })
                .ToListAsync();
    }
}
