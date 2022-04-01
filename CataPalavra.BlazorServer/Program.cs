using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using CataPalavra.BlazorServer.Data;
using CataPalavra.Buscador.Interfaces;
using CataPalavra.Buscador.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<CataPalavraService>();
builder.Services.AddSingleton<IDicionarioService, DicionarioService>();
builder.Services.AddScoped<IBuscadorService, BuscadorService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
