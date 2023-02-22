using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// for swagger
builder.Services.AddEndpointsApiExplorer();
// for swagger
builder.Services.AddSwaggerGen(c => 
{
    c.SwaggerDoc("v1", new OpenApiInfo 
    {
        Title = "Jesus' SandBox API",
        Description = "Jesus' Sandbox Api with EfCore",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Jesus Hilario H.",
            Url = new Uri("https://jesushilarioh.com")
        }
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Jesus' SandBox API V1");
});

app.MapGet("/", () => "Hello World!");

app.Run();
