//Importando namespaces:
using Tabuleiro_De_Xadrez;

namespace Jogo
{
    //Classe PartidaDeXadrez:
    /*
        Responsável pela lógica da partida de xadrez. Contido nela temos:
        1. As variáveis e conjuntos essências para a lógica da partida.
        2. Criação do tabuleiro e das definições básicas.
        3. Implementa a inserção das peças dentro do tabuleiro.
        4. Implemnta a movimentação de peça, a verificação de peças em jogo e peças capturadas, verifica posições de destino e posições de origem.
        5. Implementa a lógica de xeque é xeque mate.

    */
    public class PartidaDeXadrez
    {
        //Propriedades: tabuleiro, mudança de turno, jogador atual e status da partida.
        public Tabuleiro Tabuleiro { get; private set; }
        public int Turno { get; private set; }
        public Color JogadorAtual { get; private set; }
        public bool StatusDaPartida { get; private set; }

        //Verificando se o jogador está em Xeque.
        public bool PecaEmXeque { get; private set; }
        //Conjunto de peças em jogo e peças capturadas do tabuleiro.
        public HashSet<PecasDeXadrez> Pecas; //HashSet é uma coleção de conjuntos(elementos únicos) que não permite duplicatas
        public HashSet<PecasDeXadrez> PecasCapturadas;

        public PartidaDeXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8); //Criando um tabuleiro padrão 8x8.
            //Criando os conjuntos vazios.
            Pecas = new(); //Peças ao total.
            PecasCapturadas = new(); //Peças Capturadas.
            Turno = 1;//Definindo o turno
            StatusDaPartida = false; //Definindo o estado da partida.
            PecaEmXeque = false; //Defindo o estado de peças em Xeque.
            JogadorAtual = Color.Branca; //Definindo o jogador atual.

