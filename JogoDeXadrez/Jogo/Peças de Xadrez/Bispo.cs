//Importando namespaces:
using Tabuleiro_De_Xadrez;

namespace Jogo
{
    public class Bispo : PecasDeXadrez
    {
        public Bispo(Tabuleiro Tabuleiro, Color color) : base(Tabuleiro, color) { }

        //Retorna o caracter "B", que é a representação visual da peça no Tabuleiro de xadrez. 
        public override string ToString()
        {
            return $"B";
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
            //Cria uma matriz booleana de acordo com as linhas e colunas do tabuleiro.
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            //Resenta a posição.
            Posicao pos = new(0, 0);

            //←↑
            //Na posição passada, chamamos o método Definir posição, que define uma posição manualmente.
            pos.DefinirPosicao(Posicao.Linhas - 1, Posicao.Colunas - 1);
            //Estrutura de repetição while(condição == verdadeira){faça}:
            //Enquanto a posição for válida e é possível mover a peça para tal posição, faça:
            while (Tabuleiro.ValidarPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
                //Estrutura condicional -> Para a execução do loop, se a posição não for nula, e caso, a cor da peça seja igual.
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).color != color)
                {
                    break;
                }
                pos.DefinirPosicao(pos.Linhas - 1, pos.Colunas - 1);
            }
            //↑→
            pos.DefinirPosicao(Posicao.Linhas - 1, Posicao.Colunas + 1);
            while (Tabuleiro.ValidarPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).color != color)
                {
                    break;
                }
                pos.DefinirPosicao(pos.Linhas - 1, pos.Colunas + 1);
            }
            //↓→
            pos.DefinirPosicao(Posicao.Linhas + 1, Posicao.Colunas + 1);
            while (Tabuleiro.ValidarPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).color != color)
                {
                    break;
                }
                pos.DefinirPosicao(pos.Linhas + 1, pos.Colunas + 1);
            }
            //←↓
            pos.DefinirPosicao(Posicao.Linhas + 1, Posicao.Colunas - 1);
            while (Tabuleiro.ValidarPosicao(pos) && PodeMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).color != color)
                {
                    break;
                }
                pos.DefinirPosicao(pos.Linhas + 1, pos.Colunas - 1);
            }
            //Retorna a matriz com os movimentos possíveis da peça.
            return mat;
        }
    }
}