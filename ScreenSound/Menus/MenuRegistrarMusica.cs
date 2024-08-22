using ScreenSound.DB;
using ScreenSound.Models;

namespace ScreenSound.Menus;

internal class MenuRegistrarMusica : Menu
{
    public override void Execute(DAL<Artist> artistDAL)
    {
        base.Execute(artistDAL);
        ExibirTituloDaOpcao("Registro de músicas");
        Console.Write("Digite o artista cuja música deseja registrar: ");
        string artistName = Console.ReadLine()!;
        var recoveredArtist = artistDAL.GetBy(a => a.Name.Equals(artistName));
        if (recoveredArtist is not null)
        {
            Console.Write("Agora digite o título da música: ");
            string tituloDaMusica = Console.ReadLine()!;
            Console.Write("Agora digite o ano de lançamento da musica: ");
            string releaseYear = Console.ReadLine()!;
            recoveredArtist.AdicionarMusica(new Music(tituloDaMusica, Convert.ToInt32(releaseYear), null));
            Console.WriteLine($"A música {tituloDaMusica} de {artistName} foi registrada com sucesso!");
            artistDAL.Update(recoveredArtist);
            Thread.Sleep(4000);
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\nO artista {artistName} não foi encontrado!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
