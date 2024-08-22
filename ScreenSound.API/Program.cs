using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ScreenSound.API.Endpoints;
using ScreenSound.DB;
using ScreenSound.Models;
using ScreenSound.Shared.Models.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ScreenSoundContext>((options) =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:ScreenSoundDB"]).UseLazyLoadingProxies(false);
});
builder.Services.AddTransient<DAL<Artist>>();
builder.Services.AddTransient<DAL<Music>>();
builder.Services.AddTransient<DAL<Gender>>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => 
options.SerializerOptions.ReferenceHandler 
= ReferenceHandler.IgnoreCycles);

var app = builder.Build();

app.AddEndpointsArtists();
app.AddEndpointsMusics();
app.AddEndpointsGenres();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();


