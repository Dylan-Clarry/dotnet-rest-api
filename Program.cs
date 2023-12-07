using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Db>(opt => opt.UseInMemoryDatabase("ProductList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/products", async (Db db) =>
    await db.Products.ToListAsync());

app.MapGet("/products/{id}", async (int id, Db db) =>
    await db.Products.FindAsync(id)
        is Product todo
            ? Results.Ok(todo)
            : Results.NotFound());

app.MapPost("/products", async (Product todo, Db db) => {
    db.Products.Add(todo);
    await db.SaveChangesAsync();

    return Results.Created($"/products/{todo.Id}", todo);
});

app.MapPut("/products/{id}", async (int id, Product inputProduct, Db db) => {
    var product = await db.Products.FindAsync(id);
    if(product is null) return Results.NotFound();
    product.Name = inputProduct.Name;
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/products/{id}", async (int id, Db db) => {
    if(await db.Products.FindAsync(id) is Product todo)
    {
        db.Products.Remove(todo);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});

app.Run();
