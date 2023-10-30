//Importando namespaces:
using Tabuleiro_De_Xadrez; //Contém todas as classes, métodos e variáveis relacionada ao tabuleiro.
using Jogo; //Contém as classes, métodos e variáveis relacionadas a lógica de jogo do xadrez,

//Classe Program:
/*
   Responsável por iniciar a execução do jogo de xadrez. Contido nela temos:
   1. O teste de Exceções envolvendo a lógica de execução do jogo.
   2. Criação da partida.
   3. O teste que verifica se a partida está iniciada ou finalizada.
*/

namespace Xadrez_No_Console
{
  public class Program
  {
    public static void Main(String[] args)
    {
      //Estrutura try{Lógica do código} catch{Retorno, caso excções} para lidar com exceções:
      try
      {

        //Iniciando / Criando uma nova partida de xadrez.
        PartidaDeXadrez Partida = new();
        //Estrutua de repetição while(Condição) {Bloco de execução} enquanto a condição for verdadeira, o bloco é executado.
        while (!Partida.StatusDaPartida) // !false = true (Partida finalizada) !true = false (Partida Iniciada).
        {
          try
          {
            //Chama o método da classe tela que é responsável por imprimir o tabuleiro de xadrez no console.
            Tela.VisualizarPartida(Partida);
            //Solicitando a posição de origem da peça.
            Console.Write("Origem:");
            /*O método Tela.LerPosicao().ToPosicao() ler uma posição em formato "letra + número" e converte ela em um objeto Posição.*/
            Posicao Origem = Tela.LerPosicao().ToPosicao();

            //Verificando a posição de origem digitada.
            Partida.VerificarOrigem(Origem);

            //Cria uma matriz de movimentos válidos.
            bool[,] MovimentosValidos = Partida.Tabuleiro.Peca(Origem).MovimentosPossiveis();
            //Limpa o console.
            Console.Clear();
            //Chama o método de visualizar tabuleiro, passando como argumento (partida e os movimentos possíveis)
            Tela.VisualizarTabuleiro(Partida.Tabuleiro, MovimentosValidos);
            //Espaçamento em branco.
            Console.WriteLine();

            Console.Write("Destino:");
            //Guarda a posição de destino, já convertida em uma variávia temporária.
            Posicao Destiny = Tela.LerPosicao().ToPosicao();

            //Verificando se é possível mover a peça da posição de origem para a posição de destino digitada.
            Partida.VerificarDestino(Origem, Destiny);

            //Controla a vez dos jogadores e verifica se o joador atual está em xeque e xeque mate.
            Partida.ControleDeTurno(Origem, Destiny);
          }
          catch (TabuleiroException error)
          {
            Console.WriteLine(error.Message);
            Console.ReadLine();
          }
          Console.Clear();
          //Inicia um novo jogo.
          Tela.VisualizarPartida(Partida);
        }

      }
      // Captura exceções do tipo TabuleiroException:
      catch (TabuleiroException error)
      {
        Console.WriteLine(error.Message);
      }
    }
  }
}
