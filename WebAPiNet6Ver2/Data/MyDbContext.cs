using Microsoft.EntityFrameworkCore;

namespace WebAPiNet6Ver2.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        #region Dbset
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<HangHoa> hangHoas { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(e =>
            {
                e.ToTable("Order");
                e.HasKey(or => or.MaDh);
                e.Property(s => s.NgayDat).HasDefaultValueSql("getutcdate()");
                e.Property(s => s.NguoiNhan).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<OrderDetail>(e =>
            {
                e.ToTable("OrderDetail");
                e.HasKey(e => new { e.MaDh, e.MaHh });
                e.HasOne(e => e.Order)
                .WithMany(e => e.OrderDetails)
                .HasForeignKey(e => e.MaDh)
                .HasConstraintName("FK_OrderDetail_Order");

                e.HasOne(e => e.HangHoa)
                .WithMany(e => e.OrderDetails)
                .HasForeignKey(e => e.MaHh)
                .HasConstraintName("FK_OrderDetail_HangHoa");
            });
            modelBuilder.Entity<User>(e =>
            {
                e.HasIndex(a => a.UserName).IsUnique();
                e.Property(a => a.Name).IsRequired().HasMaxLength(150);
                e.Property(a => a.Email).IsRequired().HasMaxLength(150);
            });
            base.OnModelCreating(modelBuilder);
        }

    }
}
