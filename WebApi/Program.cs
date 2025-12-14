using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebApi.Contexts;
using WebApi.Interfaces.Repositories;
using WebApi.Interfaces.Services;
using WebApi.Repositories;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// ================== SERVICES (Servis Kayıtları) ==================

// 1. Controller Servisleri
builder.Services.AddControllers();

// 3. DbContext (Veritabanı Bağlantısı)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("sqLite")));

// 4. Dependency Injection (Bağımlılıklar)
builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
builder.Services.AddScoped<IMusicService, MusicService>();

// 2. Swagger Servisleri
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Music API",
        Version = "v1"
    });
});

var app = builder.Build();

// ================== MIDDLEWARE (İstek İşleme Sırası) ==================

// ÖNEMLİ: Swagger ayarları HttpsRedirection ve Authorization'dan ÖNCE gelmeli.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Music API v1");
    });
}

// HTTPS Yönlendirmesi
app.UseHttpsRedirection();

app.UseAuthentication();
// Yetkilendirme (Eğer Authentication varsa onun hemen altına gelmeli)
app.UseAuthorization();

// Controller Rotaları
app.MapControllers();

app.Run();