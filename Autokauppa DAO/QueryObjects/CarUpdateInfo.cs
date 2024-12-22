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
        [MaxLength(50)]
        public required string CarId { get; set; }

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
