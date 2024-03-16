using Lab7.Services; // Import namespace with services.
using Lab7.Services.Interfaces; // Import namespace with service interfaces.
using Microsoft.OpenApi.Models; // Import namespace with OpenAPI models.

var builder = WebApplication.CreateBuilder(args); // Creating a builder object to configure the web application.

builder.Services.AddControllers(); // Adding controllers to the services collection.

builder.Services.AddSingleton<IComputerComponentService, ComputerComponentService>(); // Adding the computer component service to the services collection as a singleton.
builder.Services.AddSingleton<IComputerService, ComputerService>(); // Adding the computer service to the services collection as a singleton.
builder.Services.AddSingleton<IDeviceService, DeviceService>(); // Adding the device service to the services collection as a singleton.

// Choosing a singleton is due to the need for shared data between different components of the application
// and their single instance throughout the application lifecycle. This provides global access to data,
// prevents redundant instance creation, and simplifies dependency management in the application.

builder.Services.AddEndpointsApiExplorer(); // Adding API Explorer for handling API endpoints.
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Computer WebAPI", Version = "v1" }); // Configuring Swagger with API version information.
});

var app = builder.Build(); // Building the application based on the settings.

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) // Checking that the application is running in development mode.
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(options => {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Computer WebAPI v1");
    });
}

app.UseHttpsRedirection(); // Using HTTPS redirection.
app.UseAuthorization(); // Using authorization.
app.MapControllers(); // Mapping controllers.
app.Run(); // Running the application.
