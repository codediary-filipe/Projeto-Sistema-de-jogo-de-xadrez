
namespace Tabuleiro_De_Xadrez
{
    //Classe que representa uma posição no tabuleiro.
    public class Posicao
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }

        //Construtor:
        public Posicao(int linhas, int colunas)
        {
            //Referenciando os nossos objeto com a palavra this:
            Linhas = linhas;
            Colunas = colunas;
        }

        //Construtor criado para poder manipular as linhas e colunas da minha posição:

        public void DefinirPosicao(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
        }

        public override string ToString()
        {
            return $"{Linhas}. {Colunas}";
        }
    }
}