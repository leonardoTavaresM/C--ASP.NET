namespace ScreenSound.API.Requests;

public record ArtistRequestEdit(int id, string name, string bio) : ArtistRequest(name, bio);

