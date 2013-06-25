using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGOL
{
    public class Cell 
    {
        public CellState State { get; set; }

        public enum CellState { Alive, Dead };

        public Cell(CellState state)
        {
            this.State = state;
        }
    }
}
