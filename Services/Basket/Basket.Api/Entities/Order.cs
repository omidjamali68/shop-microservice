﻿namespace Basket.Api.Entities
{
    public class Order
    {
        public string UserName { get; set; }
        public List<OrderItem> Items { get; set; }
        public decimal TotalPrice { 
            get 
            { 
                decimal total = 0;
                foreach(var item in  Items)
                {
                    total+= item.Price * item.Quantity;
                }
                return total;
            } 
        }
    }
}