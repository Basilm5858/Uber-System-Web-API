using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Uber_Ride_Booking_System.Data;
using Uber_Ride_Booking_System.Mapper;
using Uber_Ride_Booking_System.Repos.Impelementation;
using Uber_Ride_Booking_System.Repos.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(
    x => x.AddProfile<MappingProfile>());


builder.Services.AddDbContext<My_AppContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("conn"))
    );

builder.Services.AddScoped<IVehicle, VehicleCustomRepo>();
builder.Services.AddScoped<IRideRepo, RideCustomRepo>();
builder.Services.AddScoped<IRating, RatingCustomRepo>();
builder.Services.AddScoped<IPayment, PaymentCustomRepo>(); 
builder.Services.AddScoped<IAuthRepo, AuthRepoCustomRepo>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("AllowFrontend", policy =>
    {
        policy.AllowAnyHeader()
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
    });
});

var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]));

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(x =>
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Iss"],

        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Aud"],

        ValidateIssuerSigningKey = true,
        IssuerSigningKey = key
    });

var app = builder.Build();

app.UseCors("AllowFrontend");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
