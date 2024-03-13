using Lab7.Models; // ������ ������������ ���� � ��������.

using Lab7.Services; // ������ ������������ ���� � ���������.
using Lab7.Services.Interfaces; // ������ ������������ ���� � ������������ ��������.
using Microsoft.OpenApi.Models; // ������ ������������ ���� � �������� OpenAPI.

var builder = WebApplication.CreateBuilder(args); // �������� ������� builder ��� ��������� ���-����������.

builder.Services.AddControllers(); // ���������� ������������ � ��������� ��������.

builder.Services.AddSingleton<IComputerComponentService, ComputerComponentService>(); // ���������� ������� ����������� ���������� � ��������� �������� ��� ��������.
builder.Services.AddSingleton<IComputerService, ComputerService>(); // ���������� ������� ����������� � ��������� �������� ��� ��������.
builder.Services.AddSingleton<IDeviceService, DeviceService>(); // ���������� ������� ��������� � ��������� �������� ��� ��������.

// ����� ��������� ���������� �������������� ������ ������������� ������ ����� ���������� ������������ ����������
// � �� ������������ ����������� �� ���������� ���������� ����� ����������. ��� ������������ ���������� ������ � ������,
// ������������� ���������� �������� ����������� � �������� ���������� ������������� � ����������.

builder.Services.AddEndpointsApiExplorer(); // ���������� API Explorer ��� ��������� �������� ����� API.
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Computer WebAPI", Version = "v1" }); // ������������ Swagger � ����������� � ������ API.
});

var app = builder.Build(); // ���������� ���������� �� ������ ��������.

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) // ��������, ��� ���������� �������� � ������ ����������.
{
    app.UseDeveloperExceptionPage(); // ������������� �������� ����������� ���������� ��� ����������.
    app.UseSwagger(); // ������������� Swagger ��� ��������� ������������ API.
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Computer WebAPI v1")); // ������������� Swagger UI ��� ������������ ������������ API.
}

app.UseHttpsRedirection(); // ������������� ��������������� HTTPS.
app.UseAuthorization(); // ������������� �����������.
app.MapControllers(); // ����������� ������������.
app.Run(); // ������ ����������.
