//Importando namespaces para nossa classe:

namespace chessboard
{

    //A classe Position no namespace chessboard é responsável por representar uma posição no tabuleiro de xadrez:
    public class Position
    {
        /*
        Estas são propriedades da classe que representam a linha e a coluna da posição no tabuleiro. As propriedades têm métodos de acesso get e set, o que significa que elas podem ser lidas e modificadas.
        */
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
            return $"{line}. {column}";
        }
    }
}