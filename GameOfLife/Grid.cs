using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
  public class Grid{
    public IEnumerable<Position> LiveCells;
    public int Size;

    public Grid(int size, IEnumerable<Position> liveCells){
      this.LiveCells = liveCells ?? new Position[0];
      this.Size = size;
    }

    public Grid NextGeneration()
    {
      var liveCells = new List<Position>();
      
      foreach(var cell in this.LiveCells){
        var count = 0;
        for(var x = -1; x <= 1; x++){
          for(var y = -1; y <= 1; y++){
            if((x != 0 || y != 0) && this.LiveCells.Contains(new Position(cell.X + x, cell.Y + y)))
            {
              count++;
            }
          }
        }
        if (count >= 2 && count <= 3)
          liveCells.Add(cell);
      }

      return new Grid(this.Size, liveCells);
    }
  }
}
