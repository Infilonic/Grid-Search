using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridSearch
{
	struct GridVector
	{
		private readonly GridLocation locationVector;

		public GridVector(int x, int y) {
			this.locationVector = new GridLocation(x, y);
		}

		public int X {
			get { return this.locationVector.X; }
		}

		public int Y {
			get { return this.locationVector.Y; }
		}
	}
}
