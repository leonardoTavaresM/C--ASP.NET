using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Requests;
using ScreenSound.API.Response;
using ScreenSound.DB;
using ScreenSound.Models;
using ScreenSound.Shared.Models.Models;

namespace ScreenSound.API.Endpoints;

public static class GenresExtensions
{

    public static void AddEndpointsGenres(this WebApplication app)
    {
        app.MapGet("/genres", ([FromServices] DAL<Gender> dal) =>
        {
            var genreList = dal.List();
            if (genreList is null)
            {
                return Results.NotFound();
            }

            var genresListResponse = EntityListToResponseList(genreList);
            return Results.Ok(genresListResponse);
        });

        app.MapPost("/genres", ([FromServices] DAL<Gender> dal, [FromBody] GenderRequest genderRequest) =>
        {
            var gender = new Gender(genderRequest.Name, genderRequest.Description);
            dal.Add(gender);
            return Results.Ok(gender);
        });

        app.MapDelete("/genres/{id}", ([FromServices] DAL<Gender> dal, int id) =>
        {
            var gender = dal.GetBy(g =>  g.Id == id);
            if(gender is null)
            {
                return Results.NotFound("Gender not found");
            }
            dal.Delete(gender);
            return Results.Ok(EntityToResponse(gender));
        });

        app.MapPut("/genres", ([FromServices] DAL<Gender> dal, [FromBody] GenderRequestEdit genderRequestEdit) =>
        {
            var updateGender = dal.GetBy(g => g.Id == genderRequestEdit.id);
            if(updateGender is null)
            {
                return Results.NotFound("Gender not Found");
            }

            updateGender.Name = genderRequestEdit.name;
            updateGender.Description = genderRequestEdit.description;
            updateGender.Id = genderRequestEdit.id;

            dal.Update(updateGender);
            
            return Results.Ok(EntityToResponse(updateGender));
        });
    }

    private static GenderResponse EntityToResponse(Gender gender)
    {
        return new GenderResponse(gender.Name, gender.Description);
    }

    private static ICollection<GenderResponse> EntityListToResponseList(IEnumerable<Gender> GenreList)
    {
        return GenreList.Select(a => EntityToResponse(a)).ToList();
    }

}
