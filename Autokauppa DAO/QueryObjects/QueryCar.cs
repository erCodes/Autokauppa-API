using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Autokauppa_DAO.QueryObjects
{
    public class QueryCar
    {
        [SetsRequiredMembers]
        public QueryCar(string sellerId, string brand, string model, string productionYear, string engineSize, string fuelType, string transmission, List<string> safetyFeatures, List<string> otherFeatures)
        {
            SellerId = sellerId;
            Brand = brand;
            Model = model;
            ProductionYear = productionYear;
            EngineSize = engineSize;
            FuelType = fuelType;
            Transmission = transmission;
            SafetyFeatures = safetyFeatures;
            OtherFeatures = otherFeatures;
        }

        [MaxLength(50)]
        public required string SellerId { get; set; }

        [MaxLength(40)]
        public required string Brand { get; set; }

        [MaxLength(40)]
        public required string Model { get; set; }

        [MaxLength(4)]
        public required string ProductionYear { get; set; }

        [MaxLength(5)]
        public required string EngineSize { get; set; }

        [MaxLength(20)]
        public required string FuelType { get; set; }

        [MaxLength(20)]
        public required string Transmission { get; set; }

        [MaxLength(500)]
        public required List<string> SafetyFeatures { get; set; }

        [MaxLength(500)]
        public List<string> OtherFeatures { get; set; } = [];
    }
}
