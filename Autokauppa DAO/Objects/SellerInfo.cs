using System.ComponentModel.DataAnnotations;

namespace Autokauppa_DAO.Objects
{
    public class SellerInfo
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Email { get; set; }

        [MaxLength(20)]
        public string? PhoneNumber { get; set; }
    }
}
