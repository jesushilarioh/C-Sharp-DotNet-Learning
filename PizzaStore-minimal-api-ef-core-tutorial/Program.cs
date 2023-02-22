using Microsoft.OpenApi.Models; // For swagger
using Microsoft.EntityFrameworkCore;
using PizzaStore.Models; // For EfCore, In-memory database

var builder = WebApplication.CreateBuilder(args);

// Add a database connection string
/*
    The following code checks the configuration provider 
    for a connection string named "Pizzas". If none is
    found, it will use "Data Source=Pizzas.db" as the
    connection string. SQLite will map this string
    to a file.
*/
var connectionString = builder.Configuration.GetConnectionString("Pizzas") ?? "Data Source=Pizzas.db";

// For swagger
builder.Services.AddEndpointsApiExplorer();
// For Ef Core, In-memory database
// builder.Services.AddDbContext<PizzaDb>(options => options.UseInMemoryDatabase("items"));

// SQLite implimentation 
builder.Services.AddSqlite<PizzaDb>(connectionString);

// For swagger
builder.Services.AddSwaggerGen(c => 
{
    c.SwaggerDoc("v1", new OpenApiInfo {
        Title = "PizzaStore API",
        Description = "Making Pizzas you might like!",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Jesus Hernandez",
            Url = new Uri("https://jesushilarioh.com")
        }
    });
});

var app = builder.Build();

// For swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaStore API V1");
});


app.MapGet("/", () => "Hello World!");
// Read from a list of items in PizzaDb, Pizzas
app.MapGet("/pizzas", async (PizzaDb db) => await db.Pizzas.ToListAsync());
// Create new items in the PizzaDb
app.MapPost("/pizza", async (PizzaDb db, Pizza pizza) =>
{
    await db.Pizzas.AddAsync(pizza); // add new pizza asyncronously
    await db.SaveChangesAsync();     // Save changes asyncronously

    // Return status code of 201
    return Results.Created($"/pizza/{pizza.Id}", pizza); 
});
// Get item by id
app.MapGet("/pizzas/{id}", async (PizzaDb db, int id) => await db.Pizzas.FindAsync(id));
// Update an exisiting item 
app.MapPut("/pizza/{id}", async (PizzaDb db, Pizza updatepizza, int id) => 
{
    var pizza = await db.Pizzas.FindAsync(id);
    if (pizza is null) return Results.NotFound();
    
    pizza.Name = updatepizza.Name;
    pizza.Description = updatepizza.Description;

    await db.SaveChangesAsync();
    return Results.NoContent();
});

// Delete an existing item
app.MapDelete("/pizza/{id}", async (PizzaDb db, int id) =>
{
    var pizza = await db.Pizzas.FindAsync(id); 
    if (pizza is null)
    {
        return Results.NotFound();
    }

    db.Pizzas.Remove(pizza);
    await db.SaveChangesAsync();
    return Results.Ok();
});


app.Run();
