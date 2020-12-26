namespace Catstagram.Server.Features.Profiles
{
    using Catstagram.Server.Data.Models;
    using Catstagram.Server.Features.Profiles.Models;
    using Catstagram.Server.Infrastructure.Services;
    using System.Threading.Tasks;

    public interface IProfileService
    {
        Task<ProfileServiceModel> ByUser(string userId, bool allInformation = false);

        Task<Result> Update(
            string userId,
            string email,
            string userName,
            string name,
            string mainPhotoUrl,
            string webSite,
            string biography,
            Gender gender,
            bool isPrivate);

        Task<bool> IsPublic(string userId);
    }
}
