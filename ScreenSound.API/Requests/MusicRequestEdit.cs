using ScreenSound.Models;

namespace ScreenSound.API.Requests;

public record MusicRequestEdit(int id, string name, int releaseYear, int? artistId);
