using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoL_Cli
{
  class Program
  {
    static void Main(string[] args)
    {
      var random = new Random();
      var liveCells = new List<GameOfLife.Position>();
      for(var i = 0; i < 100; i++){
        liveCells.Add(new GameOfLife.Position(random.Next(1, 20), random.Next(1, 20)));
      }

      var grid = new GameOfLife.Grid(20, liveCells);

      DisplayGrid(grid);

      for(var g = 0; g < 1000; g++){
        grid = grid.NextGeneration();
        DisplayGrid(grid);
        Thread.Sleep(200);
        Console.Clear();
      }

      Console.ReadLine();
    }

    private static void DisplayGrid(GameOfLife.Grid grid)
    {
      for(var x = 1; x <= 20; x++){
        for(var y = 1; y <= 20; y++){
          if (grid.LiveCells.Contains(new GameOfLife.Position(x, y)))
            Console.Write("X");
          else
            Console.Write(".");
        }
        Console.WriteLine();
      }
    }
  }
}
