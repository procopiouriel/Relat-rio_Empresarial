public class testes
{
    public string[] array = new string[100];//ARRAY DOS NOME
    public string[] array2 = new string[100];//ARRAY DAS HORAS ATUAIS

    public void teste(string caminho)
    {
        string palavra = "geladinho";
        string linhaEncontrada = "";
        string path = @caminho;
        string codigo = linhaEncontrada;

        using (StreamReader sr = File.OpenText(path))
        {
            string linha;
            while ((linha = sr.ReadLine()) != null)
            {
                if (linha.Contains(palavra))
                {
                    linhaEncontrada = linha;
                    string palavra1 = linha.Split(" ")[5];//NICK DO PLAYER
                    char[] delimitadores = { ' ' };
                    string[] meuArray = palavra1.Split(delimitadores);
                    foreach (string str in meuArray)
                    {
                        for (int i = 0; i < array.Length; i++)
                        {
                            while (array[i] != null && array2[i] != null)//OCUPADO
                            {
                                i++;
                            }
                            array[i] = str;
                            Console.WriteLine("Nome adicionado na posicão: " + i);
                            string horarioAtual = DateTime.Now.ToString("HH:mm:ss");
                            array2[i] = horarioAtual;
                            Console.WriteLine("O horario atual de " + array[i] + " ficara na posição: " + i);
                            Console.WriteLine("Horario de entrada de " + array[i] + " foi as " + horarioAtual);
                            break;
                        }
                    }   
                }
            }
        }
    }
}
