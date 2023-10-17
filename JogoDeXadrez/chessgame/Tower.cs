//Importando namespaces para nossa classe:
using chessboard;

/*
 A classe Tower herda todas as propriedades e métodos da classe base ChessPiece, que é a classe genérica para todas as peças de xadrez.
*/
namespace chessgame
{
    public class Tower : ChessPiece
    {
        public Tower(Board board, Color color) : base(board, color) { }

        //Quando esse método é chamado, ele retorna a string "R", que é a representação visual do Rei no tabuleiro de xadrez. 
        public override string ToString()
        {
            return $"T";
        }
    }
}