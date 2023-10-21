
namespace chessboard
{
    // Classe para representar uma posição no tabuleiro.
    public class Position
    {
        /*Estas são propriedades da classe que representam a linha e a coluna da posição no tabuleiro.*/
        public int Rows { get; set; }
        public int Columns { get; set; }

        //Construtor:
        public Position(int rows, int columns)
        {
            //Referenciando os nossos objeto com a palavra this:
            Rows = rows;
            Columns = columns;
        }

        //Construtor criado para poder manipular as linhas e colunas da minha posição:

        public void SetPosition(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
        }

        public override string ToString()
        {
            return $"{Rows}. {Columns}";
        }
    }
}