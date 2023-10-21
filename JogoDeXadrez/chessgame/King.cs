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
        //Método que verifica se o Rei pode mover-se para uma posição específica (Position pos):

        private bool CanMove(Position pos)
        {

            /*
            Ele verifica se a peça na posição pos é nula (indicando que a posição está vazia) ou se a cor da peça na posição pos é diferente da cor do próprio Rei. Isso é feito para garantir que o Rei só possa mover-se para posições vazias ou ocupadas por peças adversárias
            */

            ChessPiece piece = board.Piece(pos);
            return piece == null || piece.color != color;
        }

        //O método PossibleMoves foi adicionado para calcular os movimentos possíveis do Rei no tabuleiro:
        public override bool[,] PossibleMoves()
        {

            //Ele retorna uma matriz booleana mat, onde cada elemento indica se o Rei pode ou não se mover para a posição correspondente no tabuleiro.
            bool[,] mat = new bool[board.Rows, board.Columns];

            Position pos = new(0, 0);

            //O método utiliza o método CanMove para verificar se o Rei pode mover-se para cada uma das oito direções (cima, cima-direita, direita, etc.).
            //Cima:
            pos.SetPosition(position.Rows - 1, position.Columns);
            if (board.PositionCheck(pos) && CanMove(pos))
            {
                //Se o movimento for possível, o elemento correspondente na matriz mat é definido como true.
                mat[pos.Rows, pos.Columns] = true;
            }
            //Cima_Direita:
            pos.SetPosition(position.Rows - 1, position.Columns + 1);
            if (board.PositionCheck(pos) && CanMove(pos))
            {
                mat[pos.Rows, pos.Columns] = true;
            }
            //Cima_Esquerda:
            pos.SetPosition(position.Rows - 1, position.Columns - 1);
            if (board.PositionCheck(pos) && CanMove(pos))
            {
                mat[pos.Rows, pos.Columns] = true;
            }
            //Direita:
            pos.SetPosition(position.Rows, position.Columns + 1);
            if (board.PositionCheck(pos) && CanMove(pos))
            {
                mat[pos.Rows, pos.Columns] = true;
            }
            //Esquerdo:
            pos.SetPosition(position.Rows, position.Columns - 1);
            if (board.PositionCheck(pos) && CanMove(pos))
            {
                mat[pos.Rows, pos.Columns] = true;
            }
            //Baixo:
            pos.SetPosition(position.Rows + 1, position.Columns);
            if (board.PositionCheck(pos) && CanMove(pos))
            {
                mat[pos.Rows, pos.Columns] = true;
            }
            //Baixo_Direita:
            pos.SetPosition(position.Rows + 1, position.Columns + 1);
            if (board.PositionCheck(pos) && CanMove(pos))
            {
                mat[pos.Rows, pos.Columns] = true;
            }
            //Baixo_Esquerdo:
            pos.SetPosition(position.Rows + 1, position.Columns - 1);
            if (board.PositionCheck(pos) && CanMove(pos))
            {
                mat[pos.Rows, pos.Columns] = true;
            }
            //A matriz mat é então retornada com os movimentos possíveis do Rei.
            return mat;
        }
    }
}