using System.ComponentModel.DataAnnotations;

namespace Autokauppa_DAO.Objects
{
    public class OtherFeature(string name)
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = name;
    }
}
