using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaRestaurant.DataAccess
{
    public partial class PizzaOrdersContext : DbContext
    {
        public PizzaOrdersContext()
        {
        }

        public PizzaOrdersContext(DbContextOptions<PizzaOrdersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DeliveryLocations> DeliveryLocations { get; set; }
        public virtual DbSet<InventoryClass> InventoryClass { get; set; }
        public virtual DbSet<InventoryType> InventoryType { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrdersDescription> OrdersDescription { get; set; }
        public virtual DbSet<StoreLocations> StoreLocations { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<DeliveryLocations>(entity =>
            {
                entity.HasKey(e => e.DeliveryLocId)
                    .HasName("PK_DeliveryLocations_DeliveryLocID");

                entity.ToTable("DeliveryLocations", "PizzaOrders");

                entity.Property(e => e.DeliveryLocId).HasColumnName("DeliveryLocID");

                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.AddressLine2).HasMaxLength(100);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Zipcode).HasColumnName("ZIPCode");
            });

            modelBuilder.Entity<InventoryClass>(entity =>
            {
                entity.HasKey(e => e.ItemClassId)
                    .HasName("PK_InventoryClass_ItemClassID");

                entity.ToTable("InventoryClass", "PizzaOrders");

                entity.Property(e => e.ItemClassId).HasColumnName("ItemClassID");

                entity.Property(e => e.ClassName).HasMaxLength(100);
            });

            modelBuilder.Entity<InventoryType>(entity =>
            {
                entity.HasKey(e => e.ItemTypeId)
                    .HasName("PK_InventoryType_ItemTypeID");

                entity.ToTable("InventoryType", "PizzaOrders");

                entity.Property(e => e.ItemTypeId).HasColumnName("ItemTypeID");

                entity.Property(e => e.ItemClassId).HasColumnName("ItemClassID");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.ItemClass)
                    .WithMany(p => p.InventoryType)
                    .HasForeignKey(d => d.ItemClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PK_Menu_ItemID");

                entity.ToTable("Menu", "PizzaOrders");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.ItemCost).HasColumnType("money");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ItemSize).HasMaxLength(50);

                entity.Property(e => e.ItemTypeId).HasColumnName("ItemTypeID");

                entity.HasOne(d => d.ItemType)
                    .WithMany(p => p.Menu)
                    .HasForeignKey(d => d.ItemTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK_Orders_OrderID");

                entity.ToTable("Orders", "PizzaOrders");

                entity.Property(e => e.OrderId)
                    .HasColumnName("OrderID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DeliveryAddressId).HasColumnName("DeliveryAddressID");

                entity.Property(e => e.NetTotal).HasColumnType("money");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.SubTotal).HasColumnType("money");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.DeliveryAddress)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.DeliveryAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("KF_Orders_DeliveryLocations_DeliveryAddressID");

                entity.HasOne(d => d.Order)
                    .WithOne(p => p.Orders)
                    .HasForeignKey<Orders>(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_StoreLocations_StoreLocID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<OrdersDescription>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK_OrdersDescription_OrderID");

                entity.ToTable("OrdersDescription", "PizzaOrders");

                entity.Property(e => e.OrderId)
                    .HasColumnName("OrderID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.OrdersDescription)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<StoreLocations>(entity =>
            {
                entity.HasKey(e => e.StoreLocId)
                    .HasName("PK_StoreLocation_StoreLocID");

                entity.ToTable("StoreLocations", "PizzaOrders");

                entity.Property(e => e.StoreLocId).HasColumnName("StoreLocID");

                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.AddressLine2).HasMaxLength(100);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.StoreName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Zipcode).HasColumnName("ZIPCode");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_User_ID");

                entity.ToTable("Users", "PizzaOrders");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}
