using Dapper;
using Discount.API.Entities;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discount.API.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IConfiguration _configuration;
        public DiscountRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public async Task<bool> CreateDiscount(Coupon cupon)
        {
            using var connection = new NpgsqlConnection
                (_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>
                ("SELECT * FROM Coupon WHERE ProductId = @ProductId", new {ProductId = productId } );
        }

        public Task<bool> DeleteDiscount(string productId)
        {
            throw new NotImplementedException();
        }

        public async Task<Coupon> GetDiscountByProductId(string productId)
        {
            using var connection = new NpgsqlConnection
                (_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>
                ("SELECT * FROM Coupon WHERE ProductId = @ProductId", new { ProductId = productId });

            if(coupon==null)
            {
                new Coupon
                { Amount = 0, Description = "NO discount", ProductId = productId, ProductName = "Not available" };
            }

            return coupon;
        }

        public Task<bool> UpdateDiscount(Coupon cupon)
        {
            throw new NotImplementedException();
        }
    }
}
