using API.Controllers;
using Domain.Abstractions.Repositories;
using Domain.Abstractions.Services;
using Infrastructure.AutoMapper;
using Infrastructure.DataAccess.DbContext;
using Infrastructure.DataAccess.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Настройка Cross-Origin Resource Sharing для фронтенда
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:5174")
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Добавление контроллеров и AutoMapper
builder.Services.AddControllers().AddApplicationPart(typeof(OrdersController).Assembly);
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Конфигурация базы данных
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Регистрация сервисов и репозиториев
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

// Добавление Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Настройки для разработки
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));
}

// Базовые настройки HTTP
app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigin"); 

// Настройка маршрутизации
app.UseRouting();

// Определение конечных точек
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

// Миграция базы данных
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

// Запуск приложения
app.Run();