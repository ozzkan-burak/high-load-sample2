using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Product.API.Models;

public class Product
{
  [BsonId]
  [BsonRepresentation(BsonType.ObjectId)]
  public string? Id { get; set; }

  [BsonElement("Name")]
  public string? Name {get; set;} = null!;
  public string Category {get; set;} = null!;
  public string Description {get; set;} = null!;
  public decimal Price {get; set;}
  public string PictureUr {get; set;}
  public DateTime CreateAt {get; set;} = DateTime.UtcNow;

}