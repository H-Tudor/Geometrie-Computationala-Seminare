namespace GC.Manager.Day_1 {
	public class MaximumExclusionCircle: IExercise {
		
		public MaximumExclusionCircle() { }

		public void Run(Point[] points, GraphicsHandler graphics_handler) {
			Point circle_center = new Point(graphics_handler);
			graphics_handler.DrawPoints(new Point[] { circle_center }, graphics_handler.Aux_1Color);

			int final_diameter = Algorithm(points, circle_center);
			graphics_handler.DrawCircle(circle_center, final_diameter, graphics_handler.ResultColor);
		}

		private int Algorithm(Point[] points, Point circle_center) {
			double current_distance;
			double min_distance = DistanceBetweenPoints(circle_center, points[0]);

			for(int i = 1; i < points.Length; i++) {
				current_distance = DistanceBetweenPoints(circle_center, points[i]);
				if(current_distance < min_distance)
					min_distance = current_distance;
			}

			int final_diameter = (int)min_distance * 2 - 1;
			return final_diameter;
		}
	}
}
