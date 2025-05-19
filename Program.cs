using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Configure the HTTP request pipeline.
app.MapGet("/", () =>
{
    return "Hello World!";
});
app.MapGet("/hello", () =>
{
    // This is a simple GET method
    var response = new
    {
        Message = "I am a GET method",
        Date = DateTime.Now
    };
   return Results.Ok(response);
});
app.MapPost("/hello", () =>
{
    return Results.Created("/hello", "I am a POST method");
});
app.MapPut("/hello", () =>
{
    return Results.NoContent();
});
app.MapDelete("/hello", () =>
{
    return Results.NoContent();
});

app.Run();

