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
        "https://globecalls.com/wp-content/uploads/2021/03/Screenshot_20210319-135136.png",
        "https://www.networthdiscover.com/images/profiles/kanye-west-net-worth.jpg",
        "https://th.bing.com/th/id/R.707da67d4bced113336796a63c6bcca4?rik=v4cI8dfxrMaY0g&riu=http%3a%2f%2fpixel.nymag.com%2fimgs%2fdaily%2fvulture%2f2015%2f02%2f20%2f20-kanye-west.w529.h529.jpg&ehk=y3q%2fYNo5Cf79njG3xLlmvlUSKzrDx6IOWhMI7z9qZR0%3d&risl=&pid=ImgRaw&r=0",
        "https://1622179098.rsc.cdn77.org/data/thumbs/full/55127/650/0/0/0/kanye-west-hot-new-swish-album-release-news-update-2015.jpg",
        "https://img.buzzfeed.com/buzzfeed-static/static/2015-03/9/14/enhanced/webdr06/original-13446-1425925949-3.jpg",
        "https://th.bing.com/th/id/OIP.Xa32c1u-KKpqOTnF6YLldAHaHa?w=2000&h=2000&rs=1&pid=ImgDetMain",
        "https://media1.popsugar-assets.com/files/thumbor/gDEVJlje22pDAqm10vjObBBoCc4/fit-in/1024x1024/filters:format_auto-!!-:strip_icc-!!-/2018/08/29/753/n/1922564/0caeb1945b86d22b3beb60.35931641_/i/Kanye-West-Glow-Dark-Yeezys.jpg",
        "https://pyxis.nymag.com/v1/imgs/4cf/4c8/48cefe92ebc0ad3539e34c8001fdd20e93-13-kanye-shia.rsquare.w400.jpg",
        "https://th.bing.com/th/id/OIP.-rwQw7SLi4N9wA5XRUg0LgHaFk?w=750&h=564&rs=1&pid=ImgDetMain",
        "https://www.yournextshoes.com/wp-content/uploads/2015/03/Kanye-West-Thinking-Hard.jpg",
        "https://th.bing.com/th/id/OIP.dXOt5he1VGH_KZoX-lLzVQHaLE?w=660&h=986&rs=1&pid=ImgDetMain",
        "https://static.toiimg.com/thumb/imgsize-23456,msid-44888416,width-600,resizemode-4/44888416.jpg",
        "https://th.bing.com/th/id/OIP.akwxGicLW1TZRkucCaBJJQHaLH?w=960&h=1441&rs=1&pid=ImgDetMain",
        "https://cdn.images.express.co.uk/img/dynamic/79/590x/407747_1.jpg?r=1686998680160",
        "https://th.bing.com/th/id/OIP.ZxLZponncI5ugbS-eFb8XgHaGM?pid=ImgDet&w=205&h=171&c=7&dpr=1.5",
        "https://th.bing.com/th/id/OIP.7VVigpSUN33VMijiQx9fOAHaLH?pid=ImgDet&w=204&h=306&c=7&dpr=1.5",
        "https://th.bing.com/th/id/OIP.8upyJC_BgO1kTCV-grIpwAHaEK?pid=ImgDet&w=205&h=115&c=7&dpr=1.5",
        "https://th.bing.com/th/id/OIP.OGbxMUUqK-dTNHbGf_ZRcgHaFj?w=264&h=198&c=7&r=0&o=5&dpr=1.5&pid=1.7",
        "https://th.bing.com/th/id/OIP.DmMLUwPC-Gzu2A2lAZzWOwHaFK?w=247&h=180&c=7&r=0&o=5&dpr=1.5&pid=1.7",
        "https://th.bing.com/th/id/OIP.sosYRFKwWNd66zTUeXK5qAHaKW?w=114&h=180&c=7&r=0&o=5&dpr=1.5&pid=1.7",
        "https://th.bing.com/th/id/OIP.IpDr1-2EVu9LdcqReTtaHAHaE7?w=298&h=199&c=7&r=0&o=5&dpr=1.5&pid=1.7",
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
