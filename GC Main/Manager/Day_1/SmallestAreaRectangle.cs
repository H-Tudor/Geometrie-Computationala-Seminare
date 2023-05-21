namespace GC.Manager.Day_1 {
	public class SmallestAreaRectangle: IExercise {

		public SmallestAreaRectangle() { }

		public void Run(Point[] points, GraphicsHandler graphics_handler) {
			Algorithm(points, out int x_min, out int x_max, out int y_min, out int y_max);

			graphics_handler.DrawRectangle(new Point(x_min, y_min), new Point(x_max, y_max), graphics_handler.ResultColor, 2);
		}

		private void Algorithm(Point[] points, out int x_min, out int x_max, out int y_min, out int y_max) {
			x_min = points[0].X;
			y_min = points[0].Y;
			x_max = points[0].X;
			y_max = points[0].Y;

			for(int i = 1; i < points.Length; i++) {
				if(points[i].X < x_min)
					x_min = points[i].X;
				else if(points[i].X > x_max)
					x_max = points[i].X;

				if(points[i].Y < y_min)
					y_min = points[i].Y;
				else if(points[i].Y > y_max)
					y_max = points[i].Y;
			}
		}
	}
}
