using System;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

class ContadorEmpresarial
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Coloque o caminho da sua pasta chatlog.txt: ");
        string caminho = Console.ReadLine();
        Console.Clear();
        Leitor conexao = new Leitor();
        //conexao.Ler();
        string mensagemNick = "";
        string mensagemHoras = "";
            foreach (string nicks in conexao.GetNomes())
            {
                mensagemNick += nicks + "\n";
               // Console.WriteLine("NICKS: " + nicks);

            }

            foreach (string horas in conexao.GetHoras())
            {
                mensagemHoras += horas;
                //Console.WriteLine("HORAS: " + horas);

            }
       
        DiscordBot bot = new DiscordBot();
        await bot.RunAsync();
    }

}