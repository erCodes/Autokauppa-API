using static Autokauppa_DAO.Methods;
using Autokauppa_DAO.QueryObjects;
using System.ComponentModel.DataAnnotations;

namespace Autokauppa_DAO.Objects
{
    public class Car
    {
        // Muuta ListedOn UpdatedON
        public Car()
        {
            SafetyFeatures ??= [];
            OtherFeatures ??= [];
        }

        public Car(QueryCar queryCar)
        {
            Id = Guid.NewGuid().ToString();
            SellerId = queryCar.SellerId;
            Brand = queryCar.Brand;
            Model = queryCar.Model;
            ProductionYear = queryCar.ProductionYear;
            EngineSize = queryCar.EngineSize;
            FuelType = queryCar.FuelType;
            Transmission = queryCar.Transmission;
            SafetyFeatures = CheckLists(queryCar.SafetyFeatures);
            OtherFeatures = CheckLists(queryCar.OtherFeatures);
            ListedOn = DateTime.Now;
        }

        public Car(Car current, CarUpdateInfo update)
        {
            Id = current.Id;
            SellerId = current.SellerId;
            Brand = update.Brand ??= string.Empty;
            Model = update.Model ??= string.Empty;
            ProductionYear = update.ProductionYear ??= string.Empty;
            EngineSize = update.EngineSize ??= string.Empty;
            FuelType = update.FuelType ??= string.Empty;
            Transmission = update.Transmission ??= string.Empty;
            SafetyFeatures = CheckLists(update.SafetyFeatures);
            OtherFeatures = CheckLists(update.OtherFeatures);
            ListedOn = DateTime.Now;
        }

        public static List<string> CheckLists(List<string> toCheck)
        {
            foreach (var safetyF in toCheck)
            {
                if (safetyF.IsWhitespace())
                {
                    toCheck.Remove(safetyF);
                    continue;
                }
            }
            return toCheck;
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string SellerId { get; set; }

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
        public List<string> SafetyFeatures { get; set; }

        [MaxLength(500)]
        public List<string> OtherFeatures { get; set; }

        [Required]
        public DateTime ListedOn { get; set; }
    }
}
