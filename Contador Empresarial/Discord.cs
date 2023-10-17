using System;
using System.Reflection;
using System.Threading.Channels;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

public class DiscordBot
{
    private DiscordSocketClient _client;
    public string caminho2;
    public static ulong idUser;
    

    public async Task RunAsync()
    {
        _client = new DiscordSocketClient();

        _client.Log += Log;
       _client.MessageReceived += HandleMessageReceived;

        await _client.LoginAsync(TokenType.Bot, "MTA3MTE4MTM3NzcyODQzNDI4Ng.G3Zbgq.qPGvoJJF8XsCsJgiMb-SizCsB3NKmvq77OXAIc");
        await _client.StartAsync();

        await Task.Delay(-1);

      
    }

    private Task Log(LogMessage arg)
    {
        Console.WriteLine(arg);
        return Task.CompletedTask;
    }

    public async Task HandleMessageReceived(SocketMessage arg)
    {
        try
        {
        voltar:
            Leitor conexao = new Leitor();
            conexao.Ler(caminho2);


            //if (arg.Author.IsBot) return;
            //var channel1 = arg.Channel as SocketTextChannel;
           


            for (int i = 0; i < conexao.GetNomes().Length; i++)
            {
                while (conexao.nomeArray[i] != null)//AS POSICOES OCUPADAS
                {
                    if (conexao.GetNomes()[i].Contains("Explosivos"))
                    {
                        var channel1 = _client.GetChannel(1162768111720730707) as SocketTextChannel;
                        var userToMention = _client.GetUser(idUser);

                        await channel1.SendMessageAsync($"Responsavel: {userToMention.Mention} \n" + conexao.GetNomes()[i]);
                        conexao.Retorno(i);
                    }
                    if (conexao.GetNomes()[i].Contains("Trafico"))
                    {
                        var channel1 = _client.GetChannel(1162771309470683188) as SocketTextChannel;
                        var userToMention = _client.GetUser(idUser);

                        await channel1.SendMessageAsync($"Responsavel: {userToMention.Mention} \n" + conexao.GetNomes()[i]+"\n");
                        conexao.Retorno(i);
                    }


                }
            }
           
            goto voltar;
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR DISCORD: " + e.Message);
        }
    }

}