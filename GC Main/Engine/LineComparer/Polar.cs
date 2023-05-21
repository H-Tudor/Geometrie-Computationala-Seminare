namespace GC.Engine.LineComparer {
	public class PolarComparer: IComparer<Line> {

		public int Compare(Line a, Line b) {
			if(a == null || b == null)
				throw new ArgumentNullException();

			if(a.Start != b.Start) {
				throw new ArgumentException("Lines don't share reference point");
			}

			int polar_diff = PointPosToLine(a.End, a.Start, b.End);

			if(polar_diff != 0)
				return polar_diff > 0 ? -1 : 1;
			else
				return a.Length > b.Length ? -1 : 1;
		}
	}
}
