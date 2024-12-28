using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Autokauppa_DAO.QueryObjects
{
    public class QuerySellerInfo
    {
        public QuerySellerInfo()
        {
        }

        [SetsRequiredMembers]
        public QuerySellerInfo(string name, string? email = null, string? phoneNumber = null)
        {
            Name = name;
            Email = email ?? string.Empty;
            PhoneNumber = phoneNumber ?? string.Empty;
        }

        [MaxLength(50)]
        public required string Name { get; set; }

        [MaxLength(50)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
