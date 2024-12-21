using Autokauppa_DAO.Objects;
using Microsoft.EntityFrameworkCore;

namespace Autokauppa_DAL
{
    public class Context(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<SellerInfo> SellerInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
