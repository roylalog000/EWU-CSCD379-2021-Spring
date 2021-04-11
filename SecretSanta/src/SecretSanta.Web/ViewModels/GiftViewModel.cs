using System.ComponentModel.DataAnnotations;

namespace SecretSanta.Web.ViewModels
{
    public class GiftViewModel
    {

        public int Id { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; } = "";

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; } = "";

        [Display(Name = "URL")]
        public string URL { get; set; } = "";

        [Required]
        [Display(Name = "Priority")]
        public int Priority { get; set; }
        
        [Required]
        [Display(Name = "User")]
        public int UserID { get; set; }
    }
}