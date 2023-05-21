namespace GC.Engine {
	public static class LineComparers {

		public static IComparer<Line> segment_length = new LineComparer.SegmentLength();
		public static IComparer<Line> polar_angle_and_distance = new LineComparer.PolarAngleAndDistanceComparer();
	}
}
