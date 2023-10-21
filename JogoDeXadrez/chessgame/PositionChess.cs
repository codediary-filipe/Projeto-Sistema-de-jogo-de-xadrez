using chessboard;

/*Informações:
Essa classe é usada para representar uma posição em um formato mais amigável ao usuário, usando letras e números para representar a columns e a linha de uma posição no tabuleiro de xadrez.
*/
namespace chessgame
{
    //Esta é a classe PositionChess, que representa uma posição no formato de xadrez.
    public class PositionChess
    {
        public char Columns { get; set; }
        public int Rows { get; set; }

        public PositionChess(char columns, int rows)
        {
            Columns = columns;
            Rows = rows;
        }

        /*
        Este é um método que converte a posição no formato de xadrez (usando letras e números) em uma posição mais padrão, provavelmente usando um objeto do tipo Position do namespace chessboard. 

        É feita a subtração da linha pelo valor 8 e subtrai a columns pelo caractere 'a' (para obter um valor numérico para a columns).
        */
        public Position toPosition()
        {
            return new Position(8 - Rows, Columns - 'a');
        }

        public override string ToString()
        {
            return $" {Columns} {Rows}";
        }
    }
}