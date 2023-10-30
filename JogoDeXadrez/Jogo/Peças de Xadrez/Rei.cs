//Importando namespaces:
using Tabuleiro_De_Xadrez;

namespace Jogo
{
    public class Rei : PecasDeXadrez
    {
        public Rei(Tabuleiro Tabuleiro, Color color) : base(Tabuleiro, color) { }

        //Retorna o caracter "R", que é a representação visual da peça no Tabuleiro de xadrez. 
        public override string ToString()
        {
            return $"R";
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

            //↑
            pos.DefinirPosicao(Posicao.Linhas - 1, Posicao.Colunas);
            if (Tabuleiro.ValidarPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
            }
            //↑→
            pos.DefinirPosicao(Posicao.Linhas - 1, Posicao.Colunas + 1);
            if (Tabuleiro.ValidarPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
            }
            //←↑
            pos.DefinirPosicao(Posicao.Linhas - 1, Posicao.Colunas - 1);
            if (Tabuleiro.ValidarPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
            }
            //→
            pos.DefinirPosicao(Posicao.Linhas, Posicao.Colunas + 1);
            if (Tabuleiro.ValidarPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
            }
            //←
            pos.DefinirPosicao(Posicao.Linhas, Posicao.Colunas - 1);
            if (Tabuleiro.ValidarPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
            }
            //↓
            pos.DefinirPosicao(Posicao.Linhas + 1, Posicao.Colunas);
            if (Tabuleiro.ValidarPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
            }
            //↓→
            pos.DefinirPosicao(Posicao.Linhas + 1, Posicao.Colunas + 1);
            if (Tabuleiro.ValidarPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
            }
            //Baixo_Esquerdo:
            pos.DefinirPosicao(Posicao.Linhas + 1, Posicao.Colunas - 1);
            if (Tabuleiro.ValidarPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
            }
            //A matriz mat é então retornada com os movimentos possíveis do Rei.
            return mat;
        }
    }
}