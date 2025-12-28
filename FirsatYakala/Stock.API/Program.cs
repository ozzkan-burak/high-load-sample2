using Microsoft.EntityFrameworkCore;
using Stock.API.Data;
var builder = WebApplication.CreateBuilder(args);

// --- EF CORE AYARI ---
builder.Services.AddDbContext<StockDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"));
});
// --------------------

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// --- OTOMATİK MIGRATION (Geliştirme Ortamı İçin) ---
// Uygulama her başladığında veritabanı yoksa oluşturur.
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<StockDbContext>();
    db.Database.Migrate();
}
// ---------------------------------------------------

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();
app.Run();
