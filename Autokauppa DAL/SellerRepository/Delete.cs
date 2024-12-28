using Autokauppa_DAO.Objects;
using Microsoft.EntityFrameworkCore;
using static Autokauppa_DAO.Objects.Result;

namespace Autokauppa_DAL.SellerRepository
{
    public interface IDelete
    {
        Result SellerById(string id);
    }

    public class Delete(Context db) : IDelete
    {
        public Result SellerById(string id)
        {
            try
            {
                var found = db.SellerInfo
                    .Include(x => x.SoldCars)
                    .FirstOrDefault(y => y.Id == id);

                if (found != null)
                {
                    db.SellerInfo.Remove(found);
                    db.SaveChanges();
                    return new Result(Status.OK);
                }
                else
                {
                    return new Result(Status.NoContent);
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Result(Status.ServerError);
            }
        }
    }
}
