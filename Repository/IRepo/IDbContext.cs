using System.Data.Entity;

namespace Repository.IRepo
{
    public interface IDbContext
    {
        DbSet<Models.Product> Products { get; set; }
        DbSet<Models.Order> Orders { get; set; }

        int SaveChanges();
        Database Database { get; }
    }
}
