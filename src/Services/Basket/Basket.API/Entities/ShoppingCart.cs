﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Entities
{
    public class ShoppingCart
    {
        public string UserName { get; set; }
        public string UserId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();

        public ShoppingCart()
        {

        }

        public ShoppingCart(string userName)
        {
            this.UserName = userName;
        }

        public decimal TotalPrice
        {
            get
            {
                return ShoppingCartItems.Sum(x => x.Price);
            }
        }
    }
}
