using Autokauppa_DAO.QueryObjects;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Autokauppa_DAO.Objects
{
    public class SellerInfo
    {
        public SellerInfo()
        {
        }

        [SetsRequiredMembers]
        public SellerInfo(QuerySellerInfo querySeller)
        {
            Id = Guid.NewGuid().ToString();
            Name = querySeller.Name;
            Email = querySeller.Email;
            PhoneNumber = querySeller.PhoneNumber;
            SoldCars = [];
        }

        [SetsRequiredMembers]
        public SellerInfo(SellerInfo current, QuerySellerInfo update)
        {
            Id = current.Id;
            Name = update.Name;
            Email = update.Email;
            PhoneNumber = update.PhoneNumber;
            SoldCars = current.SoldCars;
        }

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

        public List<Car> SoldCars { get; set; }
    }
}
