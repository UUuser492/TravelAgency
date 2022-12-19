using Microsoft.EntityFrameworkCore;
using TravelAgencyApp;
using TravelAgency;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// получаем строку подключения из файла конфигурации
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// добавляем контекст TravelAgencyContext в качестве сервиса в приложение
builder.Services.AddDbContext<TravelAgencyContext>(options => options.UseSqlServer(connection));

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();




app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
