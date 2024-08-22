using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();

// Define the random number endpoint
app.MapGet("/randomnumber", () =>
{
    var randomNumber = new RandomNumber
    {
        Number = new Random().Next(1, 100)
    };
    return randomNumber;
})
.WithName("RandomNumber")
.WithOpenApi();

// Define the endpoint for a random Kanye West picture
app.MapGet("/kanye-picture", () =>
{
    var kanyePictures = new[]
    {
        "https://image.tmdb.org/t/p/original/aiLF9OBQ7LcglmAg0pXjyonGwye.jpg",
        "https://fashionbombdaily.com/wp-content/uploads/2016/06/kanye-west-famous-700x933.jpeg",
        "https://i.pinimg.com/736x/5c/e7/c8/5ce7c862fc0991d0c12e707924df2d8e.jpg",
        "https://th.bing.com/th/id/OIP.Z_45PqQulvQoPH6Y-Hb9NgAAAA?w=381&h=381&rs=1&pid=ImgDetMain",
        "https://globecalls.com/wp-content/uploads/2021/03/Screenshot_20210319-135136.png"
    };
    
    var random = new Random();
    var randomIndex = random.Next(kanyePictures.Length);
    var selectedPictureUrl = kanyePictures[randomIndex];
    
    return Results.Json(new { Url = selectedPictureUrl });
})
.WithName("KanyePicture")
.WithOpenApi();

app.Run();

record RandomNumber
{
    public int Number { get; init; }
}

record KanyePicture
{
    public string Url { get; init; }
}
