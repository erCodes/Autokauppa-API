using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Autokauppa_DAO.Objects
{
    public class SafetyFeature
    {
        [SetsRequiredMembers]
        public SafetyFeature(string name)
        {
            Id = new Guid().ToString();
            Name = name;
        }

        [Key]
        public string Id { get; set; }

        [MaxLength(50)]
        [Required]
        public required string Name { get; set; }
    }
}
