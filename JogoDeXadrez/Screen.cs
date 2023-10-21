//Importando namespaces para nossa classe:
using chessboard;
using chessgame;

//Informações da classe:
/*
    A classe Screen(Tela) tem por finalidade exibir o tabuleiro de xadrez na tela.
*/

namespace ChessGameApp
{
    public class Screen
    {
        //Explicações: 
        /*
            Este é um método público e estático que recebe como argumento um objeto Board, representando o tabuleiro de xadrez que deve ser exibido.
        */
        public static void ViewBoard(Board board)
        {
            //Utilizando dois loops for aninhados para percorrer o tabuleiro. Ele itera pelas linhas e colunas do tabuleiro.

            //O primeiro loop for itera pelas linhas do tabuleiro. board.int rows representa o número de linhas do tabuleiro:
            for (int rows = 0; rows < board.Rows; rows++)
            {
                //Criando uma coluna de números:
                Console.Write($"{8 - rows} |");
                //O segundo loop for itera pelas colunas do tabuleiro. board.column representa o número de colunas do tabuleiro.
                for (int col = 0; col < board.Columns; col++)
                {
                    PrintPiece(board.Piece(rows, col));
                }
                //Utilizando para inserir uma quebra de linha assim que passar para a próxima linha do tabuleiro.
                Console.WriteLine();
            }
            //Criando uma linha de letras:
            Console.WriteLine($"   a b c d e f g h ");
        }

        public static void ViewBoard(Board board, bool[,] validMoves)
        {
            ConsoleColor backgroundOrigem = Console.BackgroundColor;
            ConsoleColor backgroundPossibleMoves = ConsoleColor.DarkGray;

            //O primeiro loop for itera pelas linhas do tabuleiro. board.int rows representa o número de linhas do tabuleiro:
            for (int rows = 0; rows < board.Rows; rows++)
            {
                //Criando uma coluna de números:
                Console.Write($"{8 - rows} |");
                //O segundo loop for itera pelas colunas do tabuleiro. board.column representa o número de colunas do tabuleiro.
                for (int col = 0; col < board.Columns; col++)
                {
                    if (validMoves[rows, col])
                    {
                        Console.BackgroundColor = backgroundPossibleMoves;
                    }
                    else
                    {
                        Console.BackgroundColor = backgroundOrigem;
                    }
                    PrintPiece(board.Piece(rows, col));
                    Console.BackgroundColor = backgroundOrigem;
                }
                //Utilizando para inserir uma quebra de linha assim que passar para a próxima linha do tabuleiro.
                Console.WriteLine();
            }
            //Criando uma linha de letras:
            Console.WriteLine($"   a b c d e f g h ");
            Console.BackgroundColor = backgroundOrigem;
        }

        //O método PrintPiece é responsável por imprimir uma peça de xadrez no console, considerando sua cor.
        public static void PrintPiece(ChessPiece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.color == Color.Branca)
                {
                    Console.Write($"{piece}");
                }
                else
                {
                    /*Esta linha armazena a cor atual do texto no console na variável aux. Isso é feito para que possamos restaurar a cor original após a impressão da peça.*/
                    ConsoleColor aux = Console.ForegroundColor;
                    //altera a cor do texto no console para verde.
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(piece);
                    /*
                      a cor original do texto é restaurada, retornando ao valor que estava armazenado em aux. Isso garante que o restante do texto no console seja impresso na cor original.
                    */
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }

        }
        /*
        Este método é responsável por ler a entrada do usuário, que deve especificar a posição de uma peça no formato de uma letra de coluna (a-h) seguida de um número de linha (1-8).
        */
        public static PositionChess ReadScreen()
        {
            string position = Console.ReadLine();
            char column = position[0];
            int rows = int.Parse(position[1].ToString());
            //Retorna uma instância de PositionChess com os valores da coluna e da linha lidos.
            return new PositionChess(column, rows);
        }
    }
}