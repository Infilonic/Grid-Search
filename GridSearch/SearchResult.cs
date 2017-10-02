using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridSearch {
	class SearchResult {
		private GridLocation location;
		private GridVector direction;
		private string result;

		public SearchResult(GridLocation location, GridVector direction, string result) {
			this.location = location;
			this.direction = direction;
			this.result = result;
		}

		public GridLocation Location {
			get { return this.location; }
		}

		public GridVector Direction {
			get { return this.direction; }
		}

		public string Result {
			get { return this.result; }
		}
	}
}
