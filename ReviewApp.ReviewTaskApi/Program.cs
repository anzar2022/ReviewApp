using Microsoft.EntityFrameworkCore;
using ReviewApp.Data;
using ReviewApp.IRepositories;
using ReviewApp.IServices;
using ReviewApp.Repositories;
using ReviewApp.Services;

var builder = WebApplication.CreateBuilder(args);

var configuratoin = builder.Configuration;

var connectionString = configuratoin.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ReviewAppDbContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("ReviewApp.ReviewTaskApi")));
builder.Services.AddControllers();

builder.Services.AddScoped<IQuarterService, QuarterService>();
builder.Services.AddScoped<IReviewTaskService, ReviewTaskService>();
builder.Services.AddScoped<IStatusService, StatusService>();


builder.Services.AddScoped<IQuarterRepository, QuarterRepository>();
builder.Services.AddScoped<IReviewTaskRepository, ReviewTaskRepository>();
builder.Services.AddScoped<IStatusRepository, StatusRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("EnableCORS", builder =>
    {
        builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
    });
});

var app = builder.Build();
app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.UseCors("EnableCORS");

app.Run();
