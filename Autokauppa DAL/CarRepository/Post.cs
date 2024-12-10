using static Autokauppa_DAO.Methods;
using Autokauppa_DAO.Objects;
using Autokauppa_DAO.QueryObjects;
using Microsoft.EntityFrameworkCore;

namespace Autokauppa_DAL.CarRepository
{
    public interface IPost
    {
        bool NewCar(QueryCar newCar);
    }

    public class Post(Context db) : IPost
    {
        public Context Db { get; set; } = db;
        public bool NewCar(QueryCar newCar)
        {
            var exists = Db.Cars.FirstOrDefault(
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
                Db.Add(newdbEntry);
                Db.Entry(newdbEntry).State = EntityState.Added;
                Db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }
    }
}
