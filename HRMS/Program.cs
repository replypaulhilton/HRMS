using BankApplication.Infrastructure.Presistence;
using HRMS;
using HRMS.HRMS.Application.Common.Interfaces.Persistence;
using HRMS.Infrastructure;
using HRMS.Infrastructure.Presistence;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Mapper
var config = TypeAdapterConfig.GlobalSettings;
config.Scan(Assembly.GetExecutingAssembly());

builder.Services.AddSingleton(config);
builder.Services.AddScoped<IMapper, ServiceMapper>();

//Meditor
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
//builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

//Repository or Infrasturture -- U can split these in to another file
builder.Services.AddScoped<IAdminstratorRepository, AdminstratorRepository>();

//Database -- Need to Make seperate file for more maintable 
var configuration = builder.Configuration;
var DapperSettings = new DapperSettings();
configuration.Bind(DapperSettings.SectionName, DapperSettings);
builder.Services.AddSingleton(Options.Create(DapperSettings));
builder.Services.AddSingleton<DapperContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
