using Microsoft.OpenApi.Models; // For SwaggerDoc 2nd Parameter
using minimalApiExample1.DB;

// Initializes a new instance of the WebApplicationBuilder class with preconfigured defaults
// Returns the WebApplicationBuilder
// WebApplicationBuilder = a builder for web applications and services
var builder = WebApplication.CreateBuilder(args);

// Configures ApiExplorer using Metadata 
// Services = a collection of services for the application to compose. This is useful for adding user provided or framework provided services.
builder.Services.AddEndpointsApiExplorer();

// Builds SwaggerDocument objects directly from routes, controllers, and models
// Typically combined with Swagger endpoint middleware to auto expose Swagger JSON
builder.Services.AddSwaggerGen(c => 
{
    c.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "Minimal API Tutorial API", 
        Description = "Making the API you could love", 
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Jesus Hilario Hernandez",
            Url = new Uri("https://jesushilarioh.com")
        }
    });
});

var app = builder.Build();

// Enables middleware for serving the generated JSON document and the Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "minimal api tutorial 1 API V1");
    });
}


app.MapGet("/", () => "Hello World!");
app.MapGet("/users", () => UserDB.GetUsers());
app.MapGet("/users/{id}", (int id) => UserDB.GetUser(id));
app.MapPost("/users", (User user) => UserDB.CreateUser(user));
app.MapPut("/users", (User user) => UserDB.UpdateUser(user));
app.MapDelete("/users/{id}", (int id) => UserDB.RemoveUser(id));

app.Run();






