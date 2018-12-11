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

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<OrderHeader> OrderHeader { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<StoreInventory> StoreInventory { get; set; }
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

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address", "PO");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

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

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Zipcode).HasColumnName("ZIPCode");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail", "PO");

                entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetailID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OOrderDetail_OrderHeader_OrderDetailID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetail_Products_Product_ID");
            });

            modelBuilder.Entity<OrderHeader>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK_OrderHeader_OrderID");

                entity.ToTable("OrderHeader", "PO");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.OrderAddressId).HasColumnName("OrderAddressID");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("UserID")
                    .HasMaxLength(100);

                entity.HasOne(d => d.OrderAddress)
                    .WithMany(p => p.OrderHeader)
                    .HasForeignKey(d => d.OrderAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderHeader_Address_AddressID");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.OrderHeader)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK_Products_ProductID");

                entity.ToTable("Products", "PO");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store", "PO");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.SaddressLine1)
                    .IsRequired()
                    .HasColumnName("SAddressLine1")
                    .HasMaxLength(100);

                entity.Property(e => e.SaddressLine2)
                    .HasColumnName("SAddressLine2")
                    .HasMaxLength(100);

                entity.Property(e => e.Scity)
                    .IsRequired()
                    .HasColumnName("SCity")
                    .HasMaxLength(100);

                entity.Property(e => e.Sstate)
                    .IsRequired()
                    .HasColumnName("SState")
                    .HasMaxLength(100);

                entity.Property(e => e.Szipcode).HasColumnName("SZIPCode");
            });

            modelBuilder.Entity<StoreInventory>(entity =>
            {
                entity.ToTable("StoreInventory", "PO");

                entity.Property(e => e.StoreInventoryId).HasColumnName("StoreInventoryID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.StoreInventory)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.StoreInventory)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_Users_UserID");

                entity.ToTable("Users", "PO");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.DefaultAddressId).HasColumnName("DefaultAddressID");

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
