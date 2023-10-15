using chessboard.Entities;

namespace JogoDeXadrez
{
    public class Screen
    {
        // Método responsável por percorrer o tabuleiro e imprimir as peças na tela. 
        public static void ViewBoard(Board board)
        {
            // Criando um loop "for" para percorrer o nosso tabuleiro:
            for (int i = 0; i < board.line; i++)
            {
                for (int j = 0; j < board.column; j++)
                {
                    // Verifica se a peça na posição atual não é nula e a exibe; caso contrário, exibe um espaço em branco.
                    if (board.Piece(i, j) != null)
                    {
                        Console.Write($"{board.Piece(i, j)} ");
                    }
                    else
                    {
                        Console.Write("[ ] ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}