using ScreenSound.Shared.Models.Models;

namespace ScreenSound.Models;

public class Music
{
    public Music(string name, int? releaseYear, int? artistId)
    {
        Name = name;
        ReleaseYear = releaseYear;
        ArtistId = artistId;
    }

    public string Name { get; set; }
    public int Id { get; set; }
    public int? ReleaseYear { get; set; }
    public int? ArtistId { get; set; }
    public virtual Artist? Artist { get; set; }

    
    public virtual ICollection<Gender> Genres { get; set; }

    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome: {Name}");
      
    }

    public override string ToString()
    {
        return @$"Id: {Id}
        Nome: {Name}";
    }
}