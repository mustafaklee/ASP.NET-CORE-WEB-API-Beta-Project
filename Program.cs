using Microsoft.EntityFrameworkCore;
using MyFirstApiProject.Mappings;
using MyFirstApiProject.Repositories;
using MyFirstApiProjects.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//dependency �njection // ba��ml�l�k enjeksiyonu
builder.Services.AddDbContext<NZWalksDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("NZWalksDbContext")));

//repository pattern'i kullanmak icin �nject etmemiz gerekiyor. 
//bu sat�r ile IRegionRepository interface'ini ve SqlRegionRepositories class'�n� enjekte eder.
builder.Services.AddScoped<IRegionRepository, SqlRegionRepositories>();
builder.Services.AddScoped<IWalkRepository, SqlWalkRepositories>();
//bu sat�r farkl� bir veritaban�na ge�ildi�i seneryoda 2.repo olarak de�i�im kolayl���n� g�stermek i�in olu�turulmu�tur.
//builder.Services.AddScoped<IRegionRepository, InMemoryRegionRepository>();

//AutoMapper i programa enjekte etmemiz gerekiyor.
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));


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
