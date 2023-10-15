//Classe tabuleiro de xadrez:
/*Informações: 
 Essa class representa o tabuleiro de xadrez. conténdo as seguintes propriedades: linhas, colunas, matriz de objetos ChessPiece que representa as peças no tabuleiro.*/

namespace chessboard.Entities
{
    public class Board
    {
        //Elementos Linha, coluna e matriz de peças xadrez:
        public int line { get; set; }
        public int column { get; set; }
        // Impede que o programador faça alterações no tabuleiro:
        private ChessPiece[,] chessPieces;

        public Board(int line, int column)
        {
            this.line = line;
            this.column = column;
            //Instânciando uma nova matriz:
            chessPieces = new ChessPiece[line, column];
        }

        // Método que retorna uma peça do tabuleiro:
        public ChessPiece Piece(int line, int column)
        {
            return chessPieces[line, column];
        }
    }
}