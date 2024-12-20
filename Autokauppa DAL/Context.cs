using Autokauppa_DAO.Objects;
using Microsoft.EntityFrameworkCore;

namespace Autokauppa_DAL
{
    public class Context(DbContextOptions options) : DbContext(options)
    {
        // Erota Seller info omaksi db setiksi viimeisenä.
        public DbSet<Car> Cars { get; set; }

        public DbSet<SellerInfo> SellerInfo { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder builder)
        //{
        //    builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AutokauppaDb;Trusted_Connection=true;MultipleActiveResultSets=true");
        //}
    }
}
