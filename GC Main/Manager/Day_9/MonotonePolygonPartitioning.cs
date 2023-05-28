using GC.Engine;

namespace GC.Manager.Day_9 {
	public class MonotonePolygonPartitioning: IExercise {
		public void Run(Point[] points, GraphicsHandler graphics_handler) {
			graphics_handler.DrawSequence(points, graphics_handler.StandardColor);
			graphics_handler.DrawLines(PolygonOperations.MonotonePolygonPartitioning(points), graphics_handler.ResultColor);
		}
	}
}
