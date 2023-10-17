//Importando namespaces para nossa classe:
using chessboard;

//Representa a peça de xadrez "Rei" no jogo.
namespace chessgame
{
    /*
     A classe King herda todas as propriedades e métodos da classe base ChessPiece, que é a classe genérica para todas as peças de xadrez.
    */
    public class King : ChessPiece
    {
        public King(Board board, Color color) : base(board, color) { }

        //Quando esse método é chamado, ele retorna a string "R", que é a representação visual do Rei no tabuleiro de xadrez. 
        public override string ToString()
        {
            return $"R";
        }
    }
}