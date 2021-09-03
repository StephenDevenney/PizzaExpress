using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza.Express.Shared.Entities;

namespace Pizza.Express.Context
{
    public class SqlContext : DbContext
    {
        #region CONSTRUCTOR
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        { }
        #endregion

        #region DBSET
        public DbSet<UserEntity> User { get; set; }
        public DbSet<UserRoleEntity> UserRole { get; set; }
        #endregion

        #region MODELBUILDER
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>(DBUser);
            modelBuilder.Entity<UserRoleEntity>(DBUserRole);
            base.OnModelCreating(modelBuilder);
        }
        #endregion

        #region ENUM
        private void DBUserRole(EntityTypeBuilder<UserRoleEntity> _)
        {
            _.ToTable("UserRole", "enum");
            _.HasKey(x => x.UserRoleId);
            _.Property<int>(x => x.UserRoleId).HasColumnName("UserRoleId");
            _.Property<string>(x => x.RoleName).HasColumnName("RoleName");
        }
        #endregion

        #region SECURITY
        private void DBUser(EntityTypeBuilder<UserEntity> _)
        {
            _.ToTable("User", "security");
            _.HasKey(x => x.UserId);
            _.Property<int>(x => x.UserId).HasColumnName("UserId");
            _.Property<int>(x => x.UserRoleId).HasColumnName("FK_UserRoleId");
            _.Property<string>(x => x.UserName).HasColumnName("UserName");
        }
        #endregion
    }
}
