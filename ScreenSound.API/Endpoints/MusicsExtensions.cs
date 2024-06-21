using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Requests;
using ScreenSound.API.Response;
using ScreenSound.DB;
using ScreenSound.Models;

namespace ScreenSound.API.Endpoints;

public static class MusicsExtensions
{
    public static void AddEndpointsMusics(this WebApplication app)
    {

        app.MapGet("/musics", ([FromServices] DAL<Music> dal) =>
        {
            var musicsList = dal.List();
            if(musicsList is null)
            {
                return Results.NotFound("Songs not Found");
            }
            
            var response = EntityListToResponseList(musicsList);
            return Results.Ok(response);
        });

        app.MapGet("/musics/{name}", ([FromServices] DAL<Music> dal, string name) =>
        {
            var music = dal.GetBy(m => m.Name!.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (music is null)
            {
                return Results.NotFound("Music not Found");
            }
            return Results.Ok(EntityToResponse(music));
        });

        app.MapPost("/musics", ([FromServices] DAL<Music> dal, [FromBody] MusicRequest musicRequest) =>
        {
            var existingMusic = dal.GetBy(m => m.Name!.Equals(musicRequest.name, StringComparison.OrdinalIgnoreCase));
            if (existingMusic is not null)
            {
                return Results.BadRequest("This song already exists");
            }

            var music = new Music(musicRequest.name, musicRequest.releaseYear);
            dal.Add(music);
            return Results.Ok(EntityToResponse(music));
        });

        app.MapDelete("/musics/{id}", ([FromServices] DAL<Music> dal, int id) =>
        {
            var music = dal.GetBy(m => m.Id == id);

            if (music is null)
            {
                return Results.NotFound("Music not Found");
            }

            dal.Delete(music);
            return Results.Ok(EntityToResponse(music));
        });

        app.MapPut("/musics", ([FromServices] DAL<Music> dal, [FromBody] MusicRequestEdit musicRequestEdit) =>
        {
            var updateMusic = dal.GetBy(m => m.Id == musicRequestEdit.id);
            if (updateMusic is null)
            {
                return Results.NotFound("Music not Found");
            }

            updateMusic.Name = musicRequestEdit.name;
            updateMusic.ReleaseYear = musicRequestEdit.releaseYear;

            dal.Update(updateMusic);
            return Results.Ok(EntityToResponse(updateMusic));
        });
    }


    private static MusicResponse EntityToResponse(Music music)
    {

        return new MusicResponse(music.Id, music.Name!, music.Artist.Id, music.Artist.Name);
    }

    private static ICollection<MusicResponse> EntityListToResponseList(IEnumerable<Music> musicList)
    {
        return musicList.Select(EntityToResponse).ToList();
    }
}
