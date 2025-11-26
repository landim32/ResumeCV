using Castle.Core.Configuration;
using Microsoft.Extensions.Configuration;
using NTools.DTO.Settings;
using ResumeCV.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Configuration.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);

builder.Services.Configure<NToolSetting>(builder.Configuration.GetSection("NTools"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Initializer.Configure(builder.Services, builder.Configuration.GetConnectionString("ResumeCVContext"));

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
