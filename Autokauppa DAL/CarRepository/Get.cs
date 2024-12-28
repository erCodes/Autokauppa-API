using Autokauppa_DAO.Objects;
using Autokauppa_DAO.QueryObjects;
using Microsoft.EntityFrameworkCore;
using static Autokauppa_DAO.Methods;
using static Autokauppa_DAO.Objects.Result;
namespace Autokauppa_DAL.CarRepository
{
    public interface IGet
    {
        Result ByBrand(string brand);
        Result ByBrandAndModel(string brand, string model);
        Result ByQuery(Query query);
    }

    public class Get(Context db) : IGet
    {
        public Result ByQuery(Query query)
        {
            try
            {
                var carQuery =
                from c in db.Cars
                where (string.IsNullOrWhiteSpace(query.Brand) || c.Brand == query.Brand)
                && (string.IsNullOrWhiteSpace(query.Model) || c.Model == query.Model)
                && (string.IsNullOrWhiteSpace(query.ProductionYear) || c.ProductionYear == query.ProductionYear)
                && (string.IsNullOrWhiteSpace(query.EngineSize) || c.EngineSize == query.EngineSize)
                && (string.IsNullOrWhiteSpace(query.FuelType) || c.FuelType == query.FuelType)
                && (string.IsNullOrWhiteSpace(query.Transmission) || c.Transmission == query.Transmission)
                && (query.SafetyFeatures.Any() || query.SafetyFeatures.All(x => c.SafetyFeatures.Any(y => y == x)))
                && (query.OtherFeatures.Any() || query.OtherFeatures.All(x => c.SafetyFeatures.Any(y => y == x)))
                && (string.IsNullOrWhiteSpace(query.SellerId) || c.SellerId == query.SellerId)
                select c;

                var data = carQuery.ToList();
                if (data.Empty())
                {
                    return new Result(Status.NoContent);
                }

                return new Result(Status.OK, data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Result(Status.ServerError);
            }
        }

        public Result ByBrand(string brand)
        {
            try
            {
                var data = db.Cars
                    .Where(x => x.Brand == brand)
                    .ToList();

                if (data.Empty())
                {
                    return new Result(Status.NoContent);
                }

                return new Result(Status.OK, data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Result(Status.ServerError);
            }
        }

        public Result ByBrandAndModel(string brand, string model)
        {
            try
            {
                var data = db.Cars
                    .Where(x => x.Brand == brand && x.Model == model)
                    .ToList();

                if (data.Empty())
                {
                    return new Result(Status.NoContent);
                }

                return new Result(Status.OK, data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Result(Status.ServerError);
            }
        }
    }
}
