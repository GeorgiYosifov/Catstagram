namespace Catstagram.Server.Features.Cats.Models
{
    using static Data.Validation.Cat;
    using System.ComponentModel.DataAnnotations;

    public class CreateCatRequestModel
    {
        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }
    }
}
