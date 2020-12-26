namespace Catstagram.Server.Features.Follows
{
    using Catstagram.Server.Infrastructure.Services;
    using System.Threading.Tasks;

    public interface IFollowService
    {
        Task<Result> Follow(string userId, string followerId);

        Task<bool> IsFollower(string userId, string followerId);
    }
}
