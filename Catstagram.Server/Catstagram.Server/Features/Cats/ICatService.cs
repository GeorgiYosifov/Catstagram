namespace Catstagram.Server.Features.Cats
{
    using Catstagram.Server.Features.Cats.Models;
    using Catstagram.Server.Infrastructure.Services;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICatService
    {
        Task<int> Create(string ImageUrl, string description, string userId);

        Task<Result> Update(int id, string description, string userId);

        Task<Result> Delete(int id, string userId);

        Task<IEnumerable<CatListingServiceModel>> ByUser(string userId);

        Task<CatDetailsServiceModel> Details(int id);
    }
}
