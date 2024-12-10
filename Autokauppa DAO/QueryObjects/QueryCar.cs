using System.ComponentModel.DataAnnotations;

namespace Autokauppa_DAO.QueryObjects
{
    public class QueryCar
    {
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

        [MaxLength(500)]
        public required QuerySellerInfo SellerInfo { get; set; }
    }
}
