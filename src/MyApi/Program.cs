var builder = WebApplication.CreateBuilder(args)

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/randomnumber", () =>
{
    var randomNumber = new RandomNumber
    {
        Number = new Random().Next(1, 100)
    };
    return randomNumber;
}
)
.WithName("RandomNumber")
.WithOpenApi();

app.Run();

record RandomNumber
{
    public int Number { get; init; }
};