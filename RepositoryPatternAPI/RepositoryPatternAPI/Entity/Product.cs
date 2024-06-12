﻿
namespace RepositoryPatternAPI.Entity
{
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } 

        public decimal Price { get; set; }

        //navigation property

        public List<Order> Orders { get; set; }
    }
}