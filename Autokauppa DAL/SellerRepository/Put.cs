using Autokauppa_DAO.Objects;
using Autokauppa_DAO.QueryObjects;
using Microsoft.EntityFrameworkCore;
using static Autokauppa_DAO.Objects.Result;

namespace Autokauppa_DAL.SellerRepository
{
    public interface IPut
    {
        Result UpdateSeller(string id, QuerySellerInfo update);
    }

    public class Put(Context db) : IPut
    {
        public Result UpdateSeller(string id, QuerySellerInfo update)
        {
            try
            {
                var seller = db.SellerInfo
                    .AsNoTracking()
                    .Include(x => x.SoldCars)
                    .FirstOrDefault(y => y.Id == id);
                if (seller == null)
                {
                    return new Result(Status.NoContent);
                }

                seller = new SellerInfo(seller, update);
                db.Update(seller);
                db.SaveChanges();

                return new Result(Status.OK, seller);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Result(Status.ServerError);
            }

        }
    }
}
