//Importando namespaces para nossa classe:
using chessboard;

//Informações da classe:
/*
    A classe Screen(Tela) tem por finalidade exibir o tabuleiro de xadrez na tela.
*/

namespace JogoDeXadrez
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

            //O primeiro loop for itera pelas linhas do tabuleiro. board.line representa o número de linhas do tabuleiro:
            for (int i = 0; i < board.line; i++)
            {
                //Criando uma coluna de números:
                Console.Write($"{8 - i} |");
                //O segundo loop for itera pelas colunas do tabuleiro. board.column representa o número de colunas do tabuleiro.
                for (int j = 0; j < board.column; j++)
                {
                    //É verificado se a peça na posição atual (linha i, coluna j) não é nula:
                    if (board.Piece(i, j) != null)
                    {
                        PrintPiece(board.Piece(i, j));
                        Console.Write(" ");
                    }
                    //Se a peça não for nula, ela será exibida na tela; caso contrário, será exibido um espaço em branco.
                    else
                    {
                        Console.Write("- ");
                    }
                }
                //Utilizando para inserir uma quebra de linha assim que passar para a próxima linha do tabuleiro.
                Console.WriteLine();
            }
            //Criando uma linha de letras:
            Console.WriteLine($"   a b c d e f g h ");
        }

        //O método PrintPiece é responsável por imprimir uma peça de xadrez no console, considerando sua cor.
        public static void PrintPiece(ChessPiece piece)
        {
            //Esta linha verifica se a cor da peça piece é branca:
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
        }
    }
}