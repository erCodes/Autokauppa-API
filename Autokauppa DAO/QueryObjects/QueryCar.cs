using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Autokauppa_DAO.QueryObjects
{
    [method: SetsRequiredMembers]
    public class QueryCar(string sellerId, string brand, string model, string productionYear, string engineSize, string fuelType, string transmission, List<string> safetyFeatures, List<string> otherFeatures)
    {
        [MaxLength(50)]
        public required string SellerId { get; set; } = sellerId;

        [MaxLength(40)]
        public required string Brand { get; set; } = brand;

        [MaxLength(40)]
        public required string Model { get; set; } = model;

        [MaxLength(4)]
        public required string ProductionYear { get; set; } = productionYear;

        [MaxLength(5)]
        public required string EngineSize { get; set; } = engineSize;

        [MaxLength(20)]
        public required string FuelType { get; set; } = fuelType;

        [MaxLength(20)]
        public required string Transmission { get; set; } = transmission;

        [MaxLength(500)]
        public required List<string> SafetyFeatures { get; set; } = safetyFeatures;

        [MaxLength(500)]
        public List<string> OtherFeatures { get; set; } = otherFeatures;
    }
}
