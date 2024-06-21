namespace ScreenSound.Models;

public class Music
{
    public Music(string name, int? releaseYear)
    {
        Name = name;
        ReleaseYear = releaseYear;
    }

    public string Name { get; set; }
    public int Id { get; set; }
    public int? ReleaseYear { get; set; }

    public virtual Artist? Artist { get; set; }


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