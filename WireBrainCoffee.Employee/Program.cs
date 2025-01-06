﻿using WireBrainCoffee.Employee.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WireBrainCoffee.Employee.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EmployeeManagerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeManagerDbContext") ?? throw new InvalidOperationException("Connection string 'EmployeeManagerDbContext' not found.")));

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
