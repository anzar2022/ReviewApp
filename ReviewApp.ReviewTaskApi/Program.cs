using Microsoft.EntityFrameworkCore;
using ReviewApp.Data;
using ReviewApp.IRepositories;
using ReviewApp.IServices;
using ReviewApp.Services;

var builder = WebApplication.CreateBuilder(args);

var configuratoin = builder.Configuration;

var connectionString = configuratoin.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ReviewAppDbContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("ReviewApp.ReviewTaskApi")));
builder.Services.AddControllers();

builder.Services.AddScoped<IQuarterService, QuarterService>();
builder.Services.AddScoped<IReviewTaskService, ReviewTaskService>();
builder.Services.AddScoped<IStatusService, StatusService>();


builder.Services.AddScoped<IQuarterRepository, IQuarterRepository>();
builder.Services.AddScoped<IReviewTaskRepository, IReviewTaskRepository>();
builder.Services.AddScoped<IStatusRepository, IStatusRepository>();


var app = builder.Build();
app.MapControllers();

app.MapGet("/", () => "Hello World!");
app.Run();
