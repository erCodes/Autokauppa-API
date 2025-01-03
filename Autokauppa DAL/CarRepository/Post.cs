﻿using static Autokauppa_DAO.Methods;
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
            try
            {
                var seller = db.SellerInfo.Where(x => x.Id == newCar.SellerId)
                    .FirstOrDefault();
                if (seller == null)
                {
                    return new Result(Status.BadRequest);
                }

                var newdbEntry = new Car(newCar);
                seller.SoldCars ??= [];
                seller.SoldCars.Add(newdbEntry);
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
