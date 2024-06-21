using ScreenSound.DB;
using ScreenSound.Models;

namespace ScreenSound.Menus;

internal class MenuSair : Menu
{
    public override void Execute(DAL<Artist> artistDAL)
    {
        Console.WriteLine("Tchau tchau :)");
    }
}
