using GC.UI;

namespace GC.Manager
{
    public static class VisualTests {
		private static void Test_PointPosToLine(Resource.Point[] points, GraphicsHandler graphics_handler, int relative_pos) {
			graphics_handler.DrawSequence(new Resource.Point[] { points[0], points[1] }, graphics_handler.StandardColor);

			if(relative_pos < 0) {
				graphics_handler.DrawSequence(new Resource.Point[] { points[1], points[2] }, graphics_handler.Aux_1Color);
			} else if(relative_pos > 0) {
				graphics_handler.DrawSequence(new Resource.Point[] { points[1], points[2] }, graphics_handler.ResultColor);
			} else {
				graphics_handler.DrawSequence(new Resource.Point[] { points[1], points[2] }, graphics_handler.StandardColor);
			}
		}

		public static void Test_PointPosToLine_MatrixDeterminant(Resource.Point[] points, GraphicsHandler graphics_handler) {
			int relative_pos = PointPosToLine(points[0], points[1], points[2], false);
			Test_PointPosToLine(points, graphics_handler, relative_pos);
		}

		public static void Test_PointPosToLine_VectorCrossProduct(Resource.Point[] points, GraphicsHandler graphics_handler) {
			int relative_pos = PointPosToLine(points[0], points[1], points[2], true);
			Test_PointPosToLine(points, graphics_handler, relative_pos);
		}

	}
}
