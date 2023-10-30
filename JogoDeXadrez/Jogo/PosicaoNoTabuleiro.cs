//Importando namespaces:
using Tabuleiro_De_Xadrez;

namespace Jogo
{
    //Classe PosicaoNoTabuleiro: Representa as posição dentro do tabuleiro.
    public class PosicaoNoTabuleiro
    {
        public char Colunas { get; set; } //A coluna é  representada por caractere de a..h
        public int Linhas { get; set; } //A linha é representada por um número de 1..8

        //Contrutor padrão que recebe as linhas e as colunas.
        public PosicaoNoTabuleiro(char colunas, int linhas)
        {
            Colunas = colunas;
            Linhas = linhas;
        }

        //Método ToPosicao:
        /*
        O método converte a posição passada no formato de xadrez "a1" em uma posição númerica, fazendo a subtração (8 - linhas) e (caracter - colunas) o que retorna uma posição.
        */
        public Posicao ToPosicao()
        {
            return new Posicao(8 - Linhas, Colunas - 'a');
        }
        //Sobreposição tostring (usada para teste de verificação).
        public override string ToString()
        {
            return $" {Colunas} {Linhas}";
        }
    }
}