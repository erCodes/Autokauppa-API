using Autokauppa_DAO.Objects;
using Microsoft.EntityFrameworkCore;
using static Autokauppa_DAO.Methods;
namespace Autokauppa_DAL.CarRepository
{
    public interface IGet
    {
        List<Car>? ByBrand(string brand);
        List<Car>? ByBrandAndModel(string brand, string model);
    }

    public class Get(Context Db) : IGet
    {
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
            catch (ArgumentNullException e)
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
