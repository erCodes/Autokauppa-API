using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Autokauppa_DAO.QueryObjects
{
    [method: SetsRequiredMembers]
    public class QuerySellerInfo(string name, string? email = null, string? phoneNumber = null)
    {
        [MaxLength(50)]
        public required string Name { get; set; } = name;

        [MaxLength(50)]
        public string Email { get; set; } = email ?? string.Empty;

        [MaxLength(20)]
        public string PhoneNumber { get; set; } = phoneNumber ?? string.Empty;
    }
}
