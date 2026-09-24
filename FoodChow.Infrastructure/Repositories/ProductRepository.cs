using FoodChow.Application.Interfaces;
using FoodChow.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodChow.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Pizza", Price = 250 },
                new Product { Id = 2, Name = "Burger", Price = 120 }
            };

            return await Task.FromResult(products);
        }
    }
}