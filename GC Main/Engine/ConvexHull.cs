namespace GC.Engine {
	public static class ConvexHull {
		public static Point[] Graham(Point[] points) { 
			List<Point> vertexes = new List<Point>();
			points = InverseTrigonometricSort(points);

			int k = 2;
			vertexes.Add(points[0]);
			vertexes.Add(points[1]);
			vertexes.Add(points[2]);

			for(int i = 3; i < points.Length; i++) {
				while(PointPosToLine(vertexes[k-1], points[i], vertexes[k]) < 0) {
					vertexes.RemoveAt(k);
					k--;
				}
				vertexes.Add(points[i]);
				k++;
			}

			return InverseTrigonometricSort(vertexes.ToHashSet().ToArray());
		}

		public static Point[] Jarvis(Point[] points) {
			Point min = points[0];
			List<Point> vertexes = new List<Point>();

			for(int i = 1; i <  points.Length; i++) {
				if(PointComparers.down_left.Compare(points[i], min) == -1) {
					min = points[i];
				}
			}
			vertexes.Add(min);

			int j = 0;
			bool valid = true;
			Random rnd = new Random();
			Point selected_point;

			while(valid) {
				selected_point = points[rnd.Next(points.Length)];
				while(selected_point == vertexes[j])
					selected_point = points[rnd.Next(points.Length)];

				for(int i = 0; i < points.Length; i++) {
					if(PointPosToLine(vertexes[j], selected_point, points[i]) > 0) {
						selected_point = points[i];
					}
				}

				if(selected_point != vertexes[0]) {
					vertexes.Add(selected_point);
					j++;
				} else {
					valid = false;
				}
			}
		
			return InverseTrigonometricSort(vertexes.ToHashSet().ToArray());
		}

		public static Point[] Andrew(Point[] points) {
			List<Point> vertexes = new List<Point>();
			Array.Sort(points, PointComparers.left_down);

			int j = 1;
			List<Point> upper_hull = new List<Point>();
			List<Point> lower_hull = new List<Point>();

			upper_hull.Add(points[0]);
			upper_hull.Add(points[1]);

			for(int i = 2; i < points.Length; i++) {
				upper_hull.Add(points[i]);
				j++;

				while(j > 1 && PointPosToLine(upper_hull[j - 2], upper_hull[j - 1], upper_hull[j]) < 1) {
					upper_hull.RemoveAt(j - 1);
					j--;
				}

			}

			j = 1;
			lower_hull.Add(points[points.Length - 1]);
			lower_hull.Add(points[points.Length - 2]);

			for(int i = points.Length - 3; i >= 0; i--) {
				lower_hull.Add(points[i]);
				j++;

				while(j > 1 && PointPosToLine(lower_hull[j - 2], lower_hull[j - 1], lower_hull[j]) < 1) {
					lower_hull.RemoveAt(j - 1);
					j--;
				}

			}


			vertexes.AddRange(upper_hull.ToArray());
			vertexes.AddRange(lower_hull.ToArray());


			return InverseTrigonometricSort(vertexes.ToHashSet().ToArray());
		}


		public static Point[] Weak(Point[] points) {
			HashSet<Point> vertexes = new HashSet<Point>();

			bool valid;
			for(int i = 0; i < points.Length; i++) {
				for(int j = 0; j < points.Length; j++) {
					if(i == j)
						continue;

					valid = true;
					for(int k = 0; k < points.Length; k++) {
						if(i == k || j == k)
							continue;

						if(PointPosToLine(points[i], points[j], points[k], vector: false) >= 0) {
							valid = false;
							break;
						}
					}

					if(valid == true) {
						vertexes.Add(points[i]);
						vertexes.Add(points[j]);
					}
				}
			}

			return InverseTrigonometricSort(vertexes.ToArray());
		}
	}
}
