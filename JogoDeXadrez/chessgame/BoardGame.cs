using chessboard;

namespace chessgame
{

    // Classe para representar o jogo de xadrez.
    public class BoardGame
    {
        //Propriedades tabuleiro, mudança de turno, jogador atual e fim de partida.
        public Board Tabuleiro { get; private set; }
        //Essa propriedade representa a mudança de turno no jogo:
        private int Shift { get; set; }
        //Essa propriedade representa a cor do jogador atual (se é a vez das peças brancas ou pretas):
        private Color CurrentPlay { get; set; }
        public bool IsGameOver { get; private set; }

        // Construtor do jogo de xadrez.
        public BoardGame()
        {
            /*Criamos um tabuleiro padrão de 8x8, definimos a mudança de turno como 1 (indicando a vez das peças brancas) e define a cor do jogador atual como branca (Color.Branca). Além disso, ele chama o método InsertPiece() para adicionar as peças iniciais ao tabuleiro.*/
            Tabuleiro = new Board(8, 8);
            Shift = 1;
            //Propriedade criada para controlar o fim do jogo:
            IsGameOver = false;
            CurrentPlay = Color.Branca;
            InsertPiece();
        }
        // Realiza um movimento de uma posição de origem para uma posição de destino.
        public void MakeMove(Position origin, Position destiny)
        {
            //Remove a peça da posição de origem:
            ChessPiece movingPiece = Tabuleiro.RemovePiece(origin);
            //Remove qualquer peça do destino, caso exista:
            ChessPiece capturedPiece = Tabuleiro.RemovePiece(destiny);
            //insere a peça na posição de destino. 
            Tabuleiro.InsertPart(movingPiece, destiny);
            //Incrementa o número de movimentos dessa peça:
            movingPiece.IncreaseMoveCount();
        }

        //Este método é usado para inserir manualmente as peças iniciais no tabuleiro:
        private void InsertPiece()
        {
            //Explicações: 
            /*
                Utilizando o método InsertPart para criar e inserir novas peças em nosso tabuleiro:
            */
            //Novo objeto do tipo Torrer((inserido no Tabuleiro, é criada com a cor preta), na posição c1 que é convertida em posições válida no tabuleiro.):
            Tabuleiro.InsertPart(new Tower(Tabuleiro, Color.Branca), new PositionChess('c', 1).toPosition());
            Tabuleiro.InsertPart(new Tower(Tabuleiro, Color.Branca), new PositionChess('c', 2).toPosition());
            Tabuleiro.InsertPart(new Tower(Tabuleiro, Color.Branca), new PositionChess('d', 2).toPosition());
            Tabuleiro.InsertPart(new Tower(Tabuleiro, Color.Branca), new PositionChess('e', 2).toPosition());
            Tabuleiro.InsertPart(new Tower(Tabuleiro, Color.Branca), new PositionChess('e', 1).toPosition());
            Tabuleiro.InsertPart(new King(Tabuleiro, Color.Branca), new PositionChess('d', 1).toPosition());

            Tabuleiro.InsertPart(new Tower(Tabuleiro, Color.Preta), new PositionChess('c', 7).toPosition());
            Tabuleiro.InsertPart(new Tower(Tabuleiro, Color.Preta), new PositionChess('c', 8).toPosition());
            Tabuleiro.InsertPart(new Tower(Tabuleiro, Color.Preta), new PositionChess('d', 7).toPosition());
            Tabuleiro.InsertPart(new Tower(Tabuleiro, Color.Preta), new PositionChess('e', 7).toPosition());
            Tabuleiro.InsertPart(new Tower(Tabuleiro, Color.Preta), new PositionChess('e', 8).toPosition());
            Tabuleiro.InsertPart(new King(Tabuleiro, Color.Preta), new PositionChess('d', 8).toPosition());
        }
    }
}