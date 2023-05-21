namespace GC.Engine {
	public static class PointOperations {
		public static Point[] GeneratePoints(int nr, int width, int height, int padding = 10) {
			Random rnd = new();
			Point[] points = new Point[nr];

			int x, y;
			for(int i = 0; i < nr; i++) {
				x = rnd.Next(padding, width - padding);
				y = rnd.Next(padding, height - padding);
				points[i] = new Point(x, y);
			}

			return points;
		}
		public static Point[] GeneratePoints(int nr, GraphicsHandler graphics_handler, int padding = 10) {
			Point[] points = new Point[nr];

			for(int i = 0; i < nr; i++)
				points[i] = new Point(graphics_handler, padding);

			return points;
		}

		public static double DistanceBetweenPoints(Point a, Point b) =>
			//sqrt((b.x - a.x)^2 + (b.y - a.y)^2)
			Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2));



		public static int PointPosToLine(Point start, Point end, Point subject, bool vector = true) =>
			vector ? VectorCrossProduct(start, end, subject) : MatrixDeterminant_3Point(start, end, subject);

		public static int VectorCrossProduct(Point a, Point b, Point c) =>
			// ((y - y0) * (x1 - x0)) - ((x - x0) * (y1 - y0))
			((c.Y - a.Y) * (b.X - a.X)) - ((c.X - a.X) * (b.Y - a.Y));

		public static int MatrixDeterminant_2Point(Point a, Point b) =>
			// aX * bY * 1 - aY * bX * 1
			a.X * b.Y - a.Y * b.X;

		public static int MatrixDeterminant_3Point(Point a, Point b, Point c) =>
			// aX * bY * 1 + bX * cY * 1 + cX * aY * 1 - bY * cX * 1 - cY * aX * 1 - aY * bX * 1
			a.X * b.Y + b.X * c.Y + c.X * a.Y - b.Y * c.X - c.Y * a.X - a.Y * b.X;



		public static Point[] InverseTrigonometricSort(Point[] points) {
			int j = 0;
			Point min = points[0];
			Point[] ordered_points = new Point[points.Length];
			Line[] lines = new Line[points.Length - 1];

			for(int i = 1; i < points.Length; i++) {
				if(PointComparers.down_left.Compare(points[i], min) == -1) {
					min = points[i];
				}
			}

			for(int i = 0; i < points.Length; i++) {
				if(points[i] == min)
					continue;

				lines[j] = new Line(min, points[i]);
				j++;
			}

			Array.Sort(lines, LineComparers.polar_angle_and_distance);

			ordered_points[0] = min;
			for(int i = 1; i < points.Length; i++) {
				ordered_points[i] = lines[i - 1].End;
			}

			return ordered_points;
		}

		public static bool LineIntersect(Line a, Line b) => 
			(PointPosToLine(b.End, b.Start, a.Start) * PointPosToLine(b.End, b.Start, a.End) < 0) && 
			(PointPosToLine(a.End, a.Start, b.Start) * PointPosToLine(a.End, a.Start, b.End) < 0);
	}
}
