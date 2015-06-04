using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
  public interface IRule
  {
    bool BornToBeAlive(bool alive, int liveNeighboursCount);
  }
}
