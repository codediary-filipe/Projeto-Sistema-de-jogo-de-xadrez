//Importando namespaces:
using Tabuleiro_De_Xadrez;

namespace Jogo
{
    public class Torre : PecasDeXadrez
    {
        public Torre(Tabuleiro Tabuleiro, Color color) : base(Tabuleiro, color) { }

        public override string ToString()
        {
            return $"T";
        }

        private bool PodeMover(Posicao pos)
        {
            PecasDeXadrez peca = Tabuleiro.Peca(pos);
            return peca == null || peca.color != color;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao pos = new(0, 0);

            //↑
            pos.DefinirPosicao(Posicao.Linhas - 1, Posicao.Colunas);
            while (Tabuleiro.ValidarPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).color != color)
                {
                    break;
                }
                pos.Linhas -= 1;
            }
            //→
            pos.DefinirPosicao(Posicao.Linhas, Posicao.Colunas + 1);
            while (Tabuleiro.ValidarPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).color != color)
                {
                    break;
                }
                pos.Colunas += 1;
            }
            //←
            pos.DefinirPosicao(Posicao.Linhas, Posicao.Colunas - 1);
            while (Tabuleiro.ValidarPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).color != color)
                {
                    break;
                }
                pos.Colunas -= 1;
            }
            //↓
            pos.DefinirPosicao(Posicao.Linhas + 1, Posicao.Colunas);
            while (Tabuleiro.ValidarPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).color != color)
                {
                    break;
                }
                pos.Linhas += 1;
            }
            //Retorna a matriz com os movimentos possíveis da peça.
            return mat;
        }
    }
}