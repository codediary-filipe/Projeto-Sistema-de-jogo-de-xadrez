
//Criando a class tabuleiro de xadrex:
namespace chessboard
{
    public class Position //Criando a class posição do tabuleiro de xadrez:
    {
        //Elementos linha e coluna:
        public int line { get; set; }
        public int column { get; set; }

        //Construtor:
        public Position(int line, int column)
        {
            //Referenciando os nossos objeto com a palavra this:
            this.line = line;
            this.column = column;
        }

        public override string ToString()
        {
            return $"Posição: {line},{column}";
        }
    }
}