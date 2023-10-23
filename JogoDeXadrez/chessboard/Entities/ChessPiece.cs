
// Classe base para representar uma peça de xadrez.
namespace chessboard
{
    public abstract class ChessPiece
    {
        // Propriedades para cor, contador de movimentos, tabuleiro e posição.
        public Position position { get; set; } // Representa um objeto Position que contém as coordenadas da peça.
        public Color color { get; set; } // Representa a cor da peça. Ela utiliza o enum Color para especificar se a peça é branca ou preta.
        public int MoveCount { get; protected set; } /*Representa a quantidade de movimentos que a peça realizou.
         Ela é protegida (protected set) para que apenas a classe ChessPiece e suas subclasses possam modificar essa propriedade.*/
        public Board board { get; protected set; } // Esta é uma propriedade que faz referência ao tabuleiro em que a peça está localizada.

        // Construtor da peça de xadrez.
        public ChessPiece(Board board, Color color)
        {
            //Inicializa a posição da peça como nula (pois a peça ainda não foi posicionada no tabuleiro)
            position = null;
            this.board = board;
            this.color = color;
            //inicia o contador de movimentos com 0:
            MoveCount = 0;
        }

        // Incrementa o contador de movimentos da peça.
        public void IncreaseMoveCount()
        {
            MoveCount++;
        }
        /*Criando um métoodo abstrato 
         é projetado para calcular e retornar os movimentos possíveis da peça de xadrez específica representada por uma subclasse de ChessPiece. Como ele é abstrato, cada subclasse deve fornecer sua própria implementação desse método, com base nas regras de movimentação da peça que a classe representa.

         Ao adicionar esse método abstrato, a classe base ChessPiece fornece um contrato que obriga suas subclasses a implementar esse método, garantindo que cada tipo de peça de xadrez possa calcular seus próprios movimentos possíveis de acordo com suas regras específicas.
        */
        public abstract bool[,] PossibleMoves();

        // Criando um método para percorrer todo o nosso tabuleiro e verificar se ExistsValidMovesem movimentos possíveis para determinada peça.
        public bool ExistsValidMoves()
        {
            bool[,] mat = PossibleMoves();
            for (int i = 0; i < board.Rows; i++)
            {
                for (int j = 0; j < board.Columns; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // Método para verificar se a peça pode mover-se para uma posição específica.
        public bool CanMoveToPosition(Position pos)
        {
            return PossibleMoves()[pos.Rows, pos.Columns];
        }
    }
}