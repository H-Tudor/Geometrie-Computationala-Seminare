namespace GC.Manager.Day_4 {
	public class ConvexHullWeak: IExercise {

        public ConvexHullWeak() { }

        public void Run(Point[] points, GraphicsHandler graphics_handler) {
			graphics_handler.DrawSequence(
				Engine.ConvexHull.Weak(points),
				graphics_handler.ResultColor,
				size: 2
			);
		}
	}
}
