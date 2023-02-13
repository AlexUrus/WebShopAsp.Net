using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;

namespace Shop.Data.Repository
{
	public class OrdersRepository : IAllOrders
	{
        private readonly AppDBContent appDBContent;
        private readonly ShopCart shopCart;

        public OrdersRepository(AppDBContent appDBContent, ShopCart shopCart)
        {
            this.appDBContent = appDBContent;
            this.shopCart = shopCart;
        }

        public void createOrder(Order order)
		{
            order.OrderTime = DateTime.Now;
            appDBContent.Order.Add(order);
            appDBContent.SaveChanges();
            var items = shopCart.ListShopItems;

            foreach(var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    CarId = el.Car.Id,
                    OrderId = order.Id,
                    Price = el.Car.price
                    
                };
                appDBContent.OrderDetails.Add(orderDetail);
            }

            appDBContent.SaveChanges();
		}
	}
}
