namespace GC.Manager.Day_4 {
	public class ConvexHullAndrew: IExercise {

        public ConvexHullAndrew() { }

        public void Run(Point[] points, GraphicsHandler graphics_handler) {
			graphics_handler.DrawSequence(
				Engine.ConvexHull.Andrew(points),
				graphics_handler.ResultColor,
				size: 2
			);
		}
	}
}
