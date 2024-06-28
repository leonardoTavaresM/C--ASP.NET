using System.ComponentModel.DataAnnotations;

namespace ScreenSound.API.Requests;

public record MusicRequest([Required] string name, [Required] int releaseYear, int? artistId = null, ICollection<GenderRequest> Genres=null);
