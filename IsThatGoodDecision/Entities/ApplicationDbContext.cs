using Microsoft.EntityFrameworkCore;

namespace IsThatGoodDecision.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<WishListEntity> WishLists { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
                .HasOne(u => u.WishList)
                .WithOne(w => w.User)
                .HasForeignKey<WishListEntity>(w => w.UserId);

            modelBuilder.Entity<WishListEntity>()
                .HasOne(w => w.User)
                .WithOne(u => u.WishList)
                .HasForeignKey<UserEntity>(u => u.WishListId);

            modelBuilder.Entity<WishListEntity>()
                .HasMany(w => w.Products)
                .WithOne(p => p.WishList);

            modelBuilder.Entity<ProductEntity>()
                .HasOne(p => p.WishList)
                .WithMany(w => w.Products);

            modelBuilder.Entity<ProductEntity>()
                .HasMany(p => p.Comments)
                .WithOne(c => c.Product);

            modelBuilder.Entity<CommentEntity>()
                .HasOne(c => c.Product)
                .WithMany(p => p.Comments);
        }
    }
}
