namespace GC.Engine {

	public static class TriangulationOperations {

		public static Line[] PointArrayTriangulation(Point[] points) {
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

		public static Line[] ConvexPolygonTriangulation(Point[] points) {
			List<Line> edges = new List<Line>();

			for(int i = 2; i < points.Length - 1; i++) { 
				edges.Add(new Line(points[0], points[i]));
			}

			return edges.ToArray();		
		}
	}
}
