namespace Catstagram.Server.Features.Follows
{
    using Catstagram.Server.Features.Follows.Models;
    using Catstagram.Server.Infrastructure.Services;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class FollowsController : ApiContoller
    {
        private readonly IFollowService follows;
        private readonly ICurrentUserService currentUser;

        public FollowsController(
            IFollowService follows,
            ICurrentUserService currentUser)
        {
            this.currentUser = currentUser;
            this.follows = follows;
        }

        [HttpPost]
        public async Task<ActionResult> Follow(FollowRequestModel model)
        {
            var result = await this.follows.Follow(
                model.UserId,
                this.currentUser.GetId());

            if (result.Failure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }
    }
}
