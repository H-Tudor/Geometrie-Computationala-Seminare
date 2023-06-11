using GC.Engine;

namespace GC.Manager.Day_8 {
	public class PolygonSumArea: IExercise {
		public void Run(Point[] points, GraphicsHandler graphics_handler) {
			graphics_handler.DrawSequence(points, graphics_handler.StandardColor);
			graphics_handler.DrawText(
				PolygonOperations.PolygonAreaSum(points).ToString(),
				new Point(10, 10), graphics_handler.ResultColor
			);
		}
	}
}
