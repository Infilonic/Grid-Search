using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridSearch
{
	class CardinalDirection
	{
		public readonly static GridVector NORTH = new GridVector(0, -1);
		public readonly static GridVector NORTHEAST = new GridVector(1, -1);
		public readonly static GridVector EAST = new GridVector(1, 0);
		public readonly static GridVector SOUTHEAST = new GridVector(1, 1);
		public readonly static GridVector SOUTH = new GridVector(0, 1);
		public readonly static GridVector SOUTHWEST = new GridVector(-1, 1);
		public readonly static GridVector WEST = new GridVector(-1, 0);
		public readonly static GridVector NORTHWEST = new GridVector(-1, -1);

		public int Count {
			get { return 8; }
		}

		public static int ConvertDirection(GridVector vector) {
			if (vector.Equals(NORTH))
				return 0;
			else if (vector.Equals(NORTHEAST))
				return 1;
			else if (vector.Equals(EAST))
				return 2;
			else if (vector.Equals(SOUTHEAST))
				return 3;
			else if (vector.Equals(SOUTH))
				return 4;
			else if (vector.Equals(SOUTHWEST))
				return 5;
			else if (vector.Equals(WEST))
				return 6;
			else if (vector.Equals(NORTHWEST))
				return 7;
			return -1;
		}

		public static GridVector ConvertDirection(int vector) {
			switch (vector) {
				case 0:
					return NORTH;
				case 1:
					return NORTHEAST;
				case 2:
					return EAST;
				case 3:
					return SOUTHEAST;
				case 4:
					return SOUTH;
				case 5:
					return SOUTHWEST;
				case 6:
					return WEST;
				case 7:
					return NORTHWEST;
				default:
					return new GridVector(int.MaxValue, int.MaxValue);
			}
		}

		public static string ToString(GridVector vector) {
			switch (ConvertDirection(vector)) {
				case 0:
					return "NORTH";
				case 1:
					return "NORTHEAST";
				case 2:
					return "EAST";
				case 3:
					return "SOUTHEAST";
				case 4:
					return "SOUTH";
				case 5:
					return "SOUTHWEST";
				case 6:
					return "WEST";
				case 7:
					return "NORTHWEST";
				default:
					return "NO DIR FOUND";
			}
		}

		public static string ToString(int vector) {
			return ToString(ConvertDirection(vector));
		}
	}
}
