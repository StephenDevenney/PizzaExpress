﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<PizzaEntity> Pizza { get; set; }
        #endregion

        #region MODELBUILDER
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientEntity>(DBUser);
            modelBuilder.Entity<ClientRoleEntity>(DBUserRole);
            modelBuilder.Entity<NavMenuEntity>(DBNavMenu);
            modelBuilder.Entity<NavMenuRoleEntity>(DBNavMenuRole);
            modelBuilder.Entity<PizzaEntity>(DBPizza);
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
        private void DBPizza(EntityTypeBuilder<PizzaEntity> _)
        {
            _.ToTable("Pizza", "enum.pizza");
            _.HasKey(x => x.PizzaId);
            _.Property<int>(x => x.PizzaId).HasColumnName("PizzaId");
            _.Property<string>(x => x.Name).HasColumnName("Name");
            _.Property<string>(x => x.Description).HasColumnName("Description");
            _.Property<decimal>(x => x.Price).HasColumnName("Price");
            _.Property<string>(x => x.ImageLink).HasColumnName("ImageLink");
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
    }
}
