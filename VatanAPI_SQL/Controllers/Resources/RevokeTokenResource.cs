using System.ComponentModel.DataAnnotations;

namespace VatanAPI.Controllers.Resources
{
    public class RevokeTokenResource
    {
        [Required]
        public string Token { get; set; }
    }
}