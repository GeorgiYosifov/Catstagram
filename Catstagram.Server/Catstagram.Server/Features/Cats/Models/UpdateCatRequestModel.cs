namespace Catstagram.Server.Features.Cats.Models
{
    using static Data.Validation.Cat;
    using System.ComponentModel.DataAnnotations;

    public class UpdateCatRequestModel
    { 
        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }
    }
}
