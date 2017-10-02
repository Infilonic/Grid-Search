using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridSearch
{
	class Program
	{
		private static Grid niceGrid;
		protected static void Main(string[] args) {
			Console.WriteLine("Grid dimensions:");
			niceGrid = new Grid(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));

			char[] randomPool = new char[26]; // { 'o', 'a', 'e', '2', 'm', 's', 'l', '7', '3', 'x', '5', 'z', 't', 'n', 'f', 'ü', 'i', 'g' };

			for (int i = 97; i < 123; i++) {
				randomPool[i - 97] = (char)i;
			}

			niceGrid.LetterPool = randomPool;
			niceGrid.PopulateGrid();
			while (Call()) ;
		}

		private static bool Call() {
			Console.Clear();
			Console.WriteLine("i: insert\ns: search\np: print\ng: Print Grid\nq: quit\n\n");
			string action = Console.ReadLine();
			switch (action) {
				case "i":
					Insert();
					break;
				case "s":
					Search();
					break;
				case "p":
					PrintSearch(null);
					break;
				case "g":
					niceGrid.PrintToConsole();
					Console.Write("\n\n---\nPress any key...\n");
					Console.ReadKey();
					break;
				case "q":
					return false;
				default:
					break; ;
			}
			return true;
		}

		private static void Insert() {
			Console.Clear();
			Console.WriteLine("X coord:");
			int x = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Y coord:");
			int y = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Dir:");
			int dir = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Word:");
			niceGrid.InsertWord(new GridLocation(x, y), CardinalDirection.ConvertDirection(dir), Console.ReadLine());
		}

		private static void Search() {
			List<SearchResult> srList;
			Console.Clear();
			Console.WriteLine("Searchterm:");
			if ((srList = niceGrid.Search(Console.ReadLine())).Count > 0) {
				Console.WriteLine("Match, print? y/n");
				switch (Console.ReadLine()) {
					case "y":
						PrintSearch(srList);
						break;
					default:
						break;
				}
			}
		}

		private static void PrintSearch(List<SearchResult> srList) {
			Console.Clear();
			if (srList != null && srList.Count > 0) {
				foreach (SearchResult sr in srList) {
					Console.WriteLine("\n\n---");
					Console.WriteLine("Location X: {0}, Y: {1}", sr.Location.X, sr.Location.Y);
					Console.WriteLine("Direction: {0}", CardinalDirection.ToString(sr.Direction));
					Console.WriteLine("String: {0}, Length: {1}", sr.Result, sr.Result.Length);
				}
			}
			Console.Write("\n\n---\nPress any key...\n");
			Console.ReadKey();
		}
	}
}
