using System;
using System.ComponentModel;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

class ContadorEmpresarial
{
    public static async Task Main()
    {
        Console.WriteLine("Instruções:\n 1- Caso você forneça o caminho errado ao programa, ele simplesmente não funcionará.\n 2 - Para ativar o programa, vá a um canal aleatório do seu servidor do Discord(onde queira que seja executado o serviço) e digite qualquer coisa aleatória(TUDO É VÁLIDO). \n 3 - Para encerrar o programa, basta fechar completamente o console. \n" );
        Console.WriteLine("Coloque o caminho da sua pasta chatlog.txt: ");
        string caminho = Console.ReadLine();

        if (caminho == null)
        {
            Console.WriteLine("Caminho invalido!");
        }
        else
        {
            Leitor conexao = new Leitor();
            conexao.caminho = caminho;
            Console.Clear();

            DiscordBot bot = new DiscordBot();
            bot.caminho2 = caminho;
            await bot.RunAsync();
        }

        Console.ReadKey();
    }
}