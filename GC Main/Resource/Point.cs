using GC.UI;

namespace GC.Resource
{
    public class Point {
		public int X { get; private set; }
		public int Y { get; private set; }

		public Point() : this(0, 0) { }

		public Point(GraphicsHandler handler, int padding = 10) {
			Random rnd = new();

			X = rnd.Next(padding, handler.Width - padding);
			Y = rnd.Next(padding, handler.Height - padding);
		}

		public Point(int x, int y) {
			X = x;
			Y = y;
		}

		public override string ToString() {
			return $"({X}, {Y})";
		}

		public System.Drawing.Point ToDraw() {
			return new System.Drawing.Point(X, Y);
		}
	}
}
