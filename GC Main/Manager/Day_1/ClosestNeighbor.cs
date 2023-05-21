namespace GC.Manager.Day_1 {
	public class ClosestNeighbor: IExercise {

		public ClosestNeighbor() { }

		public void Run(Point[] points, GraphicsHandler graphics_handler) {
			Point[] aux_points = GeneratePoints(new Random().Next(points.Length, points.Length * 2), graphics_handler);
			graphics_handler.DrawPoints(aux_points, graphics_handler.Aux_1Color);

			Point[] neighbors = Algorithm(points, aux_points);

			for(int i = 0; i < points.Length; i++) {
				graphics_handler.DrawSequence(new Point[] { points[i], neighbors[i] }, graphics_handler.ResultColor);
			}
		}

		private Point[] Algorithm(Point[] points, Point[] aux_points) {
			Point[] neighbors = new Point[points.Length];
			double min_distance;
			double current_distance;
			for(int i = 0; i < points.Length; i++) {
				min_distance = DistanceBetweenPoints(points[i], aux_points[0]);
				neighbors[i] = aux_points[0];
				for(int j = 1; j < aux_points.Length; j++) {
					current_distance = DistanceBetweenPoints(points[i], aux_points[j]);
					if(current_distance < min_distance) {
						min_distance = current_distance;
						neighbors[i] = aux_points[j];
					}
				}
			}

			return neighbors;
		}
	}
}
