using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
  public class Position{
    public int X;
    public int Y;

    public Position(int x, int y){
      this.X = x;
      this.Y = y;
    }

    public override bool Equals(object obj)
    {
      return this.Equals((Position)obj);
    }

    public bool Equals(Position other)
    {
      return this.X == other.X && this.Y == other.Y;
    }

    public override string ToString()
    {
      return string.Format("{0}:{1}", this.X, this.Y);
    }
  }
}
