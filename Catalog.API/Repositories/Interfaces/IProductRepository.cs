using Catalog.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();

        Task<Product> GetProduct(string Id);

        Task<IEnumerable<Product>> GetProductsByName(string Name);

        Task<IEnumerable<Product>> GetProductsByCategory(string Category);

        Task Create(Product prod);

        Task<bool> Update(Product Prod);

        Task<bool> Delete(string Id);
    }
}
