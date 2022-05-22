using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FreeCourse.Services.Catalog.Models
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } //String olarak gönderdiğimiz şeyi ObjectId ye dönüştürecek.
        public string Name { get; set; }
    }
}
