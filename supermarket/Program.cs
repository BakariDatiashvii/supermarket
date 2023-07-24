using Microsoft.EntityFrameworkCore;
using supermarket.DBcontext;
using supermarket.ProductServise;
using supermarket.SupermarketServise;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ISupermarketServise, SupermarketServise>();  
builder.Services.AddScoped<IProductServise, ProductServise>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SupermarketProductDBcontext>(option =>
{
    option.UseSqlServer(@"Server=DESKTOP-MRACR18\SQLEXPRESS01;Database=SUPERMARKETI;Trusted_Connection=True;TrustServerCertificate=True;");
});
builder.Services.AddAutoMapper(typeof(Program).Assembly);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
