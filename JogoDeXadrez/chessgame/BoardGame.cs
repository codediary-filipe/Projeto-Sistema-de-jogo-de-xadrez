using chessboard;

namespace chessgame
{

    // Classe para representar o jogo de xadrez.
    public class BoardGame
    {
        //Propriedades tabuleiro, mudança de turno, jogador atual e fim de partida.
        public Board Tabuleiro { get; private set; }
        //Essa propriedade representa a mudança de turno no jogo:
        public int Turn { get; private set; }
        //Essa propriedade representa a cor do jogador atual (se é a vez das peças brancas ou pretas):
        public Color CurrentPlay { get; private set; }
        public bool IsGameOver { get; private set; }

        // Construtor do jogo de xadrez.
        public BoardGame()
        {
            /*Criamos um tabuleiro padrão de 8x8, definimos a mudança de turno como 1 (indicando a vez das peças brancas) e define a cor do jogador atual como branca (Color.Branca). Além disso, ele chama o método InsertPiece() para adicionar as peças iniciais ao tabuleiro.*/
            Tabuleiro = new Board(8, 8);
            Turn = 1;
            //Propriedade criada para controlar o fim do jogo:
            IsGameOver = false;
            CurrentPlay = Color.Branca;
            InsertPiece();
        }

        /*Este método permite realizar um movimento de uma posição de origem para uma posição de destino no tabuleiro. Remove a peça da posição de origem, faz captura de uma possível peça no destino e insere a peça na nova posição. Além disso, ele incrementa o contador de movimentos da peça.*/
        public void MakeMove(Position origin, Position destiny)
        {
            //Remove a peça da posição de origem:
            ChessPiece movingPiece = Tabuleiro.RemovePiece(origin);
            //Remove qualquer peça do destino, caso ExistsValidMovesa:
            ChessPiece capturedPiece = Tabuleiro.RemovePiece(destiny);
            //insere a peça na posição de destino. 
            Tabuleiro.InsertPart(movingPiece, destiny);
            //Incrementa o número de movimentos dessa peça:
            movingPiece.IncreaseMoveCount();
        }

        //Esse método inicia a partida, adiciona turnos ao nosso contador e controla a mudança de turno atualizando o jogador atual.;
        public void MakePlay(Position origin, Position destiny)
        {
            MakeMove(origin, destiny);
            Turn++;
            ChangePlayer();
        }

        //Esse método é responsável por alternar a vez dos jogadores, ou seja, mudar a cor do jogador atual de branco para preto ou de preto para branco.
        public void ChangePlayer()
        {
            if (CurrentPlay == Color.Branca)
            {
                CurrentPlay = Color.Preta;
            }
            else
            {
                CurrentPlay = Color.Branca;
            }
        }

        //Verifica se a posição de origem e válida, caso não for, ele lança uma exeção.
        /*
         Exeções possíveis: Caso não tenha peça na posição de origem, quando a peça na origem não pertence ao jogador atual ou quando a peça não tem movimentos possíveis.
        */
        public void CheckOrigin(Position origin)
        {
            if (Tabuleiro.Piece(origin) == null)
            {
                throw new BoardException("Não ExistsValidMovese peça de origem na posição escolhida!.");
            }
            else if (CurrentPlay != Tabuleiro.Piece(origin).color)
            {
                throw new BoardException("A peça de origem escolhida não é sua!.");
            }
            else if (!Tabuleiro.Piece(origin).ExistsValidMoves())
            {
                throw new BoardException("Não há movimentos possíveis pra a peça de origem escolhida!.");
            }
        }

        /*
         Este método verifica se a posição de destino é válida para mover uma peça a partir de uma origem específica. Ele se baseia nas regras de movimento da peça e lança uma exceção se a posição de destino for inválida.
        */

        public void CheackDestiny(Position origin, Position destiny)
        {
            if (!Tabuleiro.Piece(origin).CanMoveToPosition(destiny))
            {
                throw new BoardException("Posição de destino inválida!");
            }
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