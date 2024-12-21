using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Autokauppa_DAO.Objects
{
    [method: SetsRequiredMembers]
    public class SafetyFeature(string name)
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [MaxLength(50)]
        [Required]
        public required string Name { get; set; } = name;
    }
}
