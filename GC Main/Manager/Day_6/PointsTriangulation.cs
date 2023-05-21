using GC.Engine;

namespace GC.Manager.Day_6 {
	public class PointsTriangulation: IExercise {

        public PointsTriangulation() { }

        public void Run(Point[] points, GraphicsHandler graphics_handler) {
			graphics_handler.DrawLines(TriangulationOperations.PointArrayTriangulation(points), graphics_handler.ResultColor);
		}
	}
}
