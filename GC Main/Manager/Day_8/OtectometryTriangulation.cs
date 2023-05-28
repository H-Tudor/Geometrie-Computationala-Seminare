using GC.Engine;

namespace GC.Manager.Day_8 {
	public class OtectometryTriangulation: IExercise {
		public void Run(Point[] points, GraphicsHandler graphics_handler) {
			graphics_handler.DrawSequence(points, graphics_handler.StandardColor);
			graphics_handler.DrawLines(TriangulationOperations.Otectometry(points), graphics_handler.ResultColor);
		}
	}
}
