using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Requests;
using ScreenSound.API.Response;
using ScreenSound.DB;
using ScreenSound.Models;

namespace ScreenSound.API.Endpoints;

public static class ArtistsExtensions
{
    public static void AddEndpointsArtists(this WebApplication app)
    {
        app.MapGet("/artists", ([FromServices] DAL<Artist> dal) =>
        {
            var artistList = dal.List();
            if(artistList is null)
            {
                return Results.NotFound();
            }
            var artistListResponse = EntityListToResponseList(artistList);
            return Results.Ok(artistListResponse);
        });


        app.MapGet("/artists/{name}", ([FromServices] DAL<Artist> dal, string name) =>
        {
            var artist = dal.GetBy(a => a.Name.ToUpper().Equals(name.ToUpper()));
            if (artist is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(EntityToResponse(artist));
        });

        app.MapPost("/artists", ([FromServices] DAL<Artist> dal, [FromBody] ArtistRequest artistRequest) =>
        {
            var artist = new Artist(artistRequest.name, artistRequest.bio);
            dal.Add(artist);
            return Results.Ok(artist);
        });
         
        app.MapDelete("/artists/{id}", ([FromServices] DAL<Artist> dal, int id) =>
        {
            var artist = dal.GetBy(a => a.Id == id);
            if (artist is null)
            {
                return Results.NotFound("Artist not found");
            }
            dal.Delete(artist);
            return Results.Ok(EntityToResponse(artist));
        });


        app.MapPut("/artists", ([FromServices] DAL<Artist> dal, [FromBody] ArtistRequestEdit artistRequestEdit) =>
        {
            var updateArtist = dal.GetBy(a => a.Id == artistRequestEdit.id);
            if (updateArtist is null)
            {
                return Results.NotFound("Artist not found");
            }

            updateArtist.Name = artistRequestEdit.name;
            updateArtist.Bio = artistRequestEdit.bio;
            

            dal.Update(updateArtist);

            return Results.Ok(EntityToResponse(updateArtist));
        });
    }

    private static ArtistResponse EntityToResponse(Artist artist)
    {
        return new ArtistResponse(artist.Id, artist.Name, artist.Bio, artist.ProfilePhoto);
    }

    private static ICollection<ArtistResponse> EntityListToResponseList(IEnumerable<Artist> ArtistList)
    {
        return ArtistList.Select(a => EntityToResponse(a)).ToList();
    }

}
