namespace Catstagram.Server.Features.Cats
{
    using Catstagram.Server.Data;
    using Catstagram.Server.Data.Models;
    using Catstagram.Server.Features.Cats.Models;
    using Catstagram.Server.Infrastructure.Services;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CatService : ICatService
    {
        private readonly CatstagramDbContext data;

        public CatService(CatstagramDbContext data)
            => this.data = data;

        public async Task<int> Create(string ImageUrl, string description, string userId)
        {
            var cat = new Cat
            {
                Description = description,
                ImageUrl = ImageUrl,
                UserId = userId
            };

            this.data.Add(cat);
            await this.data.SaveChangesAsync();

            return cat.Id;
        }

        public async Task<Result> Update(int id, string description, string userId)
        {
            var cat = await this.GetByIdAndByUserId(id, userId);
            if (cat == null)
            {
                return "This user cannot edit this cat.";
            }

            cat.Description = description;
            await this.data.SaveChangesAsync();

            return true;
        }

        public async Task<Result> Delete(int id, string userId)
        {
            var cat = await this.GetByIdAndByUserId(id, userId);
            if (cat == null)
            {
                return "This user cannot delete this cat.";
            }

            this.data.Remove(cat);
            await this.data.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<CatListingServiceModel>> ByUser(string userId)
            => await this.data
                    .Cats
                    .Where(c => c.UserId == userId)
                    .OrderByDescending(c => c.CreatedOn)
                    .Select(c => new CatListingServiceModel
                    {
                        Id = c.Id,
                        ImageUrl = c.ImageUrl,
                    })
                    .ToListAsync();

        public async Task<CatDetailsServiceModel> Details(int id)
            => await this.data
                    .Cats
                    .Where(c => c.Id == id)
                    .Select(c => new CatDetailsServiceModel
                    {
                        Id = c.Id,
                        ImageUrl = c.ImageUrl,
                        Description = c.Description,
                        UserId = c.UserId,
                        UserName = c.User.UserName,
                    })
                    .FirstOrDefaultAsync();

        private async Task<Cat> GetByIdAndByUserId(int id, string userId) 
            => await this.data
                .Cats
                .Where(c => c.Id == id && c.UserId == userId)
                .FirstOrDefaultAsync();
    }
}
