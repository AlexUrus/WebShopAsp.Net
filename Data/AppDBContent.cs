﻿
using Microsoft.EntityFrameworkCore;
using Shop.Data.Models;

namespace Shop.Data
{
	public class AppDBContent : DbContext
	{
		public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
		{
		}

		public DbSet<Car> Cars { get; set; }
		public DbSet<Category> Categories { get; set; }
        public DbSet<ShopCartItem> ShopCartItems { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

    }
}
