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
        public DbSet<ClientEntity> Client { get; set; }
        public DbSet<ClientRoleEntity> ClientRole { get; set; }
        public DbSet<NavMenuEntity> NavMenu { get; set; }
        public DbSet<NavMenuRoleEntity> NavMenuRole { get; set; }
        public DbSet<ProductEntity> Product { get; set; }
        public DbSet<ProductTypeEntity> ProductType { get; set; }
        public DbSet<BasketItemEntity> BasketItem { get; set; }
        public DbSet<OrderEntity> Order { get; set; }
        public DbSet<OrderedProductEntity> OrderedProduct { get; set; }
        public DbSet<OrderStatusEntity> OrderStatus { get; set; }
        #endregion

        #region MODELBUILDER
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientEntity>(DBUser);
            modelBuilder.Entity<ClientRoleEntity>(DBUserRole);
            modelBuilder.Entity<NavMenuEntity>(DBNavMenu);
            modelBuilder.Entity<NavMenuRoleEntity>(DBNavMenuRole);
            modelBuilder.Entity<ProductEntity>(DBProduct);
            modelBuilder.Entity<ProductTypeEntity>(DBProductType); 
            modelBuilder.Entity<BasketItemEntity>(DBBasketItems);
            modelBuilder.Entity<OrderEntity>(DBOrder);
            modelBuilder.Entity<OrderedProductEntity>(DBOrderedProducts);
            modelBuilder.Entity<OrderStatusEntity>(DBOrderStatus);
            base.OnModelCreating(modelBuilder);
        }
        #endregion

        #region ENUM
        private void DBUserRole(EntityTypeBuilder<ClientRoleEntity> _)
        {
            _.ToTable("ClientRole", "enum.security");
            _.HasKey(x => x.ClientRoleId);
            _.Property<int>(x => x.ClientRoleId).HasColumnName("ClientRoleId");
            _.Property<string>(x => x.RoleName).HasColumnName("RoleName");
        }
        private void DBNavMenu(EntityTypeBuilder<NavMenuEntity> _)
        {
            _.ToTable("NavMenu", "enum.security");
            _.HasKey(x => x.NavMenuId);
            _.Property<int>(x => x.NavMenuId).HasColumnName("NavMenuId");
            _.Property<string>(x => x.NavMenuName).HasColumnName("NavMenuName");
            _.Property<string>(x => x.NavMenuTitle).HasColumnName("NavMenuTitle");
            _.Property<string>(x => x.NavMenuRoute).HasColumnName("NavMenuRoute");
        }
        private void DBProduct(EntityTypeBuilder<ProductEntity> _)
        {
            _.ToTable("Product", "enum.product");
            _.HasKey(x => x.ProductId);
            _.Property<int>(x => x.ProductId).HasColumnName("ProductId");
            _.Property<int>(x => x.ProductTypeId).HasColumnName("FK_ProductTypeId");
            _.Property<string>(x => x.Name).HasColumnName("Name");
            _.Property<string>(x => x.Description).HasColumnName("Description");
            _.Property<decimal>(x => x.Price).HasColumnName("Price");
            _.Property<string>(x => x.ImageLink).HasColumnName("ImageLink");
        }
        private void DBProductType(EntityTypeBuilder<ProductTypeEntity> _)
        {
            _.ToTable("ProductTypes", "enum.product");
            _.HasKey(x => x.ProductTypeId);
            _.Property<int>(x => x.ProductTypeId).HasColumnName("ProductTypeId");
            _.Property<string>(x => x.Name).HasColumnName("Name");
        }
        private void DBOrderStatus(EntityTypeBuilder<OrderStatusEntity> _)
        {
            _.ToTable("Status", "enum.product");
            _.HasKey(x => x.StatusId);
            _.Property<int>(x => x.StatusId).HasColumnName("StatusId");
            _.Property<string>(x => x.Description).HasColumnName("Description");
        }
        #endregion

        #region SECURITY
        private void DBUser(EntityTypeBuilder<ClientEntity> _)
        {
            _.ToTable("Client", "security");
            _.HasKey(x => x.ClientId);
            _.Property<int>(x => x.ClientId).HasColumnName("ClientId");
            _.Property<int>(x => x.ClientRoleId).HasColumnName("FK_ClientRoleId");
            _.Property<string>(x => x.ClientName).HasColumnName("ClientName");
        }
        private void DBNavMenuRole(EntityTypeBuilder<NavMenuRoleEntity> _)
        {
            _.ToTable("NavMenuRole", "security");
            _.HasKey(x => x.NavMenuRoleId);
            _.Property<int>(x => x.NavMenuRoleId).HasColumnName("NavMenuRoleId");
            _.Property<int>(x => x.NavMenuId).HasColumnName("FK_NavMenuId");
            _.Property<int>(x => x.ClientRoleId).HasColumnName("FK_ClientRoleId");
        }
        #endregion

        #region BASKET
        private void DBBasketItems(EntityTypeBuilder<BasketItemEntity> _)
        {
            _.ToTable("BasketItems", "product");
            _.HasKey(x => x.BasketItemId);
            _.Property<int>(x => x.BasketItemId).HasColumnName("BasketItemId");
            _.Property<int>(x => x.ClientId).HasColumnName("FK_ClientId");
            _.Property<int>(x => x.ProductId).HasColumnName("FK_ProductId");
            _.Property<int>(x => x.ProductCount).HasColumnName("ProductCount");
        }
        #endregion

        #region ORDER
        private void DBOrder(EntityTypeBuilder<OrderEntity> _)
        {
            _.ToTable("Order", "product");
            _.HasKey(x => x.OrderId);
            _.Property<int>(x => x.OrderId).HasColumnName("OrderId");
            _.Property<int>(x => x.ClientId).HasColumnName("FK_ClientId");
            _.Property<int>(x => x.StatusId).HasColumnName("FK_StatusId");
            _.Property<string>(x => x.OrderCode).HasColumnName("OrderCode");
        }
        private void DBOrderedProducts(EntityTypeBuilder<OrderedProductEntity> _)
        {
            _.ToTable("OrderedProducts", "product");
            _.HasKey(x => x.OrderedProductId);
            _.Property<int>(x => x.OrderedProductId).HasColumnName("OrderedProductId");
            _.Property<int>(x => x.OrderId).HasColumnName("FK_OrderId");
            _.Property<int>(x => x.ProductId).HasColumnName("FK_ProductId");
            _.Property<int>(x => x.ProductCount).HasColumnName("ProductCount");
        }
        #endregion
    }
}
