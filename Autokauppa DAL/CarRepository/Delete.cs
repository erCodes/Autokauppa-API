using Microsoft.AspNetCore.Http.HttpResults;
using Autokauppa_DAO.Objects;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static Autokauppa_DAO.Objects.Result;

namespace Autokauppa_DAL.CarRepository
{
    public interface IDelete
    {
        Result CarById(string id);
    }

    public class Delete(Context db) : IDelete
    {
        public Result CarById(string id)
        {
            try
            {
                var found = db.Cars.FirstOrDefault(x => x.Id == id);
                if (found != null)
                {
                    db.Cars.Remove(found);
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
