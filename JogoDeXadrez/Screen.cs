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
                //O segundo loop for itera pelas colunas do tabuleiro. board.column representa o número de colunas do tabuleiro.
                for (int j = 0; j < board.column; j++)
                {
                    //É verificado se a peça na posição atual (linha i, coluna j) não é nula:
                    if (board.Piece(i, j) != null)
                    {
                        Console.Write($"{board.Piece(i, j)} ");
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
        }
    }
}