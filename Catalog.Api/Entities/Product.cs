using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Api.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }

        [BsonElement("Name")]
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }

        public Product() {}
        public Product(string id, string name, string category, string description, string image, decimal price)
        {
            Id = id;
            Name = name;
            Category = category;
            Description = description;
            Image = image;
            Price = price;
        }

        public void SetId(string id) => Id = id;
        


    }
}
