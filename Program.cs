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

//dependency ýnjection // baðýmlýlýk enjeksiyonu
builder.Services.AddDbContext<NZWalksDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("NZWalksDbContext")));

//repository pattern'i kullanmak icin ýnject etmemiz gerekiyor. 
//bu satýr ile IRegionRepository interface'ini ve SqlRegionRepositories class'ýný enjekte eder.
builder.Services.AddScoped<IRegionRepository, SqlRegionRepositories>();
builder.Services.AddScoped<IWalkRepository, SqlWalkRepositories>();
//bu satýr farklý bir veritabanýna geçildiði seneryoda 2.repo olarak deðiþim kolaylýðýný göstermek için oluþturulmuþtur.
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
