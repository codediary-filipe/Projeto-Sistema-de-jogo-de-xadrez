//Importando namespaces para nossa classe:
using chessboard;
using chessgame;

//Informações da classe:
/*
    A classe Program é responsável por iniciar a execução do jogo de xadrez. Criando um tabuleiro, adiciona peças a ele, exibe o tabuleiro na tela e lidando com exceções. Isso permite que o jogador visualize o tabuleiro e qualquer mensagem de erro associada.
*/

namespace JogoDeXadrez
{
  public class Program
  {
    public static void Main(String[] args)
    {
      //A estrutura try é usada para envolver um bloco de código que pode lançar exceções:
      try
      {

        // Chamando o método para imprimir o tabuleiro:
        BoardGame Game = new BoardGame();
        Screen.ViewBoard(Game.Tabuleiro);
      }
      /*
      A estrutura catch é usada para capturar exceções do tipo BoardException, que podem ser lançadas dentro do bloco try.
      Se ocorrer uma exceção do tipo BoardException, o bloco catch será executado. catch (BoardException error).
      */
      catch (BoardException error)
      {
        Console.WriteLine(error.Message);
      }
      //Este comando aguarda a entrada do usuário antes de encerrar o programa. Isso permite que o jogador veja a saída do jogo antes de fechá-lo.
      Console.ReadKey();
    }
  }
}
