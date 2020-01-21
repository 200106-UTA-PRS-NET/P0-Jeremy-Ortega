using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaBox.Domain.Models
{
    public partial class Project0Context : DbContext
    {
        public Project0Context()
        {
        }

        public Project0Context(DbContextOptions<Project0Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CxOrder> CxOrder { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<Store> Store { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("fname")
                    .IsUnicode(false);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("lname")
                    .IsUnicode(false);

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.UserPass)
                    .HasColumnName("userPass")
                    .IsUnicode(false);

                entity.Property(e => e.Email)//////////changed Username to Email
                    .HasColumnName("username")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CxOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__CxOrder__C3905BAF870EB072");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.CustId).HasColumnName("Cust_Id");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StoreId).HasColumnName("Store_Id");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.CxOrder)
                    .HasForeignKey(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CxOrder__Cust_Id__6F7F8B4B");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.CxOrder)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CxOrder__Store_I__6E8B6712");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.Property(e => e.PizzaId).HasColumnName("PizzaID");

                entity.Property(e => e.Crust).HasColumnName("crust");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.Size).HasColumnName("size");

                entity.Property(e => e.Toppings).HasColumnName("toppings");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pizza__OrderID__74444068");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.Property(e => e.StoreLocation)
                    .HasColumnName("storeLocation")
                    .IsUnicode(false);

                entity.Property(e => e.StoreName)
                    .HasColumnName("storeName")
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
