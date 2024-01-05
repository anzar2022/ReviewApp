using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ReviewApp.Data;
using ReviewApp.IRepositories;
using ReviewApp.IServices;
using ReviewApp.Model;
using ReviewApp.Repositories;
using ReviewApp.ReviewTaskApi;
using ReviewApp.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var configuratoin = builder.Configuration;

var connectionString = configuratoin.GetConnectionString("DefaultConnection");
var jwtSettingsSection = configuratoin.GetSection("JwtSettings");

builder.Services.Configure<JwtSettings>(jwtSettingsSection);

builder.Services.AddDbContext<ReviewAppDbContext>(options =>
{
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("ReviewApp.ReviewTaskApi"));
    options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
    options.EnableSensitiveDataLogging();
});

/*Test*/


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
var jwtSettings = builder.Services.BuildServiceProvider().GetRequiredService<IOptions<JwtSettings>>().Value;
var SecretKey = Encoding.ASCII.GetBytes(jwtSettings.SecretKey);
//builder.Services.AddScoped<JwtSettings>();

//builder.Services.AddScoped<IJwtService, JwtService>();


builder.Services.Configure<RouteOptions>(options =>
{
    options.ConstraintMap.Add("DateOnly", typeof(DateOnlyRouteConstraint));
});


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{

    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {

        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(SecretKey),
        ValidateIssuer = false,
        ValidateAudience = false
    };

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
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("EnableCORS");
app.MapControllers();
app.MapGet("/", () => "Hello World!");
app.Run();
