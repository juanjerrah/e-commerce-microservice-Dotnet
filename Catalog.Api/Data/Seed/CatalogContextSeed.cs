using Catalog.Api.Entities;
using MongoDB.Driver;

namespace Catalog.Api.Data.Seed
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            var hasProduct = productCollection.Find(p => true).Any();

            if (!hasProduct)
            {
                productCollection.InsertManyAsync(GetMyProducts());
            }
        }

        public static IEnumerable<Product> GetMyProducts()
        {
            return new[]
            {
                new Product()
                {
                    Id = "6483bea3ebdc429f09f9095c",
                    Name = "Iphone X",
                    Description = "Descrição legal do iphone X aqui",
                    Image = "url-img1.png",
                    Price = 5200.0M,
                    Category = "Smartphone"
                },
                new Product()
                {
                    Id = "6483bfa24fc51313b88db1a6",
                    Name = "Tv samsung 65",
                    Description = "Descrição legal da tv samsung 65 aqui",
                    Image = "url-img2.png",
                    Price = 3500.25M,
                    Category = "eletrodomésticos"
                },
                new Product()
                {
                    Id = "6483bfb58693b4e4fe281f39",
                    Name = "Geladeira eletrolux",
                    Description = "Descrição legal da Geladeira eletrolux aqui",
                    Image = "url-img3.png",
                    Price = 8735.90M,
                    Category = "eletrodomésticos"
                },
            };
        }
    }
}
