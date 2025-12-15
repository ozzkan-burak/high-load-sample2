using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Product.API.Models;

namespace Product.API.Services;

public class ProductService
{
  private readonly IMongoCollection<Models.Product> _productsCollection;

  public ProductService(IConfiguration configuration)
  {
    var mongoClient = new MongoClient(configuration.GetValue<string>("MongoDbSettings:ConnectionString"));
    var mongoDatabase = mongoClient.GetDatabase(configuration.GetValue<string>("MongoDbSettings:DatabaseName"));
    _productsCollection = mongoDatabase.GetCollection<Models.Product>(
      configuration.GetValue<string>("MongoDbSettings:CollectionName")
    );
  }  
    // Tüm ürünleri getirir
    public async Task<List<Models.Product>> GetAsync() => await _productsCollection.Find(_ => true).ToListAsync();
    // Id'ye göre ürün getirir
    public async Task<Models.Product?> GetAsync(string id) => await _productsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    // Yeni ürün oluşturur
    public async Task CreateAsync(Models.Product newProduct) => await _productsCollection.InsertOneAsync(newProduct);
    // Güncelle
    public async Task UpdateAsync(string id, Models.  Product updatedProduct) => await _productsCollection.ReplaceOneAsync(x => x.Id == id, updatedProduct);
    // Sil
    public async Task RemoveAsynce(string id) => await _productsCollection.DeleteOneAsync(x => x.Id == id);
}