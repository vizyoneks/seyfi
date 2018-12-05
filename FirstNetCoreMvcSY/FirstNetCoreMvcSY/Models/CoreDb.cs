using Microsoft.EntityFrameworkCore;

namespace FirstNetCoreMvcSY.Models
{
    public class CoreDb : DbContext
    {
        public CoreDb()
        {

        }

        public CoreDb(DbContextOptions<CoreDb> options)
       : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");
                entity.HasKey(x => x.Id);
            });
        }

        public virtual DbSet<Product> Products { get; set; }

    }
}
