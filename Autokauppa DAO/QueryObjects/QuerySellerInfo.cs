using System.ComponentModel.DataAnnotations;

namespace Autokauppa_DAO.QueryObjects
{
    public class QuerySellerInfo
    {
        [MaxLength(50)]
        public required string Name { get; set; }

        [MaxLength(50)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
