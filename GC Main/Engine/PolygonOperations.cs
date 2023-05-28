using System.Windows.Forms.VisualStyles;

namespace GC.Engine {
	public static class PolygonOperations {
		public static Point[] GeneratePolygonPoints(Point center, float radius, int nr_of_points, double rotation_angle = 0) {
			Point[] bounds = new Point[nr_of_points];
			double alpha = Math.PI * 2 / nr_of_points;
			rotation_angle -= Math.PI / 2;

			// N - number of sides, n - number of vertices, theta - constant rotation angle
			// x[n] = r * cos(2 * pi * n / N + theta) + Centre.x
			// y[n] = r * sin(2 * pi * n / N + theta) + Centre.y

			for(int i = 0; i < nr_of_points; i++) {
				int x = (int)(center.X + radius * Math.Cos(i * alpha + rotation_angle));
				int y = (int)(center.Y + radius * Math.Sin(i * alpha + rotation_angle));
				bounds[i] = new Point(x, y);
			}

			return bounds;
		}

		public static double PolygonAreaSum(Point[] points) {
			points = InverseTrigonometricSort(points).Reverse().ToArray();
			double area = 0;
			for(int i = 0; i < points.Length; i++) {
				area += points[i].X * points[(i + 1) % points.Length].Y - points[i].Y * points[(i + 1) % points.Length].X;
			}

			return area / 2;
		}

		public static bool DiagonalPolygonSideIntersect(Line diagonal, Point[] points) {
			Line edge;
			bool start_check, end_check;
			for(int i = 0; i < points.Length; i++) {
				edge = new Line(points[i], points[(i + 1) % points.Length]);

				start_check = edge.Start == diagonal.Start || edge.End == diagonal.Start;
				end_check = edge.Start == diagonal.End || edge.End == diagonal.End;

				if(start_check || end_check)
					continue;

				if(LineIntersect(diagonal, edge)) {
					return false;
				}
			}

			return true;
		}

		public static bool DiagonalInsidePolygon(int start, int end, Point[] points) {
			int corner_start = start == 0 ? points.Length - 1 : start - 1;

			bool convex_corner = PointPosToLine(points[corner_start], points[start], points[start + 1]) < 0;
			int angle_1 = -1 * PointPosToLine(points[start], points[end], points[start + 1]);
			int angle_2 = -1 * PointPosToLine(points[start], points[corner_start], points[end]);

			return (convex_corner && angle_1 < 0 && angle_2 < 0) || !(angle_1 > 0 && angle_2 > 0);
		}

		public static bool CheckPolygonDiagonal(int start, int end, Point[] points, List<Line> diagonals) {
			bool edge_intersect_check;
			bool diagonals_intersect_check;
			bool inside_polygon_check;
			Line current_diagonal;

			current_diagonal = new Line(points[start], points[end]);
			edge_intersect_check = DiagonalPolygonSideIntersect(current_diagonal, points);

			diagonals_intersect_check = true;
			foreach(Line diagonal in diagonals) {
				if(LineIntersect(current_diagonal, diagonal)) {
					diagonals_intersect_check = false;
					break;
				}
			}

			inside_polygon_check = DiagonalInsidePolygon(start, end, points);

			return (edge_intersect_check && diagonals_intersect_check && inside_polygon_check);
		}

		public static Line[] MonotonePolygonPartitioning(Point[] points) {
			static int check_peak_valley(Point start, Point mid, Point end) => (start.Y < mid.Y && end.Y < mid.Y) ? 1 : (start.Y > mid.Y && end.Y > mid.Y) ? -1 : 0;

			static Line GetNextDiagonal(int start, int min_end, Point[] points, bool flow) {
				if(flow) {
					for(int i = min_end; i >= 0; i--) {
						if(CheckPolygonDiagonal(start, i, points, new List<Line>()))
							return new Line(points[start], points[i]);
					}
				} else {
					for(int i = min_end; i < points.Length; i++) {
						if(CheckPolygonDiagonal(start, i, points, new List<Line>()))
							return new Line(points[start], points[i]);
					}
				}

				return null;
			}


			Line diagonal;
			List<Line> edges = new List<Line>();
			int corner_start, corner_end, check;

			points = InverseTrigonometricSort(points);
			Array.Sort(points, PointComparers.up_left);
			for(int i = 0; i < points.Length; i++) {
				corner_start = i == 0 ? points.Length - 1 : i - 1;
				corner_end = i == points.Length - 1 ? 0 : i + 1;

				if(PointPosToLine(points[corner_start], points[i], points[corner_end]) > 0) {
					check = check_peak_valley(points[corner_start], points[i], points[corner_end]);

					if(check > 0) {
						diagonal = GetNextDiagonal(i, corner_start, points, true);

						if(diagonal != null)
							edges.Add(diagonal);
					} else if(check < 0) {
						diagonal = GetNextDiagonal(i, corner_end, points, false);

						if(diagonal != null)
							edges.Add(diagonal);
					}
				}
			}

			return edges.ToArray();
		}
	}

}
