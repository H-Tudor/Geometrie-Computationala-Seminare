namespace GC.Manager.Day_6 {
	public class DrawPolygon: IExercise {

        public DrawPolygon() { }

        public void Run(Point[] points, GraphicsHandler graphics_handler) {
			graphics_handler.DrawSequence(points, graphics_handler.ResultColor);
		}
	}
}
