﻿using Basket.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Repositories
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetShoppingCart(string userId);
        Task<ShoppingCart> UpdateShoppingCart(ShoppingCart shoppingCart);
        Task EmptyCart(string userId);
    }
}
