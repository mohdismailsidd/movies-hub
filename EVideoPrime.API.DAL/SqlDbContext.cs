using EVideoPrime.API.Entities.Identity;
using EVideoPrime.API.Entities.VideoPrime;
using Microsoft.EntityFrameworkCore;

namespace Movies.API.DAL
{
    public partial class SqlDbContext : DbContext
    {
        public SqlDbContext()
        {

        }

        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<PaymentDetail> PaymentDetails { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=sql-server123.database.windows.net,1433;Database=movies-dev-db;User Id=sqladmin;Password=password@123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Category>(entity =>
            {
                entity.Property(p => p.Description).IsRequired();
                entity.Property(p => p.Name).IsRequired();
            }
            );
            builder.Entity<Movie>(entity =>
            {
                entity.Property(p => p.ReleaseDate).HasColumnType("datetime").HasDefaultValueSql("sysdatetime()");
            });
            builder.Entity<Subscription>(entity =>
            {
                entity.Property(p => p.SubscribedOn).HasColumnType("datetime").HasDefaultValueSql("sysdatetime()");
            });
            builder.Entity<PaymentDetail>(entity =>
            {
                entity.Property(p => p.CreatedDate).HasColumnType("datetime").HasDefaultValueSql("sysdatetime()");
            });
            builder.Entity<User>(entity =>
            {
                entity.HasKey("Id");
                entity.Property(p => p.CreatedDate).HasColumnType("datetime").HasDefaultValueSql("sysdatetime()");
                entity.HasMany(d => d.Roles)
                    .WithMany(d => d.Users)
                    .UsingEntity<Dictionary<string, object>>(
                    "UserRole",
                    r => r.HasOne<Role>().WithMany().HasForeignKey("RoleId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_UserRoles_Role"),
                    u => u.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_UserRoles_User"),
                    ur =>
                    {
                        ur.HasKey("UserId", "RoleId").HasName("PK_UserRoles_User_Role");
                        ur.ToTable("UserRoles");
                    }
                    );
            });
            OnModelCreatingPartial(builder);
        }

        partial void OnModelCreatingPartial(ModelBuilder builder);

    }
}