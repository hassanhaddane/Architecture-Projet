using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using GestionHotel.Apis.Data;
using GestionHotel.Apis.Filters;
using GestionHotel.Apis.Persistence.Repositories;
using GestionHotel.Apis.Domain.Customers;
using GestionHotel.Apis.Domain.Rooms;
using GestionHotel.Apis.Services.Customer;
using GestionHotel.Apis.Services.Room;
using GestionHotel.Apis.Domain.Employees;
using GestionHotel.Apis.Services.Employee;
using GestionHotel.Apis.Domain.Bookings;
using GestionHotel.Apis.Services.Booking;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); // Ajoutez cette ligne pour enregistrer les contrôleurs
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

	// Ajoute la prise en charge de l'authentification JWT Bearer à Swagger
	c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
		Name = "Authorization",
		In = ParameterLocation.Header,
		Type = SecuritySchemeType.ApiKey,
		Scheme = "Bearer"
	});
	c.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddDbContext<HotelDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication(options =>
{
	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
	options.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true,
		ValidIssuer = "GestionHotel.Apis",
		ValidAudience = "GestionHotel.Apis",
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("iUBadurEM9JbL3dtjyGkUqeVjZeqT1G9"))
	};
});

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();

builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IRoomService, RoomService>();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<IBookingService, BookingService>();

// Spécifier les URL d'écoute
builder.WebHost.UseUrls("http://+:80");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "GestionHotel API V1");
	});
}

// app.UseHttpsRedirection(); // Commenter pour supprimer la redirection HTTPS

app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
	endpoints.MapControllers();
});

app.Run();
