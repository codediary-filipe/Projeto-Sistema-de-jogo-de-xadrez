
//Informações:
/* 
 Essa classe representa o tabuleiro de xadrez ela contém as informações e funcionalidades relacionadas ao tabuleiro.
 */
namespace chessboard
{
    public class Board
    {
        //Elementos Linha, coluna e matriz de peças xadrez:
        public int Rows { get; set; }
        public int Columns { get; set; }
        private ChessPiece[,] chessPieces; /*Esta é uma matriz multidimensional de objetos ChessPiece, que representa as peças no tabuleiro. A matriz é privada para evitar que o programador faça alterações diretas nas peças.*/

        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            //Criando uma nova matriz de peças:
            chessPieces = new ChessPiece[rows, columns];
        }

        //Este é um método que retorna a peça localizada em uma posição específica do tabuleiro com base nas coordenadas de linha e coluna:
        public ChessPiece Piece(int rows, int columns)
        {
            return chessPieces[rows, columns];
        }
        // Criando uma sobrecargar do meu Elemento Piece que retorna uma peça com base na posição:
        public ChessPiece Piece(Position pos)
        {
            return chessPieces[pos.Rows, pos.Columns];
        }

        /*Este método permite inserir uma peça no tabuleiro em uma posição específica. Ele verifica se a posição já está ocupada e lança uma exceção personalizada BoardException se a posição já estiver ocupada.*/
        public void InsertPart(ChessPiece p, Position pos)
        {
            if (CheckIf(pos))
            {
                throw new BoardException("Essa Posição já ExistsValidMovese!");
            }
            else
            {
                //Acessa a mátriz da minha peça na posição linha x e coluna x e atribui a peça na posição equivalente:
                chessPieces[pos.Rows, pos.Columns] = p;
                //Atribui a posição forneciada a minha peça criada:
                p.position = pos;
            }
        }

        /*Este método verifica se uma peça ExistsValidMovese em uma posição específica do tabuleiro. Ele usa a função PositionCheck para verificar se a posição é válida antes de verificar se a peça ExistsValidMovese.*/
        public bool CheckIf(Position pos)
        {
            CheckPosition(pos);
            return Piece(pos) != null;
        }

        /*Este método verifica se uma posição é válida, ou seja, se a linha e a coluna estão dentro dos limites do tabuleiro (de 0 a Rows-1 e de 0 a column-1).*/
        public bool PositionCheck(Position pos)
        {
            //Verifica-se se a Rows ou coluna desssa posição é menor que 0 ou maior igual a 8:
            if (pos.Rows < 0 || pos.Rows >= Rows || pos.Columns < 0 || pos.Columns >= Columns)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Este método é usado para verificar se a posição é válida e lança uma exceção BoardException se a posição não for válida.
        public void CheckPosition(Position pos)
        {
            if (!PositionCheck(pos))
            {
                throw new BoardException("Posição inválida!");
            }
        }
        //Classe criada para retirar uma peça do tabuleiro:
        public ChessPiece RemovePiece(Position pos)
        {
            //verifica se a posição é ou não é nula:
            if (Piece(pos) == null)
            {
                return null;
            }
            else
            {
                //Obtém a peça nessa posição e guarda em uma variável auxiliar: 
                ChessPiece PieceAux = Piece(pos);
                //Redefine a posição da peça como nula:
                PieceAux.position = null;
                //Remove a peça da matriz chessPieces:
                chessPieces[pos.Rows, pos.Columns] = null;
                //retorna a peça removida.
                return PieceAux;
            }
        }
    }
}