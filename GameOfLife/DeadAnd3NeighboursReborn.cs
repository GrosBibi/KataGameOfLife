using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
  public class DeadAnd3NeighboursReborn : IRule
  {
    public bool BornToBeAlive(bool alive, int liveNeighboursCount)
    {
      return !alive && liveNeighboursCount == 3;
    }
  }
}
