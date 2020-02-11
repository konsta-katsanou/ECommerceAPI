using System;
using System.Collections.Generic;
using EcommerceAPI.Dto;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPi.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public DateTime RegistrationDate { get; set; }

        public decimal Balance { get; set; }

        public List<Order> Orders { get; set; }

    }

    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

    }


    public class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public DateTime Date { get; set; }

        public List<OrderProduct> OrderProduct { get; set; }

    }


    public class OrderProduct
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int OrderQuantity { get; set; }
    }


    public class EcommerceDbContent : DbContext
    {

        private readonly string s1 = "Server = DESKTOP-TJ30A6D\\BASI17; Database = ecommerce; Integrated Security=SSPI  ; Persist Security Info=False;";

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderProduct> OrderProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(s1);
        }

    }


}
