namespace GC.Engine.PointComparer {
	public class DownLeft: IComparer<Point> {
		public int Compare(Point a, Point b) {
			if(a is null || b is null)
				throw new NullReferenceException();

			if(a.Y < b.Y)
				return -1;
			else if(a.Y > b.Y)
				return 1;
			else if(a.X < b.X)
				return -1;
			else if(a.X > b.X)
				return 1;

			return 0;
		}
	}
}
