using System.ComponentModel.DataAnnotations;

namespace ZPharmacy.Identity.DTOS
{
    public class ReigsterUserDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
