using LR5;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddSingleton<HttpClientWrapper>();

// Swagger/OpenAPI configuration
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddSwaggerGen();
}

// Endpoint routing configuration
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
