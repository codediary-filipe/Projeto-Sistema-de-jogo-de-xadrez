using chessboard;

/*Informações:
Essa classe é usada para representar uma posição em um formato mais amigável ao usuário, usando letras e números para representar a coluna e a linha de uma posição no tabuleiro de xadrez.
*/
namespace chessgame
{
    //Esta é a classe PositionChess, que representa uma posição no formato de xadrez.
    public class PositionChess
    {
        public char coluna { get; set; }
        public int line { get; set; }

        public PositionChess(char coluna, int line)
        {
            this.coluna = coluna;
            this.line = line;
        }

      /*
      Este é um método que converte a posição no formato de xadrez (usando letras e números) em uma posição mais padrão, provavelmente usando um objeto do tipo Position do namespace chessboard. 

      É feita a subtração da linha pelo valor 8 e subtrai a coluna pelo caractere 'a' (para obter um valor numérico para a coluna).
      */
        public Position toPosition(){
            return new Position(8 - line, coluna - 'a');
        }

        public override string ToString()
        {
            return $" {coluna}{line}";
        }
    }
}