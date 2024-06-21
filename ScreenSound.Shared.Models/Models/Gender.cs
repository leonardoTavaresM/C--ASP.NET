
namespace ScreenSound.Shared.Models.Models;

public class Gender
{
    public int Id { get; set; }
    public string? Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"Nome: {Name} - Descrição: {Description}";
    }
}
