//Informações:
/*
A classe TabuleiroException no namespace Tabuleiro_De_Xadrez é uma exceção personalizada que estende a classe ApplicationException. Essa classe é usada para lançar exceções específicas relacionadas ao tabuleiro de xadrez.
*/
namespace Tabuleiro_De_Xadrez
{
    public class TabuleiroException : ApplicationException
    {
        /*
         Este é o construtor da classe TabuleiroException. Ele aceita uma mensagem de erro como argumento e chama o construtor da classe base (ApplicationException) passando essa mensagem. A mensagem é uma descrição do erro que ocorreu, e ela será exibida quando a exceção for capturada e tratada.
        */
        public TabuleiroException(string message) : base(message) { }
    }
}