namespace ScreenSound.Models; 

public class Artist 
{
    public virtual ICollection<Music> Musics { get; set; } = new List<Music>();

    public Artist(string name, string bio)
    {
        Name = name;
        Bio = bio;
        ProfilePhoto = "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png";
    }

    public string Name { get; set; }
    public string ProfilePhoto { get; set; }
    public string Bio { get; set; }
    public int Id { get; set; }

    public void AdicionarMusica(Music music)
    {
        Musics.Add(music);
    }

    public void ExibirDiscografia()
    {
        Console.WriteLine($"Discografia do artista {Name}");
        foreach (var musica in Musics)
        {
            Console.WriteLine($"Música: {musica.Name} - Ano de Lançamento: {musica.ReleaseYear}");
        }
    }



    public override string ToString()
    {
        return $@"Id: {Id}
            Nome: {Name}
            Foto de Perfil: {ProfilePhoto}
            Bio: {Bio}";
    }
}