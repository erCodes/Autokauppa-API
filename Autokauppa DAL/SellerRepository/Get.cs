using Autokauppa_DAO;
using Autokauppa_DAO.Objects;
using Autokauppa_DAO.QueryObjects;
using static Autokauppa_DAO.Objects.Result;

namespace Autokauppa_DAL.SellerRepository
{
    public interface IGet
    {
        Result ByQuery(QuerySellerInfo query);
    }

    public class Get(Context db) : IGet
    {
        public Result ByQuery(QuerySellerInfo query)
        {
            try
            {
                var sellerQuery =
                from s in db.SellerInfo
                where (string.IsNullOrWhiteSpace(query.Name) || s.Name == query.Name)
                && (string.IsNullOrWhiteSpace(query.Email) || s.Email == query.Email)
                && (string.IsNullOrWhiteSpace(query.PhoneNumber) || s.PhoneNumber == query.PhoneNumber)
                select s;

                var data = sellerQuery.ToList();
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
