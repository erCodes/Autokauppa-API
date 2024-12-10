using System.ComponentModel.DataAnnotations;

namespace Autokauppa_DAO.QueryObjects
{
    public class QuerySellerInfo
    {
        [MaxLength(50)]
        public required string Name { get; set; }

        [MaxLength(50)]
        public required string Email { get; set; }

        [MaxLength(20)]
        public string? PhoneNumber { get; set; }
    }
}
