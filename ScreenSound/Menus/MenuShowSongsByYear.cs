

using ScreenSound.DB;
using ScreenSound.Models;

namespace ScreenSound.Menus;

internal class MenuShowSongsByYear: Menu
{

    public override void Execute(DAL<Artist> artistDAL)
    {
        base.Execute(artistDAL);
        ExibirTituloDaOpcao("Exibir musicas por ano");
        Console.Write("Digite o ano da música: ");
        string releaseYear = Console.ReadLine()!;

        var musicaDal = new DAL<Music>(new ScreenSoundContext());
        var recoveredMusics = musicaDal.ListBy(m => m.ReleaseYear == Convert.ToInt32(releaseYear));

        if (recoveredMusics.Any())
        {
            Console.WriteLine($"\nMusicas do Ano {releaseYear}: ");

            foreach (Music music in recoveredMusics) {
                music.ExibirFichaTecnica();
            }
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\nO ano {releaseYear} não foi encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }

    }
}
