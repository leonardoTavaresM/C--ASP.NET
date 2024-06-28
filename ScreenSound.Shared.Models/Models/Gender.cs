using ScreenSound.Models;

namespace ScreenSound.Shared.Models.Models;

public class Gender
{
    public Gender(string? name, string description)
    {
        Name = name;
        Description = description;
    }
    public int Id { get; set; }
    public string? Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;

    public virtual ICollection<Music> Musics { get; set; }
    public override string ToString()
    {
        return $"Nome: {Name} - Descrição: {Description}";
    }
}
