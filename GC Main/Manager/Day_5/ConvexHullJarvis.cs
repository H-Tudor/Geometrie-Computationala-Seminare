namespace GC.Manager.Day_5 {
	public class ConvexHullJarvis: IExercise {

        public ConvexHullJarvis() { }

        public void Run(Point[] points, GraphicsHandler graphics_handler) {
			graphics_handler.DrawSequence(
				Engine.ConvexHull.Jarvis(points),
				graphics_handler.ResultColor,
				size: 2
			);
		}
	}
}
