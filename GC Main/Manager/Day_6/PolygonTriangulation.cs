using GC.Engine;

namespace GC.Manager.Day_6 {
	public class PolygonTriangulation: IExercise {

        public PolygonTriangulation() { }

        public void Run(Point[] points, GraphicsHandler graphics_handler) {
			Point center = new Point(graphics_handler.Width / 2, graphics_handler.Height / 2);
			float radius = Math.Min(graphics_handler.Width, graphics_handler.Height) / 2 - 10;
			graphics_handler.ClearCanvas();

			points = PolygonOperations.GeneratePolygonPoints(center, radius, points.Length);
			graphics_handler.DrawSequence(points, graphics_handler.StandardColor, label: Config.DEV);
			graphics_handler.DrawLines(TriangulationOperations.ConvexPolygon(points), graphics_handler.ResultColor);


		}
	}
}
