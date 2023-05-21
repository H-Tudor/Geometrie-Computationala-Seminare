namespace GC.Manager.Day_2 {
	public class AllPointsCloserThanNToQ: IExercise {
		
		public AllPointsCloserThanNToQ() { }
		
		public void Run(Point[] points, GraphicsHandler graphics_handler) {
			Point circle_center = new(graphics_handler);
			int max_distance = new Random().Next(Math.Min(graphics_handler.Width, graphics_handler.Height) / 2);
			graphics_handler.DrawPoints(new Point[] { circle_center }, graphics_handler.Aux_1Color, label: true, label_text: max_distance.ToString());

			Point[] close_points = Algorithm(points, circle_center, max_distance);
			graphics_handler.DrawPoints(close_points, graphics_handler.ResultColor);
		}

		private Point[] Algorithm(Point[] points, Point circle_center, int max_distance) {
			List<Point> close_points = new();
			for(int i = 0; i < points.Length; i++) {
				if(DistanceBetweenPoints(circle_center, points[i]) <= max_distance) {
					close_points.Add(points[i]);
				}
			}

			return close_points.ToArray();
		}
	}
}
