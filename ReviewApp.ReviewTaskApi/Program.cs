using Microsoft.EntityFrameworkCore;
using ReviewApp.Data;

var builder = WebApplication.CreateBuilder(args);

var configuratoin = builder.Configuration;

var connectionString = configuratoin.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ReviewAppDbContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("ReviewApp.ReviewTaskApi")));
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();

app.MapGet("/", () => "Hello World!");
app.Run();
