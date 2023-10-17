//Importando namespaces para nossa classe:

//Informações:
/*
A classe BoardException no namespace chessboard é uma exceção personalizada que estende a classe ApplicationException. Essa classe é usada para lançar exceções específicas relacionadas ao tabuleiro de xadrez.
*/
namespace chessboard
{
    public class BoardException : ApplicationException
    {
        /*
         Este é o construtor da classe BoardException. Ele aceita uma mensagem de erro como argumento e chama o construtor da classe base (ApplicationException) passando essa mensagem. A mensagem é uma descrição do erro que ocorreu, e ela será exibida quando a exceção for capturada e tratada.
        */
        public BoardException(string message) : base(message) { }
    }
}