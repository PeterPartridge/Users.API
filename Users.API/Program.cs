using Microsoft.EntityFrameworkCore;
using Users.Domain.Interfaces;
using Users.Infrastructure;
using Users.Infrastructure.DataService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UserDataContext>(options => options.UseInMemoryDatabase("User"));
builder.Services.AddScoped<IUserDataService, UserDataService>();
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
if (app.Environment.IsDevelopment())
{
    var context = app.Services.CreateScope().ServiceProvider.GetService<UserDataContext>();
    SeedData.SeedUsers(context);
}
app.Run();
