using System;
using chessboard;
using chessboard.Entities;

namespace JogoDeXadrez
{
  internal class Program
  {
    public static void Main(String[] args)
    {
      // Instânciando uma matriz 8x8 do tipo tabuleiro:
      Board Tabuleiro = new Board(8, 8);

      // Chamando o método para imprimir o tabuleiro:
      Screen.ViewBoard(Tabuleiro);

      Console.ReadKey();
    }
  }
}
