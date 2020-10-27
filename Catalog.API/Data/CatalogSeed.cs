using Catalog.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Data
{
    public class CatalogSeed

    {
        public static void SeedData(IMongoCollection<Product> ProductCollection)
        {
            bool existProduct = ProductCollection.Find(p => true).Any();

            if (existProduct)
            {
                ProductCollection.InsertManyAsync(GetPreConfiguredProducts());
            }
             
        }
        public static IEnumerable<Product> GetPreConfiguredProducts()
        {
            return new List<Product>()
            {  new Product()
                {
                    Category="",
                    Name=""

                }
            };
        }
    }
}
