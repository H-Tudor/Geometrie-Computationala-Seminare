namespace GC.Engine.LineComparer {
	public class SegmentLength: IComparer<Line> {
		public int Compare(Line a, Line b) {
			if (a == null || b == null)
				throw new ArgumentNullException();

			return a.Length.CompareTo(b.Length);
		}
	}
}
