namespace GC.Engine.PointComparer {
	public class CrossProduct: IComparer<Point> {
		public int Compare(Point a, Point b) {
			if(a is null || b is null)
				throw new NullReferenceException();

			int cross_product = MatrixDeterminant_2Point(a, b);
			return cross_product < 0 ? -1 : 1;
		}
	}
}
