using Marathon_backend.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add Swagger/OpenAPI services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure database context
var connectionString = builder.Configuration.GetConnectionString("ConnectionString");
builder.Services.AddDbContext<UserDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();
app.UseRouting();
// Configure endpoints
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

// Configure Swagger/OpenAPI
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});
