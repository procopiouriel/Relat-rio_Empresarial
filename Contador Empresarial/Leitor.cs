using System;
using Discord.WebSocket;

public class Leitor
{
    public string[] nomeArray = new string[100];
    public string motivo;
    public string caminho;

    public void Ler(string caminho)
    {
        try
        {
            string palavra = "[INFO] Voce tirou os Explosivos de";
            string palavra1 = "[INFO] Voce tirou as Drogas de";
            string linhaEncontrada = "";
            string path = caminho;
            string codigo = linhaEncontrada;

            using (StreamReader sr = File.OpenText(path))
            {
                string linha;

                while ((linha = sr.ReadLine()) != null)
                {

                    if (linha.Contains(palavra) || linha.Contains(palavra1))
                    {
                        linhaEncontrada = linha;
                        
                            string nickMeliante = linha.Split(" ")[7];//NICK DO BANDIDO
                            string horaApreensao = linha.Split(" ")[0];//HORARIO DA PRISAO


                            for (int i = 0; i < nomeArray.Length; i++)
                            {
                                while (nomeArray[i] != null)//OCUPADO
                                {
                                    i++;
                                }

                                if (linha.Contains("Explosivos"))
                                {
                                    motivo = "Porte Ilegal de Explosivos (P.I.E)";
                                    nomeArray[i] = "Meliante: " + nickMeliante + "\nHorario: " + horaApreensao + "\nMotivo: " + motivo;
                                    Console.WriteLine(nickMeliante + " foi adicionado na posicao " + i);
                                    sr.Close();
                                    RemoverLinhaContendoPalavra(path, nickMeliante);
                                    break;
                                }
                                else if (linha.Contains("Drogas"))
                                {
                                    motivo = "Trafico";
                                    nomeArray[i] = " Meliante: " + nickMeliante + "\nHorario: " + horaApreensao + "\nMotivo: " + motivo;
                                    Console.WriteLine(nickMeliante + " foi adicionado na posicao " + i);
                                    sr.Close();
                                    RemoverLinhaContendoPalavra(path, nickMeliante);
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
                    
                    Console.WriteLine("A linha contendo a palavra '{0}' foi removida do arquivo.", palavra);

                    return;
                }
            }

            Console.WriteLine("Nenhuma linha contendo a palavra '{0}' foi encontrada no arquivo.", palavra);

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
            Console.WriteLine("As posicoes " + posicao + " foram zeradas.");
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