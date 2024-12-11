using Autokauppa_DAO.Objects;
using Autokauppa_DAO.QueryObjects;
using Microsoft.EntityFrameworkCore;
using static Autokauppa_DAO.Methods;
using static Autokauppa_DAO.Objects.Result;
namespace Autokauppa_DAL.CarRepository
{
    public interface IGet
    {
        List<Car>? ByBrand(string brand);
        List<Car>? ByBrandAndModel(string brand, string model);
    }

    public class Get(Context Db) : IGet
    {
        public Result ByQuery(Query query)
        {
            List<Car> cars = [];

            var test =
                from c in Db.Cars
                where (string.IsNullOrWhiteSpace(query.Brand)  || c.Brand == query.Brand)
                && (string.IsNullOrWhiteSpace(query.Model) || c.Model == query.Model)
                && (string.IsNullOrWhiteSpace(query.ProductionYear) || c.ProductionYear == query.ProductionYear)
                && (string.IsNullOrWhiteSpace(query.EngineSize) || c.EngineSize == query.EngineSize)
                && (string.IsNullOrWhiteSpace(query.FuelType) || c.FuelType == query.FuelType)
                && (string.IsNullOrWhiteSpace(query.Transmission) || c.Transmission == query.Transmission)
                && (query.SafetyFeatures.Any() || query.SafetyFeatures.All(x => c.SafetyFeatures.Any(y => y == x)))
                && (query.OtherFeatures.Any() || query.OtherFeatures.All(x => c.SafetyFeatures.Any(y => y == x)))
                && (string.IsNullOrWhiteSpace(query.SellerName) || c.SellerInfo.Name == query.SellerName)
                && (string.IsNullOrWhiteSpace(query.SellerEmail) || c.SellerInfo.Email == query.SellerEmail)
                && (string.IsNullOrWhiteSpace(query.SellerPhoneNumber) || c.SellerInfo.PhoneNumber == query.SellerPhoneNumber)
                select c;

            var data = test.ToList();







            if (!query.Brand.IsWhitespace())
            {
                var a = Db.Cars.Where(x => x.Brand == query.Brand).ToList();
            }
            return null;
        }

        public List<Car>? ByBrand(string brand)
        {
            try
            {
                var cars = Db.Cars
                    .Where(x => x.Brand == brand)
                    .Include(x => x.SafetyFeatures)
                    .Include(x => x.OtherFeatures)
                    .Include(x => x.SellerInfo)
                    .ToList();

                if (cars.Empty())
                {
                    return null;
                }

                return cars;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public List<Car>? ByBrandAndModel(string brand, string model)
        {
            try
            {
                var cars = Db.Cars
                    .Where(x => x.Brand == brand && x.Model == model)
                    .Include(x => x.SafetyFeatures)
                    .Include(x => x.OtherFeatures)
                    .Include(x => x.SellerInfo)
                    .ToList();

                if (cars.Empty())
                {
                    return null;
                }

                return cars;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
