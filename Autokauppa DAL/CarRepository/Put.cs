using Autokauppa_DAO.Objects;
using Autokauppa_DAO.QueryObjects;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using static Autokauppa_DAO.Objects.Result;

namespace Autokauppa_DAL.CarRepository
{
    public interface IPut
    {
        Result UpdateCar(CarUpdateInfo update);
    }

    public class Put(Context db) : IPut
    {
        public Result UpdateCar(CarUpdateInfo update)
        {
            try
            {
                var car = db.Cars.FirstOrDefault(x => x.Id == update.CarId);
                if (car == null)
                {
                    return new Result(Status.NoContent);
                }

                car = new Car(car, update);

                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();

                return new Result(Status.OK, car);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Result(Status.ServerError);
            }
        }
    }
}
