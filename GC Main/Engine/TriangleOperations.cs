namespace GC.Engine {
	public static class TriangleOperations {

		public static double TriangleArea(Point a, Point b, Point c, bool heron = false) =>
			heron ? TriangleArea_Heron(a, b, c) : TriangleArea_Matrix(a, b, c);

		public static double TriangleArea_Heron(Point a, Point b, Point c) {
			if(PointPosToLine(a, b, c) == 0) {
				return 0;
			}

			double side_A = DistanceBetweenPoints(b, c);
			double side_B = DistanceBetweenPoints(a, c);
			double side_C = DistanceBetweenPoints(a, b);
			double semi_p = (side_A + side_B + side_C) / 2;

			return Math.Sqrt(semi_p * (semi_p - side_A) * (semi_p - side_B) * (semi_p - side_C));
		}

		public static double TriangleArea_Matrix(Point a, Point b, Point c) =>
			PointPosToLine(a, b, c) == 0 ? 0 : Math.Abs(MatrixDeterminant_3Point(a, b, c)) / 2;

		public static double TrianglePerimeter(Point a, Point b, Point c) {
			if(PointPosToLine(a, b, c) == 0) {
				return 0;
			}

			double side_A = DistanceBetweenPoints(b, c);
			double side_B = DistanceBetweenPoints(a, c);
			double side_C = DistanceBetweenPoints(a, b);

			return side_A + side_B + side_C;
		}
	}
}