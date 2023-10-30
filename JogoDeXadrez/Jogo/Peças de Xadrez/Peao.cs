//Importando namespaces:
using Tabuleiro_De_Xadrez;

namespace Jogo
{
    public class Peao : PecasDeXadrez
    {
        public Peao(Tabuleiro Tabuleiro, Color color) : base(Tabuleiro, color) { }
        public override string ToString()
        {
            return $"P";
        }

        //Diferente as outras peças, o peão tem uma lógica própria:
        /*
            Como o método ExixteInimigo: Verifica-se se o peão pode se mover para as laterais, baseado em: se há ou não inimigos.
            Como o método Move: O peão pode se mover para posições a frente que estejam vazias
        */
        private bool ExisteInimigo(Posicao pos)
        {
            PecasDeXadrez p = Tabuleiro.Peca(pos);
            return p != null && p.color != color;
        }

        private bool Move(Posicao pos)
        {
            return Tabuleiro.Peca(pos) == null;
        }

        //O método Movimentos Possíveis foi adicionado para mostrar os movimentos possíveis da peça no Tabuleiro:
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao pos = new(0, 0);

            //Regras para peões da cor branca:
            if (color == Color.Branca)
            {
                pos.DefinirPosicao(Posicao.Linhas - 1, Posicao.Colunas);
                if (Tabuleiro.ValidarPosicao(pos) && Move(pos))
                {
                    mat[pos.Linhas, pos.Colunas] = true;
                }
                //Se o peão está no seu primeiro movimento, ele pode mover duas posições da dele.
                pos.DefinirPosicao(Posicao.Linhas - 2, Posicao.Colunas);
                if (Tabuleiro.ValidarPosicao(pos) && Move(pos) && ContadorDeMovimento == 0)
                {
                    mat[pos.Linhas, pos.Colunas] = true;
                }
                pos.DefinirPosicao(Posicao.Linhas - 1, Posicao.Colunas - 1);
                if (Tabuleiro.ValidarPosicao(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linhas, pos.Colunas] = true;
                }
                pos.DefinirPosicao(Posicao.Linhas - 1, Posicao.Colunas + 1);
                if (Tabuleiro.ValidarPosicao(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linhas, pos.Colunas] = true;
                }
            }
            else //Regras para peões da cor preta:
            {
                pos.DefinirPosicao(Posicao.Linhas + 1, Posicao.Colunas);
                if (Tabuleiro.ValidarPosicao(pos) && Move(pos))
                {
                    mat[pos.Linhas, pos.Colunas] = true;
                }
                pos.DefinirPosicao(Posicao.Linhas + 2, Posicao.Colunas);
                if (Tabuleiro.ValidarPosicao(pos) && Move(pos) && ContadorDeMovimento == 0)
                {
                    mat[pos.Linhas, pos.Colunas] = true;
                }
                pos.DefinirPosicao(Posicao.Linhas + 1, Posicao.Colunas - 1);
                if (Tabuleiro.ValidarPosicao(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linhas, pos.Colunas] = true;
                }
                pos.DefinirPosicao(Posicao.Linhas + 1, Posicao.Colunas + 1);
                if (Tabuleiro.ValidarPosicao(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linhas, pos.Colunas] = true;
                }
            }
            //Retorna a matriz com os movimentos possíveis da peça.
            return mat;
        }
    }
}