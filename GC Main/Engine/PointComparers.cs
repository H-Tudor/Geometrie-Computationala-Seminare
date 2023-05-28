namespace GC.Engine {
	public static class PointComparers {
		public static IComparer<Point> down_left = new PointComparer.DownLeft();
		public static IComparer<Point> left_down = new PointComparer.LeftDown();
		public static IComparer<Point> cross_product = new PointComparer.CrossProduct();
		public static IComparer<Point> up_left = new PointComparer.UpLeft();
	}
}