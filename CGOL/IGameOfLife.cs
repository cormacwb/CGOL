using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGOL
{
    interface IGameOfLife
    {
        Cell[,] GetCells();
        void MoveToNextState();
        int GetGenerationNumber();
        int GetLiveCellCount();
    }
}
