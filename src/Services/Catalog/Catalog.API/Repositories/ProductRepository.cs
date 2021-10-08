using Catalog.API.Data;
using Catalog.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _catalogContext;

        public ProductRepository(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        public async Task CreateProduct(Product product)
        {
            await _catalogContext.Products.InsertOneAsync(product);
        }

        public async Task<bool> DeleteProductById(string id)
        {
            var deleteResult = await _catalogContext.Products.DeleteOneAsync(x => x.Id == id);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount>0;
        }

        public async Task<Product> GetProductById(string id)
        {
            return await _catalogContext
                                    .Products
                                    .Find(p => p.Id == id)
                                    .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _catalogContext
                                    .Products
                                    .Find(p => true)
                                    .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(string category)
        {
            return await _catalogContext
                                    .Products
                                    .Find(p => p.Category == category)
                                    .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByName(string name)
        {
            return await _catalogContext
                                    .Products
                                    .Find(p => p.Name == name)
                                    .ToListAsync();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var updateResult =  await _catalogContext
                                            .Products
                                            .ReplaceOneAsync(x => x.Id == product.Id,  product);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
