using Microsoft.EntityFrameworkCore;
using TreePlant.Database.DatabaseContext;
using TreePlant.Domain.RepositoryInterfaces;
using TreePlant.Domain.ServiceInterfaces;
using TreePlant.Repositories.AutoMapper;
using TreePlant.Repositories.Repositories;
using TreePlant.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextFactory<AppDbContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("TreePlantConnection")));

/// Adding repositories to the container.
builder.Services.AddScoped<IAreaRepository, AreaRepository>();
builder.Services.AddScoped<ITreePlantRepository, TreePlantRepository>();
builder.Services.AddScoped<ITreeSortRepository, TreeSortRepository>();

/// Adding services to the container.
builder.Services.AddScoped<IAreaService, AreaService>();
builder.Services.AddScoped<IPlantTreeService, PlantTreeService>();
builder.Services.AddScoped<ITreeSortService, TreeSortService>();

builder.Services.AddAutoMapper(typeof(MapperProfile));

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
