using Catalog.API.Data.Interfaces;
using Catalog.API.Entities;
using Catalog.API.Repositories.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Threading.Tasks;

namespace Catalog.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _catalogContext;
        public ProductRepository(ICatalogContext context)
        {
            _catalogContext = context;
        }
        public async Task Create(Product prod)
        {
            await _catalogContext.Products.InsertOneAsync(prod);
        }

        public async Task<bool> Delete(string Id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.ElemMatch(p => p.Id, Id);
            var DeletedResult = await _catalogContext.Products.DeleteOneAsync(filter);
            return DeletedResult.IsAcknowledged && DeletedResult.DeletedCount > 0;
        }

        public async Task<Product> GetProduct(string Id)
        {
            return await _catalogContext.Products.Find(p => p.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _catalogContext.Products.Find(p => true).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(string Category)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.ElemMatch(p => p.Category, Category);
            return await _catalogContext.Products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByName(string Name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.ElemMatch(p => p.Name, Name);
            return await _catalogContext.Products.Find(filter).ToListAsync();
        }

        public async Task<bool> Update(Product Prod)
        {
            var updateResult = await _catalogContext.Products.ReplaceOneAsync(g => g.Id == Prod.Id, Prod);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
