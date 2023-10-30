//Importando namespaces:
using Tabuleiro_De_Xadrez;

namespace Jogo
{
    //Classe Cavalo:
    /*
     Responsável pela lógica da peça do cavalo do xadrez. Contido nela temos:
     1. Regras de movimentação da peça.
    */
    public class Cavalo : PecasDeXadrez
    {
        public Cavalo(Tabuleiro Tabuleiro, Color color) : base(Tabuleiro, color) { }

        //Retorna o caracter "C", que é a representação visual da peça no Tabuleiro de xadrez. 
        public override string ToString()
        {
            return $"C";
        }

        //Método Pode Mover: Verifica se a peça na posição pos é nula ou se a cor da peça na posição pos é diferente.
        /*
        Isso é feito para garantir que a peça só possa mover-se para posições vazias ou ocupadas por peças adversárias
        */
        private bool PodeMover(Posicao pos)
        {
            PecasDeXadrez peca = Tabuleiro.Peca(pos);
            return peca == null || peca.color != color;
        }

        //O método Movimentos Possíveis foi adicionado para mostrar os movimentos possíveis da peça no Tabuleiro:
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao pos = new(0, 0);

            //←↑
            pos.DefinirPosicao(Posicao.Linhas - 1, Posicao.Colunas - 2);
            if (Tabuleiro.ValidarPosicao(pos) && PodeMover(pos))
            {
                //Se o movimento for possível, o elemento correspondente na matriz mat é definido como true.
                mat[pos.Linhas, pos.Colunas] = true;
            }
            //←↑
            pos.DefinirPosicao(Posicao.Linhas - 2, Posicao.Colunas - 1);
            if (Tabuleiro.ValidarPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
            }
            //↑→
            pos.DefinirPosicao(Posicao.Linhas - 1, Posicao.Colunas + 2);
            if (Tabuleiro.ValidarPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
            }
            //↑→
            pos.DefinirPosicao(Posicao.Linhas - 2, Posicao.Colunas + 1);
            if (Tabuleiro.ValidarPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
            }
            //↓→
            pos.DefinirPosicao(Posicao.Linhas + 1, Posicao.Colunas + 2);
            if (Tabuleiro.ValidarPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
            }
            //←↓
            pos.DefinirPosicao(Posicao.Linhas + 2, Posicao.Colunas - 1);
            if (Tabuleiro.ValidarPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
            }
            //↓→
            pos.DefinirPosicao(Posicao.Linhas + 1, Posicao.Colunas - 2);
            if (Tabuleiro.ValidarPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
            }
            //Retorna a matriz com os movimentos possíveis da peça.
            return mat;
        }
    }
}