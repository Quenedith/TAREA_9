using Microsoft.EntityFrameworkCore;
using TodoApi.models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
 string? cadenaSql = builder.Configuration.GetConnectionString("cnSqlServer")  ?? ("otracadena");

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<Conexiones>(opt =>
    opt.UseMySQL(cadenaSql));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseSwaggerUi(options =>
    {
        options.DocumentPath = "/openapi/v1.json";
    });
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
