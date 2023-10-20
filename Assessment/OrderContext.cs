using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessment.Models;
using Microsoft.EntityFrameworkCore;

namespace Assessment
{
    public class OrderContext:DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options): base(options)
        {

        }

        public DbSet<Orders> orders { get; set; }
        public DbSet<OrderLine> orderLines { get; set; }
        public DbSet<OrderStatus> orderStatuses { get; set; }
        public DbSet<OrderType> orderTypes { get; set;}
        public DbSet<ProductType> productTypes { get; set; }
        public DbSet<UserRole> userRoles { get; set; }
        public DbSet<AppUsers> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderType>().HasData(
                new OrderType { OrderTypeID = 1, TypeDescription = "Normal" },
                new OrderType { OrderTypeID = 2, TypeDescription = "Staff" },
                new OrderType { OrderTypeID = 3, TypeDescription = "Mechanical" },
                new OrderType { OrderTypeID = 4, TypeDescription = "Perishable" });

            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { UserRoleID = 1, UserRoleDescription = "Admin" },
                new UserRole { UserRoleID = 2, UserRoleDescription = "Guest" });

            modelBuilder.Entity<OrderStatus>().HasData(
                new OrderStatus { OrderStatusID = 1, StatusDescription = "New" },
                new OrderStatus { OrderStatusID = 2, StatusDescription = "Processing" },
                new OrderStatus { OrderStatusID = 3, StatusDescription = "Complete" });

            modelBuilder.Entity<ProductType>().HasData(
                new ProductType { ProductTypeID = 1, ProductTypeDescription = "Apparel" },
                new ProductType { ProductTypeID = 2, ProductTypeDescription = "Parts" },
                new ProductType { ProductTypeID = 3, ProductTypeDescription = "Equipment" },
                new ProductType { ProductTypeID = 4, ProductTypeDescription = "Motor" });


        }
    }
}
