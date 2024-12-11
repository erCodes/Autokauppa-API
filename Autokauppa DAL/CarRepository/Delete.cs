using Microsoft.AspNetCore.Http.HttpResults;
using Autokauppa_DAO.Objects;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static Autokauppa_DAO.Objects.Result;

namespace Autokauppa_DAL.CarRepository
{
    public interface IDelete
    {
        Status CarById(string id);
    }

    public class Delete(Context Db) : IDelete
    {
        // Muuta tämä code + result object tyyppisenä ja passaa se object suoraan fronttiin. Sama muihinkin luokkiin.
        public Status CarById(string id)
        {
            try
            {
                var found = Db.Cars.FirstOrDefault(x => x.Id == id);
                if (found != null)
                {
                    Db.Cars.Remove(found);
                    Db.SaveChanges();
                    return Status.OK;
                }
                else
                {
                    return Status.NotFound;
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return Status.ServerError;
            }



        }
    }
}
