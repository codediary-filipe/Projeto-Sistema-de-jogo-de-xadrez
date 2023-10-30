namespace Tabuleiro_De_Xadrez
{
    //Classe Tabuleiro:
    /*
        Responsável pela lógica do tabuleiro de xadrez. Contido nela temos:
        1. As linhas, colunas e uma matriz de peças de xadrez do tabuleiro.
        2. O métodos de Inserir Peças no tabuleiro.
        3. O método remover peças do tabuleiro.
        4. E os métodos de verificação, que é responsável por válidar uma posição.
    */
    public class Tabuleiro
    {
        //Propriedades: Linha, coluna e uma matriz de peças xadrez.
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        /*Representa as peças no tabuleiro. A matriz é privada para evitar que o programador faça alterações diretas nas peças.*/
        private PecasDeXadrez[,] PecasDeXadrez;

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            //Criando uma nova matriz de peças.
            PecasDeXadrez = new PecasDeXadrez[linhas, colunas];
        }

        //Método Inserir peças: Permite inserir uma peça no tabuleiro em uma posição específica.
        public void InserirPeca(PecasDeXadrez p, Posicao pos) //Recebe uma peça e uma posição.
        {
            //Verifico se a posição está ocupada ao não.
            if (VerificarPosicao(pos))
            {
                throw new TabuleiroException("Essa posição já está ocupada!");
            }
            else
            {
                //Acessa a mátriz PeçasDeXadrez e coloco a minha peça na posição linha x e coluna x.
                PecasDeXadrez[pos.Linhas, pos.Colunas] = p;
                //Atribuindo a posição forneciada a minha peça criada:
                p.Posicao = pos;
            }
        }

        //Método Verificar Posição: verifica se uma posição específica do tabuleiro é válida ou nula.
        public bool VerificarPosicao(Posicao pos)
        {
            //Verifica se a posição é válida.
            ReceberValidacao(pos);
            //Verifica se a peça na posição passa e diferente de nulo.
            return Peca(pos) != null;
        }

        public void ReceberValidacao(Posicao pos)
        {
            //Chama a função que Valida Posição que verifica se a posição e válida, caso não seja, lança uma exceção.
            if (!ValidarPosicao(pos))
            {
                throw new TabuleiroException("Posição inválida!");
            }
        }

        //Método Validar Posição: Verifica se a posição estão dentro dos limites do tabuleiro.
        public bool ValidarPosicao(Posicao pos)
        {
            //Verifica-se se a posição na linha x ou coluna x é menor que 0 ou maior igual a 8:
            if (pos.Linhas < 0 || pos.Linhas >= Linhas || pos.Colunas < 0 || pos.Colunas >= Colunas)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Método Peça: Retorna uma peça de acordo com as linhas e colunas especificadas.
        public PecasDeXadrez Peca(int linhas, int colunas)
        {
            return PecasDeXadrez[linhas, colunas];
        }
        //Sobrecargar do método Peça que retorna uma peça com base na posição:
        public PecasDeXadrez Peca(Posicao pos)
        {
            return PecasDeXadrez[pos.Linhas, pos.Colunas];
        }

        //Método Remove peça: remove uma peção na posição determinada.
        public PecasDeXadrez RemovePeca(Posicao pos)
        {
            //verifica se a posição é ou não nula:
            if (Peca(pos) == null)
            {
                return null;
            }
            else
            {
                //Obtém a peça nessa posição e guarda em uma variável auxiliar: 
                PecasDeXadrez PecaAux = Peca(pos);
                //Redefine a posição da peça removida como nula:
                PecaAux.Posicao = null;
                //Remove a peça da matriz PecasDeXadrez:
                PecasDeXadrez[pos.Linhas, pos.Colunas] = null;
                //retorna a peça removida.
                return PecaAux;
            }
        }
    }
}