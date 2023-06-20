using System.ComponentModel.DataAnnotations;

namespace Elkadeem.TicketManagement.Presentation.ViewModels
{
    public class CreateCategoryViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
    }
}
