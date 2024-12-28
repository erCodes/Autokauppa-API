using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autokauppa_DAO.QueryObjects
{
    public class CarUpdateInfo
    {
        public CarUpdateInfo()
        {
        }

        public CarUpdateInfo(string? brand, string? model, string? productionYear, string? engineSize, string? fuelType, string? transmission, List<string> safetyFeatures, List<string> otherFeatures)
        {
            Brand = brand;
            Model = model;
            ProductionYear = productionYear;
            EngineSize = engineSize;
            FuelType = fuelType;
            Transmission = transmission;
            SafetyFeatures = safetyFeatures;
            OtherFeatures = otherFeatures;
        }

        [MaxLength(40)]
        public string? Brand { get; set; }

        [MaxLength(40)]
        public string? Model { get; set; }

        [MaxLength(4)]
        public string? ProductionYear { get; set; }

        [MaxLength(5)]
        public string? EngineSize { get; set; }

        [MaxLength(20)]
        public string? FuelType { get; set; }

        [MaxLength(20)]
        public string? Transmission { get; set; }

        [MaxLength(500)]
        public List<string> SafetyFeatures { get; set; } = [];

        [MaxLength(500)]
        public List<string> OtherFeatures { get; set; } = [];
    }
}
