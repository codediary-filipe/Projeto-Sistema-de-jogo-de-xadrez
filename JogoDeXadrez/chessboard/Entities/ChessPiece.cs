//Class peça de xadrez:
/*Informações:
 A classe ChessPiece representa uma peça de xadrez. Ela tem propriedades para posição, cor, quantidade de movimentos e uma referência ao tabuleiro. 
*/
using chessboard.Enums;

namespace chessboard.Entities
{
    public class ChessPiece
    {
        // Elementos: posição, tabuleiro, quantidade de movimentos e cor da minha peça de xadrez:
        public Position position { get; set; }
        public Color color { get; set; }
        // Propriedade "GetMoves" somente acessível pela própria classe e suas subclasses.
        public int GetMoves { get; protected set; }
        public Board board { get; protected set; }

        //Construtor:
        public ChessPiece(Position position, Color color, Board board)
        {
            this.position = position;
            this.color = color;
            this.board = board;
            // Quantidade de movimentos padrão, iniciando com 0.
            GetMoves = 0;
        }
    }
}