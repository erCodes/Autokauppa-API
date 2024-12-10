using static Autokauppa_DAO.Methods;
using Autokauppa_DAO.QueryObjects;
using System.ComponentModel.DataAnnotations;

namespace Autokauppa_DAO.Objects
{
    public class Car
    {
        public Car()
        {
            SafetyFeatures ??= [];
            OtherFeatures ??= [];
        }

        public Car(QueryCar queryCar, SellerInfo? existingSellerInfo = null)
        {
            Id = new Guid().ToString();
            Brand = queryCar.Brand;
            Model = queryCar.Model;
            ProductionYear = queryCar.ProductionYear;
            EngineSize = queryCar.EngineSize;
            FuelType = queryCar.FuelType;
            Transmission = queryCar.Transmission;
            SafetyFeatures = [];
            OtherFeatures = [];

            foreach (var safetyF in queryCar.SafetyFeatures)
            {
                if (safetyF.IsWhitespace())
                {
                    continue;
                }
                SafetyFeatures.Add(new SafetyFeature(safetyF));
            }
            if (!queryCar.OtherFeatures.Empty())
            {
                foreach (var otherF in queryCar.OtherFeatures)
                {
                    if (otherF.IsWhitespace())
                    {
                        continue;
                    }
                    OtherFeatures.Add(new OtherFeature(otherF));
                }
            }

            if (existingSellerInfo != null)
            {
                if (existingSellerInfo.PhoneNumber.IsWhitespace() && !queryCar.SellerInfo.PhoneNumber.IsWhitespace())
                {
                    existingSellerInfo.PhoneNumber = queryCar.SellerInfo.PhoneNumber;
                }
                SellerInfo = existingSellerInfo;
            }
            else
            {
                SellerInfo = new SellerInfo()
                {
                    Id = new Guid().ToString(),
                    Name = queryCar.SellerInfo.Name,
                    Email = queryCar.SellerInfo.Email,
                    PhoneNumber = queryCar.SellerInfo.PhoneNumber,
                };
            }
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Brand { get; set; }

        [Required]
        [MaxLength(40)]
        public string Model { get; set; }

        [Required]
        [MaxLength(4)]
        public string ProductionYear { get; set; }

        [Required]
        [MaxLength(5)]
        public string EngineSize { get; set; }

        [Required]
        [MaxLength(20)]
        public string FuelType { get; set; }

        [Required]
        [MaxLength(20)]
        public string Transmission { get; set; }

        [Required]
        [MaxLength(500)]
        public List<SafetyFeature> SafetyFeatures { get; set; }

        [MaxLength(500)]
        public List<OtherFeature> OtherFeatures { get; set; }

        [Required]
        [MaxLength(500)]
        public SellerInfo SellerInfo { get; set; }

        [Required]
        public DateTime ListedOn { get; set; }
    }
}
