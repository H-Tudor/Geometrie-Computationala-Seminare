namespace GC.Engine {

	public static class TriangulationOperations {

		public static Line[] PointArray(Point[] points) {
			List<Line> lines = new List<Line>();
			List<Line> edges = new List<Line>();

			bool valid;
			for(int i = 0; i < points.Length - 1; i++) {
				for(int j = 0; j < points.Length; j++) {
					if(i == j)
						continue;

					lines.Add(new Line(points[i], points[j]));
				}
			}

			lines.Sort(LineComparers.segment_length);
			edges.Add(lines[0]);

			for(int i = 1; i < lines.Count; i++) {
				valid = true;
				for(int j = 0; j < edges.Count; j++) {
					if(LineIntersect(lines[i], edges[j])) {
						valid = false;
						break;
					}
				}

				if(valid)
					edges.Add(lines[i]);
			}


			return edges.ToArray();
		}

		public static Line[] ConvexPolygon(Point[] points) {
			List<Line> edges = new List<Line>();

			for(int i = 2; i < points.Length - 1; i++) {
				edges.Add(new Line(points[0], points[i]));
			}

			return edges.ToArray();
		}

		public static Line[] Diagonal(Point[] points) {
			List<Line> diagonals = new List<Line>();

			for(int i = 0; i < points.Length - 2; i++) {
				for(int j = i + 2; j < points.Length; j++) {
					if(i == 0 && j == points.Length - 1)
						break;

					if(PolygonOperations.CheckPolygonDiagonal(i, j, points, diagonals))
						diagonals.Add(new Line(points[i], points[j]));

					if(diagonals.Count == points.Length - 3)
						return diagonals.ToArray();
				}
			}

			return diagonals.ToArray();
		}

		public static Line[] Otectometry(Point[] points) {
			List<Line> diagonals = new List<Line>();
			List<Point> new_points = points.ToList();
			int one, two;

			while(new_points.Count > 3) {
				for(int i = 0; i < new_points.Count; i++) {
					one = i < new_points.Count - 1 ? i + 1 : 0;
					two = i < new_points.Count - 2 ? i + 2 : (i + 2) % new_points.Count;

					if(PolygonOperations.CheckPolygonDiagonal(i, two, points.ToArray(), new List<Line>())) {
						diagonals.Add(new Line(new_points[i], new_points[two]));
						new_points.RemoveAt(one);
						break;
					}
				}
			}

			return diagonals.ToArray();
		}
	}
}
