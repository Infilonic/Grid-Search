using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridSearch
{
	class GridMgr
	{
		Grid _Grid;
		public GridMgr() {
		}

		public void CreateGrid(int rows, int cols) {
			this._Grid = new Grid(rows, cols);
		}
	}
}
