using lva_project.Models;
using lva_project.Services;
using lva_project.Utils;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<LvaContext>();
builder.Services.AddScoped<ILvaService, LvaService>();
builder.Services.AddScoped<ISemesterService, SemesterService>();
builder.Services.AddScoped<IUtils, Utils>();



// builder.Services.AddTransient<LvaService>();


// Add services to the container.
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");
;

app.Run();