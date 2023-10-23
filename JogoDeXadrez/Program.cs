//Importando namespaces para nossa classe:
using chessboard;
using chessgame;

//Informações da classe Program: 
/*
   A classe Program é responsável por iniciar a execução do jogo de xadrez. Ela cria um tabuleiro, adiciona peças a ele, exibe o tabuleiro na tela e lida com exceções. Isso permite que o jogador visualize o tabuleiro e qualquer mensagem de erro associada.
*/

namespace ChessGameApp
{
  public class Program
  {
    public static void Main(String[] args)
    {
      // Estrutura try para lidar com exceções:
      try
      {

        /// Inicializa o jogo e entra em um loop while que continua enquanto o jogo não acabou.
        BoardGame Game = new BoardGame();
        while (!Game.IsGameOver)
        {
          try
          {
            //Limpa o console.
            Console.Clear();
            //Chama o método que visualiza o tabuleiro.
            Screen.ViewBoard(Game.Tabuleiro);
            Console.WriteLine();
            Console.WriteLine($"Turno:{Game.Turn}");
            Console.WriteLine($"Aguardando vez da {Game.CurrentPlay}");
            Console.WriteLine();

            // Solicita ao jogador que insira a posição de origem e destino para fazer um movimento no tabuleiro.
            Console.Write("Origem:");
            /*O método Screen.ReadScreen().toPosition() ler uma posição em formato "letra + número" e converte elas em objetos Position.*/
            Position Origem = Screen.ReadScreen().toPosition();

            // Verificando a posição de origem digitada.
            Game.CheckOrigin(Origem);

            bool[,] validMoves = Game.Tabuleiro.Piece(Origem).PossibleMoves();
            Console.Clear();
            Screen.ViewBoard(Game.Tabuleiro, validMoves);
            Console.WriteLine();

            Console.Write("Destino:");
            Position Destiny = Screen.ReadScreen().toPosition();

            // Verificando se é possível mover a peça da posição de origem para a posição de destino digitada.
            Game.CheackDestiny(Origem, Destiny);

            // Realiza o movimento no tabuleiro.
            Game.MakePlay(Origem, Destiny);
          }
          catch (BoardException error)
          {
            Console.WriteLine(error.Message);
            Console.ReadLine();
          }
        }

      }
      // Captura exceções do tipo BoardException:
      catch (BoardException error)
      {
        Console.WriteLine(error.Message);
      }
    }
  }
}
