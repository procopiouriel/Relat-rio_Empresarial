using System.Threading.Channels;
using Discord;
using Discord.WebSocket;

public class DiscordBot
{
    private DiscordSocketClient _client;
   

    public async Task RunAsync()
    {
        _client = new DiscordSocketClient();
        

        _client.Log += Log;
       _client.MessageReceived += HandleMessageReceived;

        await _client.LoginAsync(TokenType.Bot, "MTA3MTE4MTM3NzcyODQzNDI4Ng.GECY9F.ON864y2-N8Xmp-pmrRpShkSm27sNUrRrFbwV1w");
        await _client.StartAsync();

        await Task.Delay(-1);
    }

    private Task Log(LogMessage arg)
    {
        Console.WriteLine(arg);
        return Task.CompletedTask;
    }

    private async Task HandleMessageReceived(SocketMessage arg)
    {
        if (arg.Author.IsBot) return;

        var channel = arg.Channel as SocketTextChannel;
        

        
    }

    public async void Retorno(SocketMessage arg)
    {
        try
        {
            Leitor conexao = new Leitor();
            conexao.Ler();
            var channel = arg.Channel as SocketTextChannel;

            while (true)
            {
                voltar:
                string mensagemNick = "";
                string mensagemHoras = "";
                
                for (int i = 0; i <= conexao.nomeArray.Length; i++)
                {
                    if (conexao.nomeArray[i] != null)//SE O ARRAY TIVER ALGUM PLAYER
                    {
                        Console.WriteLine(conexao.GetNomes()[i]);
                        
                        await channel.SendMessageAsync(conexao.GetNomes()[i]);

                    }
                    
                    conexao.nomeArray[i] = null;
                    Console.WriteLine("As posicoes " + i + " foram zeradas.");
                    
                }
                
            }
            Console.WriteLine("TESTE");

        }
        catch (Exception e)
        {
            Console.WriteLine(" ERRORRR: " + e.Message);
        }
    }
}