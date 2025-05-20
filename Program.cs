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

List<Category> categories = new List<Category>();
//Configure the HTTP request pipeline.
app.MapGet("/", () =>
{
    return "Hello World!";
});
app.MapGet("api/categories", () =>
{
    return Results.Ok(categories);
});
app.MapPost("api/categories", () =>
{
   // return ("categories");
    var newCategory = new Category
    {
        CategoryId = Guid.NewGuid(),
        Name = "New Category",
        Description = "This is a new category.",
        CreatedAt = DateTime.UtcNow
    };
    categories.Add(newCategory);
    return Results.Created($"/api/categories/{newCategory.CategoryId}", newCategory);
});
app.MapPut("api/categories", () =>
{

});
app.MapDelete("api/categories", () =>
{
    //return ("categories");
    var categoryId = Guid.NewGuid();
    var category = categories.FirstOrDefault(c => c.CategoryId == categoryId);
    if (category == null)
    {
        return Results.NotFound();
    }
    categories.Remove(category);
    return Results.NoContent();
});


app.Run();

public record Category
{
    public Guid CategoryId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
}
