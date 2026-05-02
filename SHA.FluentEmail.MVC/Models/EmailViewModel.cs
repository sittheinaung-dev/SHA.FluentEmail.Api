using System.ComponentModel.DataAnnotations;

namespace SHA.FluentEmail.MVC.Models
{
    public class EmailViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "To Email")]
        public string ToEmail { get; set; } = string.Empty;

        [Required]
        public string Subject { get; set; } = string.Empty;

        [Required]
        public string Body { get; set; } = string.Empty;
    }
}
