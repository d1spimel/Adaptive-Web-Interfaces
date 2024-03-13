using Lab7.Models; // Импорт пространства имен с моделями.

using Lab7.Services; // Импорт пространства имен с сервисами.
using Lab7.Services.Interfaces; // Импорт пространства имен с интерфейсами сервисов.
using Microsoft.OpenApi.Models; // Импорт пространства имен с моделями OpenAPI.

var builder = WebApplication.CreateBuilder(args); // Создание объекта builder для настройки веб-приложения.

builder.Services.AddControllers(); // Добавление контроллеров в коллекцию сервисов.

builder.Services.AddSingleton<IComputerComponentService, ComputerComponentService>(); // Добавление сервиса компонентов компьютера в коллекцию сервисов как синглтон.
builder.Services.AddSingleton<IComputerService, ComputerService>(); // Добавление сервиса компьютеров в коллекцию сервисов как синглтон.
builder.Services.AddSingleton<IDeviceService, DeviceService>(); // Добавление сервиса устройств в коллекцию сервисов как синглтон.

// Выбор синглтона обусловлен необходимостью общего использования данных между различными компонентами приложения
// и их единственным экземпляром на протяжении жизненного цикла приложения. Это обеспечивает глобальный доступ к данным,
// предотвращает избыточное создание экземпляров и упрощает управление зависимостями в приложении.

builder.Services.AddEndpointsApiExplorer(); // Добавление API Explorer для обработки конечных точек API.
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Computer WebAPI", Version = "v1" }); // Конфигурация Swagger с информацией о версии API.
});

var app = builder.Build(); // Построение приложения на основе настроек.

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) // Проверка, что приложение запущено в режиме разработки.
{
    app.UseDeveloperExceptionPage(); // Использование страницы отображения исключений для разработки.
    app.UseSwagger(); // Использование Swagger для генерации документации API.
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Computer WebAPI v1")); // Использование Swagger UI для визуализации документации API.
}

app.UseHttpsRedirection(); // Использование перенаправления HTTPS.
app.UseAuthorization(); // Использование авторизации.
app.MapControllers(); // Отображение контроллеров.
app.Run(); // Запуск приложения.
