//Importando namespaces para nossa classe:
using System;
using chessboard;
using chessgame;

//Informações:
/* 
 Essa classe representa o tabuleiro de xadrez ela contém as informações e funcionalidades relacionadas ao tabuleiro.
 */
namespace chessboard
{
    public class Board
    {
        //Elementos Linha, coluna e matriz de peças xadrez:
        public int line { get; set; }
        public int column { get; set; }
        private ChessPiece[,] chessPieces; /*Esta é uma matriz multidimensional de objetos ChessPiece, que representa as peças no tabuleiro. A matriz é privada para evitar que o programador faça alterações diretas nas peças.*/

        public Board(int line, int column)
        {
            this.line = line;
            this.column = column;
            //Criando uma nova matriz de peças:
            chessPieces = new ChessPiece[line, column];
        }

        //Este é um método que retorna a peça localizada em uma posição específica do tabuleiro com base nas coordenadas de linha e coluna:
        public ChessPiece Piece(int line, int column)
        {
            return chessPieces[line, column];
        }
        // Criando uma sobrecargar do meu Elemento Piece que retorna uma peça com base na posição:
        public ChessPiece Piece(Position pos)
        {
            return chessPieces[pos.line, pos.column];
        }

        /*Este método permite inserir uma peça no tabuleiro em uma posição específica. Ele verifica se a posição já está ocupada e lança uma exceção personalizada BoardException se a posição já estiver ocupada.*/
        public void InsertPart(ChessPiece p, Position pos)
        {
            if (CheckIf(pos))
            {
                throw new BoardException("Essa Posição já existe!");
            }
            else
            {
                //Acessa a mátriz da minha peça na posição linha x e coluna x e atribui a peça na posição equivalente:
                chessPieces[pos.line, pos.column] = p;
                //Atribui a posição forneciada a minha peça criada:
                p.position = pos;
            }
        }

        /*Este método verifica se uma peça existe em uma posição específica do tabuleiro. Ele usa a função PositionCheck para verificar se a posição é válida antes de verificar se a peça existe.*/
        public bool CheckIf(Position pos)
        {
            CheckPosition(pos);
            return Piece(pos) != null;
        }

        /*Este método verifica se uma posição é válida, ou seja, se a linha e a coluna estão dentro dos limites do tabuleiro (de 0 a line-1 e de 0 a column-1).*/
        public bool PositionCheck(Position pos)
        {
            //Verifica-se se a line ou coluna desssa posição é menor que 0 ou maior igual a 8:
            if (pos.line < 0 || pos.line >= line || pos.column < 0 || pos.column >= line)
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
    }
}