using System;
using Discord.WebSocket;

public class Leitor
{
    public bool repetidor = false;
    public string[] nomeArray = new string[100];
    public string[] horaArray = new string[100];

    public void Ler()
    {
        string palavra = "contratou";
        string linhaEncontrada = "";
        string path = @"/Users/urielprocopio/Desktop/cópia de chatlog.txt";
        string codigo = linhaEncontrada;

        using (StreamReader sr = File.OpenText(path))
        {
            string linha;

            while ((linha = sr.ReadLine()) != null)
            {

                if (linha.Contains(palavra))
                {
                    int contador = 0;
                    linhaEncontrada = linha;
                    string nickPlayer = linha.Split(" ")[4];//NICK DO PLAYER
                    string horaPlayer = linha.Split(" ")[0];//HORARIO DO ALUGUEL

                    for (int i = 0; i <= nomeArray.Length; i++)
                    {
                        
                        while (nomeArray[i] != null && horaArray[i] != null)
                        {
                            i++;
                        }
                        nomeArray[i] = nickPlayer + " " + horaPlayer;
                        Console.WriteLine(nickPlayer + " foi adicionado na posicao " + i);
                        horaArray[i] = horaPlayer;
                        break;
                    }
                }
            }
        }
    }

    
    public string[] GetNomes()
    {
        while (true)
        {
           
            return nomeArray;
        }
    }
    
    public string[] GetHoras()
    {
        while (true)
        {
            //Ler();
            return horaArray;
        }
    }

}