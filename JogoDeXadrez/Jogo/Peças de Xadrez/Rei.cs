//Importando namespaces:
using Tabuleiro_De_Xadrez;

namespace Jogo
{
    public class Rei : PecasDeXadrez
    {
        //Criando uma variável partida:
        private PartidaDeXadrez partida { get; set; }
        public Rei(Tabuleiro Tabuleiro, PartidaDeXadrez partida, Color color) : base(Tabuleiro, color)
        {
            this.partida = partida;
        }
        //Método PossivelRoque: Verifica se é possível fazer um roque na posição passada.
        private bool PossivelRoque(Posicao pos)
        {
            //Recebe a peça que está na posiçao.
            PecasDeXadrez p = Tabuleiro.Peca(pos);
            //Verifica, as seguintes condições: a peça não pode ser nula, tem que ser uma torre com a mesma cor do rei e não pode ter se movimentado
            return p != null && p is Torre && p.color == color && p.ContadorDeMovimento == 0;
        }

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

            //#Jogada Especial Roque
            //Verifica se o Rei está em sua primeira jogada e se não está em xeque.
            if (ContadorDeMovimento == 0 && !partida.PecaEmXeque)
            {
                //Verifica se a peça retirada é um Rei e se a movimentação é um Roque (destino.Colunas == origem.Colunas + 2)
                Posicao RoquePequeno = new(Posicao.Linhas, Posicao.Colunas + 3);
                //Verifica se é possível realizar um Roque do Rei para o lado do Roque Pequeno.
                if (PossivelRoque(RoquePequeno))
                {
                    //Criando duas posições auxiliares para verificar se é possível fazer o Roque está disponível. 
                    Posicao p1 = new(Posicao.Linhas, Posicao.Colunas + 1);
                    Posicao p2 = new(Posicao.Linhas, Posicao.Colunas + 2);
                    //Verifica se as posições auxiliares para o Roque Pequeno estão disponíveis.
                    if (Tabuleiro.Peca(p1) == null && Tabuleiro.Peca(p2) == null)
                    {
                        mat[Posicao.Linhas, Posicao.Colunas + 2] = true;
                    }
                }
                //Define a posição para o Roque do Rei para o lado do Roque Grande.
                Posicao RoqueGrande = new(Posicao.Linhas, Posicao.Colunas - 4);
                //Verifica se é possível realizar um Roque do Rei para o lado do Roque Grande.
                if (PossivelRoque(RoqueGrande))
                {
                    Posicao p1 = new(Posicao.Linhas, Posicao.Colunas - 1);
                    Posicao p2 = new(Posicao.Linhas, Posicao.Colunas - 2);
                    Posicao p3 = new(Posicao.Linhas, Posicao.Colunas - 3);
                    if (Tabuleiro.Peca(p1) == null && Tabuleiro.Peca(p2) == null && Tabuleiro.Peca(p3) == null)
                    {
                        mat[Posicao.Linhas, Posicao.Colunas - 2] = true;
                    }
                }
            }

            //A matriz mat é então retornada com os movimentos possíveis do Rei.
            return mat;
        }
    }
}