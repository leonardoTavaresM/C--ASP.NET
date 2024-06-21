using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Endpoints;
using ScreenSound.DB;
using ScreenSound.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ScreenSoundContext>();
builder.Services.AddTransient<DAL<Artist>>();
builder.Services.AddTransient<DAL<Music>>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => 
options.SerializerOptions.ReferenceHandler 
= ReferenceHandler.IgnoreCycles);

var app = builder.Build();

app.AddEndpointsArtists();
app.AddEndpointsMusics();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
