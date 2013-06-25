using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGOL
{
    public class World : IGameOfLife
    {
        public Cell[,] Cells { get; set; }
        private int _stateNumber;
        private int _size;

        private const int STARVATION_THRESHOLD = 2;
        private const int OVERCROWDING_THRESHOLD = 3;
        private const int REQUIRED_REPRODUCTION_VALUE = 3;

        public World(int size, int initialLiveCellDensityPercentage)
        {
            _size = size;
            _stateNumber = 0;

            if (size < 1)
                throw new ArgumentException("World size cannot be less than 1");

            if (initialLiveCellDensityPercentage < 0)
                throw new ArgumentException("initialLiveCellDensityPercentage cannot be negative");

            if (initialLiveCellDensityPercentage > 100)
                throw new ArgumentException("initialLiveCellDensityPercentage cannot be greater than 100");

            Cells = new Cell[size, size];
            Random random = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Cell.CellState state = random.Next(100) < initialLiveCellDensityPercentage ? Cell.CellState.Alive : Cell.CellState.Dead;
                    Cells[i, j] = new Cell(state);
                }
            }
        }

        public int GetLiveCellCount()
        {
            return Cells.OfType<Cell>().Where(c => c.State == Cell.CellState.Alive).Count();
        }

        public World(Cell[,] cells)
        {
            if (cells.Length < 1)
                throw new ArgumentException("Invalid cells array");

            _size = (int)Math.Sqrt(cells.Length);
            Cells = cells;
        }

        public Cell[,] GetCells()
        {
            return Cells;
        }

        public int GetGenerationNumber()
        {
            return _stateNumber;
        }

        public void MoveToNextState()
        {
            _stateNumber++;
            Cell[,] nextState = new Cell[_size, _size];
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    nextState[i, j] = new Cell(GetCellNextState(i, j));
                }
            }
            Cells = nextState;
        }

        private Cell.CellState GetCellNextState(int i, int j)
        {
            if (i < 0 || i > _size)
                throw new ArgumentException("Invalid value for i");

            if (j < 0 || j > _size)
                throw new ArgumentException("Invalid value for j");

            int aliveNeigbourCount = GetAliveNeigbourCount(i, j);
            if (Cells[i, j].State == Cell.CellState.Alive)
            {
                if (aliveNeigbourCount < STARVATION_THRESHOLD)
                    return Cell.CellState.Dead;
                else if (aliveNeigbourCount > OVERCROWDING_THRESHOLD)
                    return Cell.CellState.Dead;
                else
                    return Cell.CellState.Alive;
            }
            else
            {
                if (aliveNeigbourCount == REQUIRED_REPRODUCTION_VALUE)
                    return Cell.CellState.Alive;
                else
                    return Cell.CellState.Dead;
            }
        }

        private int GetAliveNeigbourCount(int i, int j)
        {
            return GetNeigbourCells(i, j).Where(c => c.State == Cell.CellState.Alive).Count();
        }

        private IEnumerable<Cell> GetNeigbourCells(int i, int j)
        {
            for (int iOffset = -1; iOffset <= 1; iOffset++)
            {
                if (i + iOffset < 0 || i + iOffset > _size - 1)
                    continue;

                for (int jOffset = -1; jOffset <= 1; jOffset++)
                {
                    if (j + jOffset < 0 || j + jOffset > _size - 1)
                        continue;

                    if (iOffset == 0 && jOffset == 0)
                        continue;

                    yield return Cells[i + iOffset, j + jOffset];
                }
            }
        }


    }
}
