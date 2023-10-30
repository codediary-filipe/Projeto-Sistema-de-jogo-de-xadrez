namespace Tabuleiro_De_Xadrez
{
    //Classe Peça de Xadrex:
    /*
        Responsável pela lógica das peças de xadrex. Contido nela temos:
        1. As propriedades da peça de xadrez: Posição, Cor, Quantidade de movimentos, Tabuleiro.
        2. Lógica de movimentos possíveis de uma peça dentro do tabuleioro.
        
    */
    public abstract class PecasDeXadrez
    {
        public Posicao Posicao { get; set; } //Representa a posição da peça dentro do Tabuleiro.
        public Color color { get; set; } //Representa a cor da peça.
        public int ContadorDeMovimento { get; protected set; } /*Representa a quantidade de movimentos que a peça realizou.
         Ela é protegida (protected set) para que apenas a classe PecasDeXadrez e suas subclasses possam modificar essa propriedade.*/
        public Tabuleiro Tabuleiro { get; protected set; } //Tabuleiro em que a peça está localizada.

        public PecasDeXadrez(Tabuleiro Tabuleiro, Color color)
        {
            //Iniciando a variável posição como nula.
            Posicao = null;
            //Iniciando o contador de movimentos com 0:
            ContadorDeMovimento = 0;
            this.Tabuleiro = Tabuleiro;
            this.color = color;
        }

        //Método que incrementa o movimento de uma determina peça.
        public void IncrementarMovimento()
        {
            ContadorDeMovimento++;
        }
        //Decrementa o movimento de uma peça.
        public void DecrementarMovimento()
        {
            ContadorDeMovimento--;
        }

        //Método Abstrato Movimentos Possíveis:
        /*
         Utilizando para calcular e retornar os movimentos possíveis da peça de xadrez específica. Como ele é abstrato, cada subclasse deve fornecer sua própria implementação desse método, com base nas regras de movimentação de cada peça.
        */
        public abstract bool[,] MovimentosPossiveis();

        //Método Movimento Existentes válidos: 
        /*
         Percorrer todo o Tabuleiro e verificar se há movimentos possíveis dentro do tabuleiro.
        */
        public bool MovimentosExistValidos()
        {
            //Criandondo uma matriz contendo todos os movimentos possíveis.
            bool[,] mat = MovimentosPossiveis();
            //Percorrendo o nosso tabuleiro e verificando se a movimentos válidos.
            for (int i = 0; i < Tabuleiro.Linhas; i++)
            {
                for (int j = 0; j < Tabuleiro.Colunas; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //Método pode mover para: verificar se a peça pode mover para uma determinada posição.
        public bool PodeMoverPara(Posicao pos)
        {
            //Verifica os movimentos possíveis de acordo com essa posição.
            return MovimentosPossiveis()[pos.Linhas, pos.Colunas];
        }
    }
}