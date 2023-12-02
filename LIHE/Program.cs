using LIHE.Data;
using LIHE.Mappings;
using LIHE.Repositories;
using LIHE.Repositories.IRepositoty;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICountryMastRepository, CountryMastRepository>();
builder.Services.AddScoped<IDepartmentmastRepository, DepartmentMastRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
builder.Services.AddDbContext<LIHEDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("defalutConncetion"))
);
builder.Services.AddIdentityCore<IdentityUser>().AddRoles<IdentityRole>().
	AddEntityFrameworkStores<LIHEDbContext>().
	AddDefaultTokenProviders();
builder.Services.Configure<IdentityOptions>(option =>
{
	option.Password.RequireDigit = false;
	option.Password.RequireLowercase = false;
	option.Password.RequireUppercase = false;
	option.Password.RequireNonAlphanumeric = false;
	option.Password.RequiredLength = 6;
	option.Password.RequiredUniqueChars = 1;

});
builder.Services.AddAuthentication();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors();
app.UseCors(builder =>
{
	builder
	.AllowAnyOrigin()
	.AllowAnyMethod()
	.AllowAnyHeader();
});
app.MapControllers();

app.Run();
