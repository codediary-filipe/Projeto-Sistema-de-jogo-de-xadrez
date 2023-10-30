//Importando namespaces:
using Tabuleiro_De_Xadrez;
using Jogo;

//Classe Tela:
/*
    Responsável por exibir o tabuleiro de xadrez no console. Contido nela temos:
    1. O método que imprime o tabuleiro de xadrez.
    2. O método que imprime as peças no tabuleiro.
    3. O método que imprime as peças capturadas
    4. Executa a lógica de Xeque e Xeque Mate.

*/

namespace Xadrez_No_Console
{
    public class Tela
    {
        //Imprime o tabuleiro, as peças capturadas, o turno e o jogador da vez.
        public static void VisualizarPartida(PartidaDeXadrez partida) //Recebe uma partida como parâmetro.
        {
            //Limpa o console.
            Console.Clear();
            //Chama o método que imprime o tabuleiro.
            VisualizarTabuleiro(partida.Tabuleiro); //Recebe o tabuleiro da partida iniciada como parâmetro.
            //Espaçamento em branco.
            Console.WriteLine();
            //Chama o método que Imprime as peças capturadas.
            ImprimirPecaCapturadas(partida);
            Console.WriteLine();
            //Imprime o turno e o jogador da vez.
            Console.WriteLine($"Turno:{partida.Turno}");
            //Lógica que verifica se o jogador está em Xeque ou Xeque Mate.
            /*
                Se o status da partida e false, aguarde a vez do jogador atual, se for true, informe o jogador vencedor.
            */
            if (!partida.StatusDaPartida)
            {
                Console.WriteLine($"Aguardando vez da {partida.JogadorAtual}");
                //Verifica se o jogador está em Xeque.
                if (partida.PecaEmXeque)
                {
                    Console.WriteLine("Xeque!");
                }
            }
            else
            {
                Console.WriteLine("Xeque Mate!");
                Console.WriteLine($"Jogador Vecendor: {partida.JogadorAtual}");
                Console.ReadKey();
            }
        }

        //Método VisualizarTabuleiro: Responsável por criar o tabuleiro de xadrez no console.
        public static void VisualizarTabuleiro(Tabuleiro tabuleiro) //Recebe um tabuleiro como parâmetro.
        {
            //Utilizando duas estruturas de repetição for para iterar(percorrer) sobre as linhas e as colunas do nosso tabuleiro.

            //Estrutura for(contador; condição; incrementador) {bloco de execução}
            for (int linhas = 0; linhas < tabuleiro.Linhas; linhas++)
            {
                //Criando uma coluna de números:
                Console.Write($"{8 - linhas} |");
                for (int col = 0; col < tabuleiro.Colunas; col++)
                {
                    //Chama a função Imprimir peça que coloca a peça de acordo com a linha e coluna selecionada.
                    ImprimirPeca(tabuleiro.Peca(linhas, col));
                }
                //Espaçamento em branco.
                Console.WriteLine();
            }
            //Criando uma linha de letras:
            Console.WriteLine($"   a b c d e f g h ");
        }

        //Método Imprimir peça: Responsável por imprimir as peças de xadrez em nosso tabuleiro.
        public static void ImprimirPeca(PecasDeXadrez peca) //Recebe uma peça como parãmetro.
        {
            //Verifica se a peça é nula.
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {   //Verifica se a peça é branca.
                if (peca.color == Color.Branca)
                {
                    //Imprime a peça
                    Console.Write(peca);
                }
                else
                {
                    //Cria uma variável do tipo ConsoleColor e armazena a cor atual do texto.
                    ConsoleColor padrao = Console.ForegroundColor;
                    //altera a cor do texto para verde.
                    Console.ForegroundColor = ConsoleColor.Green;
                    //Imprime a peça
                    Console.Write(peca);
                    /*
                      a cor origemal do texto é restaurada, retornando a cor que estava armazenada em padrao. Isso garante que o restante do texto no console seja impresso na cor origemal.
                    */
                    Console.ForegroundColor = padrao;
                }
                //Espaçamento em branco.
                Console.Write(" ");
            }
        }

        //Método responsável por imprimir as peças Brancas e Pretas que são capturadas.
        public static void ImprimirPecaCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças Capturadas:");
            Console.Write("Brancas:");
            //Chama o método que retorna um conjunto de peças capturas.
            VisualizarConjunto(partida.PecaCapturada(Color.Branca));
            Console.WriteLine();
            //Conjunto de peças pretas.
            Console.Write("Pretas:");
            //Captura a cor padrão do nosso console e guarda em uma variável temporária.
            ConsoleColor temp = Console.ForegroundColor;
            //Muda a cor do console para verde.
            Console.ForegroundColor = ConsoleColor.Green;
            VisualizarConjunto(partida.PecaCapturada(Color.Preta));
            //retorna a cor origemal do console.
            Console.ForegroundColor = temp;
            Console.WriteLine();
        }

        //Método que imprime as peças de um determinado conjunto.
        public static void VisualizarConjunto(HashSet<PecasDeXadrez> conjunto) //Recebe um conjunto como parâmetro.
        {
            Console.Write("[");
            //Percorrer o nosso conjunto e imprime todos os objetos do tipo peça.
            foreach (PecasDeXadrez obj in conjunto)
            {
                Console.Write(obj + " ");
            }
            Console.Write("]");
        }

        //Sobrecarga do método VisualizarTabuleiro:
        /*
          Além de fazer o mesmo que o método VisualizarTabuleiro padrão faz, ele imprime os movimentos possíveis da peça.
        */
        public static void VisualizarTabuleiro(Tabuleiro tabuleiro, bool[,] MovimentosValidos)//Recebe uma tabuleiro e uma matriz de movimentos possíveis.
        {
            ConsoleColor backgroundOrigem = Console.BackgroundColor;
            ConsoleColor backgroundMovimentosPossiveis = ConsoleColor.DarkGray;

            for (int linhas = 0; linhas < tabuleiro.Linhas; linhas++)
            {
                //Criando uma coluna de números:
                Console.Write($"{8 - linhas} |");

                for (int col = 0; col < tabuleiro.Colunas; col++)
                {
                    //Verifica se há movimentos possíveis em uma determina linha e coluna do tabuleiro.
                    if (MovimentosValidos[linhas, col])
                    {
                        //Movimentos possíveis são "pintados" de cinza.
                        Console.BackgroundColor = backgroundMovimentosPossiveis;
                    }
                    else
                    {
                        Console.BackgroundColor = backgroundOrigem;
                    }
                    ImprimirPeca(tabuleiro.Peca(linhas, col));
                    Console.BackgroundColor = backgroundOrigem;
                }
                Console.WriteLine();
            }
            //Criando uma linha de letras:
            Console.WriteLine($"   a b c d e f g h ");
            Console.BackgroundColor = backgroundOrigem;
        }

        //Posição no tabuleiro.
        /*
        Este método é responsável por ler a entrada do usuário, que deve especificar a posição de uma peça no formato de Xadrez (letra "a-h" + um número de "1-8").
        */
        public static PosicaoNoTabuleiro LerPosicao()
        {
            string Posicao = Console.ReadLine();
            char coluna = Posicao[0];
            int linha = int.Parse(Posicao[1].ToString());
            //Retorna uma instância de PosicaoNoTabuleiro com os valores da coluna e da linha lidos.
            return new PosicaoNoTabuleiro(coluna, linha);
        }
    }
}