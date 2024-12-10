using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Autokauppa_DAL.CarRepository
{
    public interface IDelete
    {
        Delete.Result CarById(string id);
    }

    public class Delete(Context Db) : IDelete
    {
        // Muuta tämä code + result object tyyppisenä ja passaa se object suoraan fronttiin. Sama muihinkin luokkiin.
        public enum Result
        {
            OK,
            NotFound,
            ServerError
        }

        public Result CarById(string id)
        {
            try
            {
                var found = Db.Cars.FirstOrDefault(x => x.Id == id);
                if (found != null)
                {
                    Db.Cars.Remove(found);
                    Db.SaveChanges();
                    return Result.OK;
                }
                else
                {
                    return Result.NotFound;
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return Result.ServerError;
            }



        }
    }
}
