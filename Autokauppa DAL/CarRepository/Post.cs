using static Autokauppa_DAO.Methods;
using Autokauppa_DAO.Objects;
using Autokauppa_DAO.QueryObjects;
using Microsoft.EntityFrameworkCore;
using static Autokauppa_DAO.Objects.Result;

namespace Autokauppa_DAL.CarRepository
{
    public interface IPost
    {
        Result NewCar(QueryCar newCar);
    }

    public class Post(Context db) : IPost
    {
        public Result NewCar(QueryCar newCar)
        {
            var exists = db.Cars.FirstOrDefault(
                x => string.Equals(
                    x.SellerInfo.Name,
                    newCar.SellerInfo.Name,
                    StringComparison.OrdinalIgnoreCase));

            Car? newdbEntry = null;

            if (exists != null)
            {
                newdbEntry = new Car(newCar, exists.SellerInfo);
            }
            else
            {
                newdbEntry = new Car(newCar);
            }

            try
            {
                db.Add(newdbEntry);
                db.Entry(newdbEntry).State = EntityState.Added;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Result(Status.ServerError);
            }

            return new Result(Status.OK);
        }
    }
}
