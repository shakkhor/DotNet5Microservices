using Discount.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discount.API.Repositories
{
    interface IDiscountRepository
    {
        Task<Coupon> GetDiscountByProductId(string productId);
        Task<bool> CreateDiscount(Coupon cupon);
        Task<bool> UpdateDiscount(Coupon cupon);
        Task<bool> DeleteDiscount(string productId);

    }
}
