namespace GC.Manager.Day_5 {
	public class ConvexHullGraham: IExercise {

		public ConvexHullGraham() { }

		public void Run(Point[] points, GraphicsHandler graphics_handler) {
			graphics_handler.DrawSequence(
				Engine.ConvexHull.Graham(points),
				graphics_handler.ResultColor, 
				size: 2
			);
		}
	}
}
