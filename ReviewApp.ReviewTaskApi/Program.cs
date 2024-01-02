using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ReviewApp.Data;
using ReviewApp.IRepositories;
using ReviewApp.IServices;
using ReviewApp.Model;
using ReviewApp.Repositories;
using ReviewApp.ReviewTaskApi;
using ReviewApp.Services;

var builder = WebApplication.CreateBuilder(args);

var configuratoin = builder.Configuration;

var connectionString = configuratoin.GetConnectionString("DefaultConnection");
var jwtSettingsSection = configuratoin.GetSection("JwtSettings");

builder.Services.Configure<JwtSettings>(jwtSettingsSection);

builder.Services.AddDbContext<ReviewAppDbContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("ReviewApp.ReviewTaskApi")));
builder.Services.AddControllers();

builder.Services.AddScoped<IQuarterService, QuarterService>();
builder.Services.AddScoped<IReviewTaskService, ReviewTaskService>();
builder.Services.AddScoped<IStatusService, StatusService>();


builder.Services.AddScoped<IQuarterRepository, QuarterRepository>();
builder.Services.AddScoped<IReviewTaskRepository, ReviewTaskRepository>();
builder.Services.AddScoped<IStatusRepository, StatusRepository>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddSingleton(provider => provider.GetRequiredService<IOptions<JwtSettings>>().Value);
//builder.Services.AddScoped<JwtSettings>();

//builder.Services.AddScoped<IJwtService, JwtService>();


builder.Services.Configure<RouteOptions>(options =>
{
    options.ConstraintMap.Add("DateOnly", typeof(DateOnlyRouteConstraint));
});

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
app.UseCors("EnableCORS");
app.MapGet("/", () => "Hello World!");
app.Run();
