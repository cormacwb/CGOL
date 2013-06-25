using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CGOL;

namespace CGOL_Tests
{
    [TestClass]
    public class WorldTests
    {

        //Creates following grid
        //X = Dead
        //O = Alive
        //XXOOO
        //XXXXX
        //OXOOO
        //XXOOX
        //OXOXX
        private World GetTestWorldInstance()
        {
            Cell[,] cells = new Cell[5, 5];
            cells[0, 0] = new Cell(Cell.CellState.Dead);
            cells[0, 1] = new Cell(Cell.CellState.Dead);
            cells[0, 2] = new Cell(Cell.CellState.Alive);
            cells[0, 3] = new Cell(Cell.CellState.Alive);
            cells[0, 4] = new Cell(Cell.CellState.Alive);

            cells[1, 0] = new Cell(Cell.CellState.Dead);
            cells[1, 1] = new Cell(Cell.CellState.Dead);
            cells[1, 2] = new Cell(Cell.CellState.Dead);
            cells[1, 3] = new Cell(Cell.CellState.Dead);
            cells[1, 4] = new Cell(Cell.CellState.Dead);

            cells[2, 0] = new Cell(Cell.CellState.Alive);
            cells[2, 1] = new Cell(Cell.CellState.Dead);
            cells[2, 2] = new Cell(Cell.CellState.Alive);
            cells[2, 3] = new Cell(Cell.CellState.Alive);
            cells[2, 4] = new Cell(Cell.CellState.Alive);

            cells[3, 0] = new Cell(Cell.CellState.Dead);
            cells[3, 1] = new Cell(Cell.CellState.Dead);
            cells[3, 2] = new Cell(Cell.CellState.Alive);
            cells[3, 3] = new Cell(Cell.CellState.Alive);
            cells[3, 4] = new Cell(Cell.CellState.Dead);

            cells[4, 0] = new Cell(Cell.CellState.Alive);
            cells[4, 1] = new Cell(Cell.CellState.Dead);
            cells[4, 2] = new Cell(Cell.CellState.Alive);
            cells[4, 3] = new Cell(Cell.CellState.Dead);
            cells[4, 4] = new Cell(Cell.CellState.Dead);

            return new World(cells);
        }
        
        [TestMethod]
        public void CanAdvanceWorldState()
        {
            //Arrange
            World world = GetTestWorldInstance();
            //Act
            world.MoveToNextState();

            //Assert
            Assert.AreEqual(world.Cells[0, 0].State, Cell.CellState.Dead, "Unexpected value in cell:0,0");
            Assert.AreEqual(world.Cells[0, 1].State, Cell.CellState.Dead, "Unexpected value in cell:0,1");
            Assert.AreEqual(world.Cells[0, 2].State, Cell.CellState.Dead, "Unexpected value in cell:0,2");
            Assert.AreEqual(world.Cells[0, 3].State, Cell.CellState.Alive, "Unexpected value in cell:0,3");
            Assert.AreEqual(world.Cells[0, 4].State, Cell.CellState.Dead, "Unexpected value in cell:0,4");

            Assert.AreEqual(world.Cells[1, 0].State, Cell.CellState.Dead, "Unexpected value in cell:1,0");
            Assert.AreEqual(world.Cells[1, 1].State, Cell.CellState.Alive, "Unexpected value in cell:1,1");
            Assert.AreEqual(world.Cells[1, 2].State, Cell.CellState.Dead, "Unexpected value in cell:1,2");
            Assert.AreEqual(world.Cells[1, 3].State, Cell.CellState.Dead, "Unexpected value in cell:1,3");
            Assert.AreEqual(world.Cells[1, 4].State, Cell.CellState.Dead, "Unexpected value in cell:1,4");

            Assert.AreEqual(world.Cells[2, 0].State, Cell.CellState.Dead, "Unexpected value in cell:2,0");
            Assert.AreEqual(world.Cells[2, 1].State, Cell.CellState.Alive, "Unexpected value in cell:2,1");
            Assert.AreEqual(world.Cells[2, 2].State, Cell.CellState.Alive, "Unexpected value in cell:2,2");
            Assert.AreEqual(world.Cells[2, 3].State, Cell.CellState.Dead, "Unexpected value in cell:2,3");
            Assert.AreEqual(world.Cells[2, 4].State, Cell.CellState.Alive, "Unexpected value in cell:2,4");

            Assert.AreEqual(world.Cells[3, 0].State, Cell.CellState.Dead, "Unexpected value in cell:3,0");
            Assert.AreEqual(world.Cells[3, 1].State, Cell.CellState.Dead, "Unexpected value in cell:3,1");
            Assert.AreEqual(world.Cells[3, 2].State, Cell.CellState.Dead, "Unexpected value in cell:3,2");
            Assert.AreEqual(world.Cells[3, 3].State, Cell.CellState.Dead, "Unexpected value in cell:3,3");
            Assert.AreEqual(world.Cells[3, 4].State, Cell.CellState.Alive, "Unexpected value in cell:3,4");

            Assert.AreEqual(world.Cells[4, 0].State, Cell.CellState.Dead, "Unexpected value in cell:4,0");
            Assert.AreEqual(world.Cells[4, 1].State, Cell.CellState.Alive, "Unexpected value in cell:4,1");
            Assert.AreEqual(world.Cells[4, 2].State, Cell.CellState.Alive, "Unexpected value in cell:4,2");
            Assert.AreEqual(world.Cells[4, 3].State, Cell.CellState.Alive, "Unexpected value in cell:4,3");
            Assert.AreEqual(world.Cells[4, 4].State, Cell.CellState.Dead, "Unexpected value in cell:4,4");
        }

        [TestMethod]
        public void CanGetStateNumber()
        {
            World world = GetTestWorldInstance();
            Assert.AreEqual(world.GetGenerationNumber(), 0);
            world.MoveToNextState();
            Assert.AreEqual(world.GetGenerationNumber(), 1);
            world.MoveToNextState();
            Assert.AreEqual(world.GetGenerationNumber(), 2);
        }

        [TestMethod]
        public void CanGetCells()
        {
            //Arrange
            World world = GetTestWorldInstance();

            //Act
            Cell[,] cells = world.GetCells();

            //Assert
            Assert.IsNotNull(cells, "GetCells returned null");
        }

        [TestMethod]
        public void CAnGetLiveCellsCount()
        {
            //Arrange
            World world = GetTestWorldInstance();

            //Act
            int liveCellCount = world.GetLiveCellCount();

            //Assert
            Assert.AreEqual(liveCellCount, 11);
        }
    }
}
