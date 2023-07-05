using System;
using Discord.WebSocket;

public class Leitor
{
    public string[] nomeArray = new string[100];
    public string caminho;

    public void Ler(string caminho)
    {
        try
        {
            string palavra = "contratou";
            string linhaEncontrada = "";
            string path = caminho;
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
                        if (linha.Contains("para a empresa"))
                        {
                            string nickPlayer = linha.Split(" ")[4];//NICK DO PLAYER
                            string horaPlayer = linha.Split(" ")[0];//HORARIO DO ALUGUEL

                            for (int i = 0; i < nomeArray.Length; i++)
                            {
                                while (nomeArray[i] != null)//OCUPADO
                                {
                                    i++;
                                }
                                nomeArray[i] = nickPlayer + " " + horaPlayer;
                                //Console.WriteLine(nickPlayer + " foi adicionado na posicao " + i);
                                RemoverLinhaContendoPalavra(path, nickPlayer);
                                break;
                            }
                        }
                    }
                }
            }
        }
        catch (Exception error)
        {
            Console.WriteLine("ERROR NO LEITOR: " + error.Message);
        }
    }


    public void RemoverLinhaContendoPalavra(string filePath, string palavra)
    {
        try
        {
            string[] linhas = File.ReadAllLines(filePath);

            for (int i = 0; i <= linhas.Length; i++)
            {
                if (linhas[i].Contains(palavra))
                {
                    linhas[i] = null;
                    File.WriteAllLines(filePath, linhas);
                    //Console.WriteLine("A linha contendo a palavra '{0}' foi removida do arquivo.", palavra);
                    return;
                }
            }

            //Console.WriteLine("Nenhuma linha contendo a palavra '{0}' foi encontrada no arquivo.", palavra);

        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR REMOVEDOR LINHA: " + e.Message);
        }
    }


    public void Retorno(int posicao)
    {
        try
        {
            nomeArray[posicao] = null;
            //Console.WriteLine("As posicoes " + posicao + " foram zeradas.");
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR RETORNO: " + e.Message);
        }
    }

    public string[] GetNomes()
    {
        return nomeArray;
    }
}