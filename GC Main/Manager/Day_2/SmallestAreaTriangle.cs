using static GC.Engine.PointComparers;
using static GC.Engine.TriangleOperations;

namespace GC.Manager.Day_2 {
	public class SmallestAreaTriangle: IExercise {

		public SmallestAreaTriangle() { }

		public void Run(Point[] points, GraphicsHandler graphics_handler) {
			graphics_handler.DrawSequence(OptimizedAlgorithm(points), graphics_handler.ResultColor);
		}

		public Point[] OptimizedAlgorithm(Point[] points) {
			Point[] triangle_vertexes = new Point[3];
			Array.Sort(points, cross_product);

			double min_area = TriangleArea(points[0], points[1], points[2]);
			double min_perimeter = TrianglePerimeter(points[0], points[1], points[2]);
			double current_area;
			double current_perimeter;

			for(int i = 1; i < points.Length - 2; i++) {
				current_area = TriangleArea(points[i], points[i + 1], points[i + 2]);
				current_perimeter = TrianglePerimeter(points[i], points[i + 1], points[i + 2]);

				if(current_area < min_area && current_area > 0 && min_area > 0) {
					triangle_vertexes[0] = points[i];
					triangle_vertexes[1] = points[i + 1];
					triangle_vertexes[2] = points[i + 2];
					min_area = current_area;
					min_perimeter = current_perimeter;
				} else if(current_area == min_area && (current_perimeter < min_perimeter && current_perimeter != 0)) {
					triangle_vertexes[0] = points[i];
					triangle_vertexes[1] = points[i + 1];
					triangle_vertexes[2] = points[i + 2];
					min_area = current_area;
					min_perimeter = current_perimeter;
				}
			}

			return triangle_vertexes;
		}

		public Point[] BasicAlgorithm(Point[] points) {
			Point[] triangle_vertexes = new Point[3];

			double min_area = TriangleArea(points[0], points[1], points[2]);
			double min_perimeter = TrianglePerimeter(points[0], points[1], points[2]);
			double current_area;
			double current_perimeter;

			for(int i = 0; i < points.Length - 2; i++) {
				for(int j = i + 1; j < points.Length - 1; j++) {
					for(int k = j + 1; k < points.Length; k++) {
						current_area = TriangleArea(points[i], points[j], points[k]);
						current_perimeter = TrianglePerimeter(points[i], points[j], points[k]);

						if(current_area < min_area && current_area > 0 && min_area > 0) {
							triangle_vertexes[0] = points[i];
							triangle_vertexes[1] = points[j];
							triangle_vertexes[2] = points[k];
							min_area = current_area;
							min_perimeter = current_perimeter;
						} else if(current_area == min_area && (current_perimeter < min_perimeter && current_perimeter != 0)) {
							triangle_vertexes[0] = points[i];
							triangle_vertexes[1] = points[j];
							triangle_vertexes[2] = points[k];
							min_area = current_area;
							min_perimeter = current_perimeter;
						}
					}
				}
			}

			return triangle_vertexes;
		}
	}
}