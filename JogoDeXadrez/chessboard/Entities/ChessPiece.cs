//Importando namespaces para nossa classe:

//Informações:
/*
  É uma classe base que representa uma peça de xadrez no jogo. Ela fornece informações e funcionalidades comuns a todas as peças de xadrez.
*/
namespace chessboard
{
    public class ChessPiece
    {
        //Elementos: posição, tabuleiro, quantidade de movimentos e cor da minha peça de xadrez:
        public Position position { get; set; } //Representa um objeto Position que contém as coordenadas da peça.
        public Color color { get; set; } //Representa a cor da peça. Ela utiliza o enum Color para especificar se a peça é branca ou preta.
        public int GetMoves { get; protected set; } /*Representa a quantidade de movimentos que a peça realizou.
         Ela é protegida (protected set) para que apenas a classe ChessPiece e suas subclasses possam modificar essa propriedade.*/
        public Board board { get; protected set; } //Esta é uma propriedade que faz referência ao tabuleiro em que a peça está localizada.

        //Ele aceita como argumentos um objeto Board (representando o tabuleiro) e uma cor (branca ou preta) para a peça. 
        public ChessPiece(Board board, Color color)
        {
            //Inicializa a posição da peça como nula (pois a peça ainda não foi posicionada no tabuleiro)
            position = null;
            this.board = board;
            this.color = color;
            //inicia o contador de movimentos com 0:
            GetMoves = 0;
        }
        //Método que faz a incrementação dos movimentos da peça:
        public void increaseMovements()
        {
           GetMoves++;
        }
    }
}