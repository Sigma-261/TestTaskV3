using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TestTaskV3.Components;
using TestTaskV3.Data;
using TestTaskV3.Data.Interfaces;
using TestTaskV3.Data.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

ConfigurationManager configuration = builder.Configuration;

configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddDbContext<TubeContext>(options =>
        options.UseNpgsql(configuration.GetConnectionString("PostgresConnection")));

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

builder.Services.AddTransient(typeof(IEntityRepository<>), typeof(EntityRepository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
