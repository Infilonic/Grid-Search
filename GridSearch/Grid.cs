using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridSearch
{
	class Grid
	{
		private int rows;
		private int cols;
		private char[] letterPool;
		private char[,] gridArray;

		public Grid(int cols, int rows) {
			this.cols = cols;
			this.rows = rows;
			this.gridArray = new char[this.cols, this.rows];
		}

		public int Rows {
			get { return this.rows; }
			set { this.rows = value; }
		}

		public int Cols {
			get { return this.cols; }
			set { this.cols = value; }
		}

		public char[] LetterPool {
			get { return this.letterPool; }
			set { this.letterPool = value; }
		}

		public void PopulateGrid() {
			Random rnd = new Random();
			for (int x = 0; x < this.cols; x++) {
				for (int y = 0; y < this.rows; y++) {
					this.gridArray[x, y] = this.letterPool[rnd.Next(0, this.letterPool.Length)];
				}
			}
		}

		public char GetCharAt(GridLocation location) {
			if (this.IsLocationWithinGrid(location)) {
				return this.gridArray[location.X, location.Y];
			}
			return '\0';
		}

		public void PrintToConsole() {
			GridLocation nextLoc;
			Console.WriteLine("--\n");
			for (int y = 0; y < this.rows; y++) {
				Console.Write("\n");
				for (int x = 0; x < this.cols; x++) {
					nextLoc = new GridLocation(x, y);
					PrintCellToConsole(nextLoc, ConsoleColor.White);
				}
				Console.Write("\n");
			}
		}

		public void PrintCellToConsole(GridLocation location, ConsoleColor color) {
			Console.ForegroundColor = color;
			Console.Write("| {0} ", GetCharAt(location));
			Console.ForegroundColor = ConsoleColor.White;
		}

		public static void PrintResultsToConsole(List<SearchResult> searchResults, Grid grid) {
			int nextX, nextY;
			GridLocation nextLocation;
			Console.WriteLine("--\n");
			foreach (SearchResult sr in searchResults) {
				for (int i = 0; i < sr.Result.Length; i++) {
					nextX = sr.Location.X + sr.Direction.X * i;
					nextY = sr.Location.Y + sr.Direction.Y * i;
					nextLocation = new GridLocation(nextX, nextY);
					grid.PrintCellToConsole(nextLocation, ConsoleColor.DarkYellow);
				}
				Console.Write("\n");
			}
		}

		public bool InsertWord(GridLocation location, GridVector direction, string word) {
			int endLocMultiplier = word.Length - 1;
			int endX = location.X + direction.X * endLocMultiplier;
			int endY = location.Y + direction.Y * endLocMultiplier;
			GridLocation endLocation = new GridLocation(endX, endY);
			if (IsLocationWithinGrid(location) && IsLocationWithinGrid(endLocation)) {
				for (int i = 0; i < word.Length; i++) {
					GridLocation newLocation = new GridLocation(location.X + direction.X * i, location.Y + direction.Y * i);
					this.gridArray[newLocation.X, newLocation.Y] = word[i];
				}
				return true;
			}
			else {
				return false;
			}
		}

		public bool IsLocationWithinGrid(GridLocation location) {
			if ((location.X >= 0 && location.X < this.cols) && (location.Y >= 0 && location.Y < this.rows))
				return true;
			else
				return false;
		}

		public List<SearchResult> Search(string searchTerm) {
			List<SearchResult> results = new List<SearchResult>();
			GridLocation loc;
			for (int x = 0; x < this.cols; x++) {
				for (int y = 0; y < this.rows; y++) {
					loc = new GridLocation(x, y);
					List<SearchResult> r;
					if ((r = this.Search(loc, searchTerm)).Count > 0) {
						results.AddRange(r);
					}
				}
			}
			return results;
		}

		public List<SearchResult> Search(GridLocation location, string searchTerm) {
			List<SearchResult> results = new List<SearchResult>();
			GridVector vector;
			for (int dir = 0; dir < 8; dir++) {
				vector = CardinalDirection.ConvertDirection(dir);
				SearchResult r;
				if ((r = this.Search(location, vector, searchTerm)) != null) {
					results.Add(r);
				}
			}
			return results;
		}

		public SearchResult Search(GridLocation location, GridVector direction, string searchTerm) {
			int endLocMultiplier = searchTerm.Length - 1;
			int endX = location.X + direction.X * endLocMultiplier;
			int endY = location.Y + direction.Y * endLocMultiplier;
			SearchResult result = null;

			if (this.IsLocationWithinGrid(new GridLocation(endX, endY))) {
				for (int i = 0; i < searchTerm.Length; i++) {
					int nextX = location.X + direction.X * i;
					int nextY = location.Y + direction.Y * i;
					if (!(this.gridArray[nextX, nextY] == searchTerm[i])) {
						break;
					}
					else if (i == searchTerm.Length - 1) {
						result = new SearchResult(location, direction, searchTerm);
					}
				}
			}
			return result;
		}
	}
}
