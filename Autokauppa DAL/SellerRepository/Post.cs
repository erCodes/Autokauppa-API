using Autokauppa_DAO.Objects;
using Autokauppa_DAO.QueryObjects;
using Microsoft.EntityFrameworkCore;
using static Autokauppa_DAO.Objects.Result;

namespace Autokauppa_DAL.SellerRepository
{
    public interface IPost
    {
        Result NewSeller(QuerySellerInfo querySeller);
    }

    public class Post(Context db) : IPost
    {
        public Result NewSeller(QuerySellerInfo querySeller)
        {
            try
            {
                var exists = db.SellerInfo.Where(x => x.Name == querySeller.Name)
                    .ToList()
                    .FirstOrDefault();

                if (exists != null)
                {
                    return new Result(Status.BadRequest, exists);
                }

                var newDbEntry = new SellerInfo(querySeller);
                db.SellerInfo.Add(newDbEntry);
                db.Entry(newDbEntry).State = EntityState.Added;
                db.SaveChanges();

                return new Result(Status.OK);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Result(Status.ServerError);
            }
        }
    }
}
