using GC.Engine;

namespace GC.Manager.Day_7 {
	internal class DiagonalTriangulation: IExercise {

        public DiagonalTriangulation() { }

        public void Run(Point[] points, GraphicsHandler graphics_handler) {
			graphics_handler.DrawSequence(points, graphics_handler.StandardColor);
			graphics_handler.DrawLines(TriangulationOperations.Diagonal(points), graphics_handler.ResultColor);
		}
	}
}
