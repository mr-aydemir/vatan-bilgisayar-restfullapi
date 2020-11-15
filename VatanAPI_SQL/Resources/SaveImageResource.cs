using System.ComponentModel.DataAnnotations;

namespace VatanAPI.Resources
{
    public class SaveImageResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Url { get; set; }
        public int ProductId { get; set; }
    }
}
