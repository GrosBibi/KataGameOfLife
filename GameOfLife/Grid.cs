using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
  public class Grid{
    private IEnumerable<IRule> Rules;
    public IEnumerable<Position> LiveCells;
    public int Size;

    public Grid(int size, IEnumerable<Position> liveCells){
      this.LiveCells = liveCells ?? new Position[0];
      this.Size = size;

      this.Rules = new IRule[]{
        new FewerThan2AndMoreThan3Die(),
        new DeadAnd3NeighboursReborn()
      };
    }

    public Grid NextGeneration()
    {
      var liveCells = new List<Position>();
      
      for(var h = 1; h <= this.Size; h++){
        for(var v = 1; v <= this.Size; v++){
          var current = new Position(h, v);
          var count = GetLiveNeighboursCount(current);

          foreach(var rule in this.Rules){
            if(rule.BornToBeAlive(this.LiveCells.Contains(current), count)){
              liveCells.Add(current);
            }
          }
          /*
          if (this.LiveCells.Contains(current) && count >= 2 && count <= 3)
            liveCells.Add(current);

          if (!this.LiveCells.Contains(current) && count == 3)
            liveCells.Add(current);*/
        }
      }
      
      return new Grid(this.Size, liveCells);
    }

    private int GetLiveNeighboursCount(Position position){
      var count = 0;
      for(var x = -1; x <= 1; x++){
        for(var y = -1; y <= 1; y++){
          if((x != 0 || y != 0) && this.LiveCells.Contains(new Position(position.X + x, position.Y + y)))
          {
            count++;
          }
        }
      }
      return count;
    }
  }
}