            //Chamano o método que insere peças em nosso tabuleiro.
            PecasDoTabuleiro();
        }

        //Método utilizando para colocar as peças dentro do tabuleiro.
        private void PecasDoTabuleiro()
        {
            //Chamando o método Colocar peça que recebe (linha, coluna, novo objeto do tipo peçaDeXadrez).
            //Pretas:
            ColocarPeca('a', 8, new Torre(Tabuleiro, Color.Preta));
            ColocarPeca('b', 8, new Cavalo(Tabuleiro, Color.Preta));
            ColocarPeca('c', 8, new Bispo(Tabuleiro, Color.Preta));
            ColocarPeca('d', 8, new Dama(Tabuleiro, Color.Preta));
            ColocarPeca('e', 8, new Rei(Tabuleiro, Color.Preta));
            ColocarPeca('g', 8, new Cavalo(Tabuleiro, Color.Preta));
            ColocarPeca('f', 8, new Bispo(Tabuleiro, Color.Preta));
            ColocarPeca('h', 8, new Torre(Tabuleiro, Color.Preta));
            ColocarPeca('a', 7, new Peao(Tabuleiro, Color.Preta));
            ColocarPeca('b', 7, new Peao(Tabuleiro, Color.Preta));
            ColocarPeca('c', 7, new Peao(Tabuleiro, Color.Preta));
            ColocarPeca('d', 7, new Peao(Tabuleiro, Color.Preta));
            ColocarPeca('e', 7, new Peao(Tabuleiro, Color.Preta));
            ColocarPeca('g', 7, new Peao(Tabuleiro, Color.Preta));
            ColocarPeca('f', 7, new Peao(Tabuleiro, Color.Preta));
            ColocarPeca('h', 7, new Peao(Tabuleiro, Color.Preta));

            //Brancas:
            ColocarPeca('a', 1, new Torre(Tabuleiro, Color.Branca));
            ColocarPeca('b', 1, new Cavalo(Tabuleiro, Color.Branca));
            ColocarPeca('c', 1, new Bispo(Tabuleiro, Color.Branca));
            ColocarPeca('d', 1, new Dama(Tabuleiro, Color.Branca));
            ColocarPeca('e', 1, new Rei(Tabuleiro, Color.Branca));
            ColocarPeca('g', 1, new Cavalo(Tabuleiro, Color.Branca));
            ColocarPeca('f', 1, new Bispo(Tabuleiro, Color.Branca));
            ColocarPeca('h', 1, new Torre(Tabuleiro, Color.Branca));
            ColocarPeca('a', 2, new Peao(Tabuleiro, Color.Branca));
            ColocarPeca('b', 2, new Peao(Tabuleiro, Color.Branca));
            ColocarPeca('c', 2, new Peao(Tabuleiro, Color.Branca));
            ColocarPeca('d', 2, new Peao(Tabuleiro, Color.Branca));
            ColocarPeca('e', 2, new Peao(Tabuleiro, Color.Branca));
            ColocarPeca('g', 2, new Peao(Tabuleiro, Color.Branca));
            ColocarPeca('f', 2, new Peao(Tabuleiro, Color.Branca));
            ColocarPeca('h', 2, new Peao(Tabuleiro, Color.Branca));
        }

        //Método utilizado para colocar peças em uma posição definida.
        public void ColocarPeca(char coluna, int linha, PecasDeXadrez peca)
        {
            //Chamando a função inserir Peças que recebe (peça, posiçao).
            Tabuleiro.InserirPeca(peca, new PosicaoNoTabuleiro(coluna, linha).ToPosicao());
            //Adicionando a peça ao conjunto Peças.
            Pecas.Add(peca);
        }

        //Método Mover peça: permite realizar um movimento de uma posição de origem para uma posição de destino no tabuleiro.
        public PecasDeXadrez MoverPeca(Posicao origem, Posicao destino)
        {
            //Remove a peça da posição de origem:
            PecasDeXadrez PecaRetirada = Tabuleiro.RemovePeca(origem);
            //Remove a peça capturada na posição de destino:
            PecasDeXadrez PecaCapturada = Tabuleiro.RemovePeca(destino);
            //Insere a Peça retirada na posição de destino. 
            Tabuleiro.InserirPeca(PecaRetirada, destino);
            //Incrementa o número de movimentos dessa peça:
            PecaRetirada.IncrementarMovimento();
            //utilizando a estrutura condicional if para adicionar todas as peças que não sejam nulas em nosso conjunto "de pelas capturadas"
            if (PecaCapturada != null)
            {
                PecasCapturadas.Add(PecaCapturada);
            }
            return PecaCapturada;
        }

        //Método Peça Capturada: Percorrer o conjunto de peças capturadas e retorna somente as peças capturadas da cor definida.
        public HashSet<PecasDeXadrez> PecaCapturada(Color cor)
        {
            //Cria um conjunto de peças capturadas temporárias.
            HashSet<PecasDeXadrez> temp = new();
            //Percorre o conjunto de peças capturadas.
            foreach (PecasDeXadrez obj in PecasCapturadas)
            {
                //Adiciona ao conjunto temporário somente as peças da cor definida.
                if (obj.color == cor)
                {
                    temp.Add(obj);
                }
            }
            //retorna o conjunto.
            return temp;
        }

        //Método Peças em jogo: Percorre o conjunto de peças em jogo e retorna somente as peças em jogo de determinada cor.
        public HashSet<PecasDeXadrez> PecaEmJogo(Color cor)
        {
            HashSet<PecasDeXadrez> temp = new();
            foreach (PecasDeXadrez obj in Pecas)
            {
                if (obj.color == cor)
                {
                    temp.Add(obj);
                }
            }
            //ExceptWith é um método do conjunto HashSet que remove os elementos que são comuns entre um conjunto x a outro conjunto y.
            temp.ExceptWith(PecaCapturada(cor));
            return temp;
        }

        //Método Desfazer Movimento: Desfaz um movimento de uma peça.
        public void DesfazerMovimento(Posicao origem, Posicao destino, PecasDeXadrez peca)
        {
            //Removendo uma peça que está na posição de destino e atribuíndo ao uma variável temporária.
            PecasDeXadrez p = Tabuleiro.RemovePeca(destino);
            //Decrementando o movimento da peça.
            p.DecrementarMovimento();
            //Verificando se a peça passada como parâmentro é diferente de nula.
            if (peca != null)
            {
                //Se for diferente de nula:
                //Insira a peça na posição de destino.
                Tabuleiro.InserirPeca(peca, destino);
                //Remova a peça do conjunto de peças capturadas.
                PecasCapturadas.Remove(peca);
            }
            //Inserindo a peça removida da posição de destino e atribuíndo a posição de origem.
            Tabuleiro.InserirPeca(p, origem);
        }

        //Método controle de turno: Verifica se o jogador está em xeque ou xeque mate, incrementa o turno e muda o jogador da vez.
        public void ControleDeTurno(Posicao origem, Posicao destino)
        {
            //Retorna a peça capturada e guarda em uma peça temporária.
            PecasDeXadrez p = MoverPeca(origem, destino);
            //Verifica se o jogador atual está ou não em xeque.
            if (EstaEmXeque(JogadorAtual))
            {
                DesfazerMovimento(origem, destino, p);
                throw new TabuleiroException("Jagador atual não pode se colocar em Xeque!");
            }
            //Verifica se o adversário está em xeque.
            if (EstaEmXeque(Adversario(JogadorAtual)))
            {
                PecaEmXeque = true;
            }
            else
            {
                PecaEmXeque = false;
            }
            //Verifica se o jogador adversário está em Xeque Mate.
            if (XequeMate(Adversario(JogadorAtual)))
            {
                StatusDaPartida = true;
            }
            else
            {
                //Incrementa o turno.
                Turno++;
                //Mudo o jogador atual.
                MudarVez();
            }
        }

        //Método Está em xeque: Verifica se o usuário está em xeque.
        public bool EstaEmXeque(Color color)
        {
            //Guarda o rei do adversario dentro de uma variável temporária.
            PecasDeXadrez Rei = ReiAdversario(color);
            //Verifica se o rei adversário é nulo.
            if (Rei == null)
            {
                throw new TabuleiroException($"Não tem rei da cor {Rei.color} no tabuleiro");
            }
            else //Senão for nulo:
            {
                //Percorrer o conjunto de peças em jogo da cor adversária. 
                foreach (PecasDeXadrez obj in PecaEmJogo(Adversario(color)))
                {
                    //Guarda os movimentos possíveis das peças em jogo dentro de uma matriz temporária.
                    bool[,] temp = obj.MovimentosPossiveis();
                    //Retorna verdadeiro se dentro da matriz temporária e possível a movimentação do rei.
                    if (temp[Rei.Posicao.Linhas, Rei.Posicao.Colunas])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //Retorna o rei de uma cor determinada.
        private PecasDeXadrez ReiAdversario(Color color)
        {
            //Percorrer o conjunto de peças em jogo.
            foreach (PecasDeXadrez obj in PecaEmJogo(color))
            {
                //"is" testa se o obj é uma instância de uma subclasse Rei.
                if (obj is Rei)
                {
                    return obj;
                }
            }
            return null;
        }

        //Retorna o adversário de acordo com a cor do jogador atual.
        private Color Adversario(Color color)
        {
            if (color == Color.Branca)
            {
                return Color.Preta;
            }
            return Color.Branca;
        }

        //Método Xeque Mate: Verifica se o jogador está ou não em xeque mate.
        public bool XequeMate(Color color)
        {
            //Verifica se não está em xeque.
            if (!EstaEmXeque(color))
            {
                return false;
            }
            else //Se estiver em xeque:
            {
                //Percorrer o conjunto de peças em jogo:
                foreach (PecasDeXadrez obj in PecaEmJogo(color))
                {
                    //Cria uma matriz de movimentos possíveis.
                    bool[,] temp = obj.MovimentosPossiveis();
                    //Percorrer o tabuleiro:
                    for (int i = 0; i < Tabuleiro.Linhas; i++)
                    {
                        for (int j = 0; j < Tabuleiro.Colunas; j++)
                        {

                            if (temp[i, j])
                            {
                                //Posição de origem recebe a posição da peça.
                                Posicao origem = obj.Posicao;
                                //Posição de destino recebe uma nova posição.
                                Posicao destino = new(i, j);
                                //Guardo a peça capturada.
                                PecasDeXadrez PecaCapturada = MoverPeca(origem, destino);
                                //Verifico se o jogador está em xeque.
                                bool TestaXeque = EstaEmXeque(color);
                                //Desfaço o movimento.
                                DesfazerMovimento(origem, destino, PecaCapturada);
                                if (!TestaXeque)
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }

        //Método é responsável por alternar a vez dos jogadores.
        public void MudarVez()
        {
            if (JogadorAtual == Color.Branca)
            {
                JogadorAtual = Color.Preta;
            }
            else
            {
                JogadorAtual = Color.Branca;
            }
        }

        //Método Verificar origem: Verifica se a posição de origem é válida, caso não for, ele lança uma exceção.
        /*
         Exeções possíveis: 
         1. Caso não tenha peça na posição de origem.
         2. Peça na origem não pertence ao jogador atual.
         3. Peça de origem não tem movimentos possíveis.
        */
        public void VerificarOrigem(Posicao origem)
        {
            if (Tabuleiro.Peca(origem) == null)
            {
                throw new TabuleiroException("Não Existem movimentos válidos da peça de origem na posição escolhida!.");
            }
            else if (JogadorAtual != Tabuleiro.Peca(origem).color)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!.");
            }
            else if (!Tabuleiro.Peca(origem).MovimentosExistValidos())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!.");
            }
        }

        //Método Verificar Destino: Verifica se a posição de destino é válida para mover uma peça a partir de uma origem específica., caso não for, ele lança uma exceção
        /*
         Exceções possíveis:
         1. Posição de destino é inválida.
        */
        public void VerificarDestino(Posicao origem, Posicao destino)
        {
            if (!Tabuleiro.Peca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }
    }
}