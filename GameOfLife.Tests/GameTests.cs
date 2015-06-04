using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using GameOfLife;

/*
 Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.
Any live cell with more than three live neighbours dies, as if by overcrowding.
Any live cell with two or three live neighbours lives on to the next generation.
Any dead cell with exactly three live neighbours becomes a live cell.
 */
namespace GameOfLife.Tests
{
  [TestFixture]
  public class GameTests
  {
    [Test]
    public void GivenACell1x1ThenItShouldDie(){
      var liveCells = new[]{ new Position(1,1) };
      var grid = new Grid(2, liveCells);

      var nextGenGrid = grid.NextGeneration();
         
      Assert.That(nextGenGrid.LiveCells, Is.Empty);
    }

    [Test]
    public void GivenFixedSizeNextGenShouldHaveSameSize(){
      var grid = new Grid(3, null);

      var nextGenGrid = grid.NextGeneration();
        
      Assert.That(nextGenGrid.Size, Is.EqualTo(3));
    }

    [Test]
    public void GivenAFull3x3ThenOnlyCornerCellsShouldLive(){
      var grid = new Grid(3,
        new []{
          new Position(1,1),
          new Position(1,2),
          new Position(1,3),
          new Position(2,1),
          new Position(2,2),
          new Position(2,3),
          new Position(3,1),
          new Position(3,2),
          new Position(3,3)
        }
      );

      var nextGenGrid = grid.NextGeneration();
      var expected = new[]{
          new Position(1,1),
          new Position(1,3),
          new Position(3,1),
          new Position(3,3)
        };

      Assert.That(nextGenGrid.LiveCells, Is.EqualTo(expected));
    }

    [Test]
    public void AnyCellWith3NeighboursShouldLive(){
      var grid = new Grid(2,
        new[]{
          new Position(1,1),
          new Position(1,2),
          new Position(2,1),
          new Position(2,2),
        });

      var nextGenGrid = grid.NextGeneration();
      var expected = new[]{
          new Position(1,1),
          new Position(1,2),
          new Position(2,1),
          new Position(2,2),
        };

      Assert.That(nextGenGrid.LiveCells, Is.EqualTo(expected));
    }

    [Test]
    public void GivenADeadCellWithThreeNeighboursItShouldLive(){
      var grid = new Grid(3,
        new[]{
          new Position(2,1),
          new Position(2,2),
          new Position(2,3)
        });

      var nextGenGrid = grid.NextGeneration();
      var expected = new[]{
          new Position(1,2),
          new Position(2,2),
          new Position(3,2)
        };

      Assert.That(nextGenGrid.LiveCells, Is.EqualTo(expected));
    }

  }
}
