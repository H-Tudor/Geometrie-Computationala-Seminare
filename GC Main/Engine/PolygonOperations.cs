namespace GC.Engine {
	public static class PolygonOperations {
		public static Point[] GeneratePolygonPoints(Point center, float radius, int nr_of_points, double rotation_angle = 0) {
			Point[] bounds = new Point[nr_of_points];
			double alpha = Math.PI * 2 / nr_of_points;
			rotation_angle -= Math.PI / 2;

			// N - number of sides, n - number of vertices, theta - constant rotation angle
			// x[n] = r * cos(2 * pi * n / N + theta) + Centre.x
			// y[n] = r * sin(2 * pi * n / N + theta) + Centre.y

			for(int i = 0; i < nr_of_points; i++) {
				int x = (int)(center.X + radius * Math.Cos(i * alpha + rotation_angle));
				int y = (int)(center.Y + radius * Math.Sin(i * alpha + rotation_angle));
				bounds[i] = new Point(x, y);
			}

			return bounds;
		}

		public static double PolygonAreaSum(Point[] points) {
			points = InverseTrigonometricSort(points).Reverse().ToArray();
			double area = 0;
			for(int i=0; i < points.Length; i++) {
				area += points[i].X * points[(i + 1) % points.Length].Y - points[i].Y * points[(i + 1) % points.Length].X;
			}

			return area / 2;
		}
	}
}
