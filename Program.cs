var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddHttpLogging();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapControllers();
app.UseHttpLogging();
app.Run();
