using apiproject.Controllers;
using apiproject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ShopContext>(options => options.UseInMemoryDatabase("Shop"));
builder.Services.AddDbContext<ArticleContext>(options => options.UseInMemoryDatabase("Article"));
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();


var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

// firstnames
var firstnames = new[]
{
    "John", "Jane", "Jack", "Jill", "Joe", "Jenny", "Jeff", "Jen", "Jesse", "Jade"
};
var lastnames = new[]
{
    "Smith", "Jones", "Williams", "Taylor", "Brown", "Davies", "Evans", "Wilson", "Thomas", "Roberts"
};
var emails = new[]
{
    "abc@gmail.com", "abc@yahoo.com", "abc@outlook.com",
    "abc1@gmail.com", "abc11@yahoo.com", "abc1@outlook.com",
    "abcd11@gmail.com", "abcd11@yahoo.com", "abcd31@outlook.com",
    "ramukaka@outlook.com"
};

app.MapGet("/users", () =>
{
    var users =  Enumerable.Range(1, 5).Select(index =>
        new User
        (
            firstnames[Random.Shared.Next(firstnames.Length)],
            lastnames[Random.Shared.Next(lastnames.Length)],
            emails[Random.Shared.Next(emails.Length)]
        ))
        .ToArray();
    return users;
});




app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

record User(string FirstName, string LastName, string Email);