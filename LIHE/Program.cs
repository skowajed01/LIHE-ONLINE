using LIHE.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LIHEDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("defalutConncetion"))
);
builder.Services.Configure<IdentityOptions>(options => {
    options.Password.RequiredLength = 6;
    //options.Password.RequireNonAlphanumeric = true;
    //options.Password.RequireDigit = true;
    //options.Password.RequiredUniqueChars = 1;
    //options.Password.RequireLowercase = true;
    //options.Password.RequireUppercase = true;
    //options.Lockout.MaxFailedAccessAttempts = 3;
    //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);

}
);
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
