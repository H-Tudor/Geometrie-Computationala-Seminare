using GC.Manager;

namespace GC.Resource {
	public static class Config {

		public static bool DEV = true;

		public static readonly IExercise[][] EXERCISES = new IExercise[][] {
			new IExercise[]{
				new Manager.Day_1.SmallestAreaRectangle(),
				new Manager.Day_1.ClosestNeighbor(),
				new Manager.Day_1.MaximumExclusionCircle(),
			},
			new IExercise[] {
				new Manager.Day_2.AllPointsCloserThanNToQ(),
				new Manager.Day_2.SmallestAreaTriangle(),
				new Manager.Day_2.MinimumEnclosingCircle(),
			},
			new IExercise[] {
				new Manager.Day_3.MinLengthsSum(),
				new Manager.Day_3.AllSegmentIntersections(),
			},
			new IExercise[] {
				new Manager.Day_4.ConvexHullWeak(),
				new Manager.Day_4.ConvexHullAndrew(),
			},
			new IExercise[] {
				new Manager.Day_5.ConvexHullJarvis(),
				new Manager.Day_5.ConvexHullGraham(),
			},
			new IExercise[] {
				new Manager.Day_6.PointsTriangulation(),
				new Manager.Day_6.DrawPolygon(),
				new Manager.Day_6.PolygonTriangulation(),
			},
			new IExercise[] {
				new Manager.Day_7.DiagonalTriangulation()
			},
			new IExercise[] {
				new Manager.Day_8.OtectometryTriangulation(),
				new Manager.Day_8.PolygonSumArea(),
				//new Manager.Day_8.TriangulationColorGraph(),
			},
			//new IExercise[] {
			//	new Manager.Day_9.MonotonePolygonPartitioning()
			//}
		};
	}
}
