﻿using Hangfire;
using HangfireDemo;
using HangfireDemo.Services;

var builder = WebApplication.CreateBuilder(args);

Startup.ConfigureService(builder.Services, builder.Configuration);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IHourService, HourService>();

Startup.ConfigureHangfire(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHangfireDashboard();

//RecurringJob.AddOrUpdate<IHourService>("print-hour", service => service.PrintHour(), "*/1 * * * *");
RecurringJob.AddOrUpdate<IHourService>("print-hour", service => service.PrintHour(), Cron.Minutely);

app.UseAuthorization();

app.MapControllers();

app.Run();

