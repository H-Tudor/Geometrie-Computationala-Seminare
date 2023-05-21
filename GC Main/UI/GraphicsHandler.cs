using System.Drawing;

namespace GC.UI {
	public static class GraphicsHelpers {

		public static System.Drawing.Point[] ToDraw(this Resource.Point[] points) {
			List<System.Drawing.Point> draw_points = new();

			foreach(Resource.Point point in points) {
				draw_points.Add(point.ToDraw());
			}

			return draw_points.ToArray();
		}
	}


	public class GraphicsHandler {

		public int Width { get; private set; }

		public int Height { get; private set; }


		private Bitmap Canvas { get; set; }

		private Graphics Handler { get; set; }

		private PictureBox PictureBox { get; set; }


		public Color BackgroundColor { get; private set; }

		public Color StandardColor { get; private set; }

		public Color ResultColor { get; private set; }

		public Color Aux_1Color { get; private set; }

		public Color Aux_2Color { get; private set; }

		public GraphicsHandler(PictureBox pictureBox) {
			Width = pictureBox.Width;
			Height = pictureBox.Height;

			PictureBox = pictureBox;
			Canvas = new Bitmap(Width, Height);
			Handler = Graphics.FromImage(Canvas);
			BackgroundColor = pictureBox.BackColor;

			StandardColor = Color.Black;
			ResultColor = Color.Red;
			Aux_1Color = Color.Blue;
			Aux_2Color = Color.LightGray;

			ClearCanvas();
		}

		public void ClearCanvas() {
			Handler.Clear(BackgroundColor);
			UpdateCanvas();
		}

		public void UpdateCanvas() {
			PictureBox.Image = Canvas;
		}

		public void DrawPoints(Resource.Point[] points, Color color, int size = 1, bool fill = true, bool label = false, string label_text = "") {
			for(int i = 0; i < points.Length; i++) {
				if(label) {
					if(label_text != "") {
						DrawText(label_text, points[i], color, size);
					} else {
						DrawText(i.ToString(), points[i], color, size);
					}
				}
				DrawCircle(points[i], size, color, size, fill);
			}

		}

		public void DrawSequence(Resource.Point[] points, Color color, int size = 2, bool label = false) {
			if(points.Length == 0)
				return;

			Pen pen = new(color, size);

			DrawPoints(points, color, fill: true, label: label);

			for(int i = 0; i < points.Length; i++) {
				Handler.DrawLine(pen, points[i].ToDraw(), points[(i + 1) % points.Length].ToDraw());
			}
		}

		public void DrawLines(Line[] lines, Color color, int size = 2, bool label = false) {
			if(lines.Length == 0)
				return;

			Pen pen = new(color, size);

			for(int i = 0; i < lines.Length; i++) {
				if(label) {
					DrawText($"{i}s", lines[i].Start, color, size);
					DrawText($"{i}e", lines[i].End, color, size);
				}

				Handler.DrawLine(pen, lines[i].Start.ToDraw(), lines[i].End.ToDraw());
			}
		}

		public void DrawRectangle(Resource.Point a, Resource.Point b, Color color, int size = 2) {
			if(a == null || b == null) {
				return;
			}

			Pen pen = new(color, size);

			int x = Math.Min(a.X, b.X);
			int y = Math.Min(a.Y, b.Y);
			int width = Math.Abs(b.X - a.X);
			int height = Math.Abs(b.Y - a.Y);

			Handler.DrawRectangle(pen, x, y, width, height);
		}

		public void DrawCircle(Resource.Point center, int radius, Color color, int size = 2, bool fill = false) {
			Pen pen = new(color, size);
			Brush brush = new SolidBrush(color);

			if(fill)
				Handler.FillEllipse(brush, center.X - radius / 2, center.Y - radius / 2, radius + 1, radius + 1);

			Handler.DrawEllipse(pen, center.X - radius / 2, center.Y - radius / 2, radius + 1, radius + 1);
		}

		public void DrawText(string text, Resource.Point location, Color color, int size = 2, string font_face = "Times New Roman", float emSize = 12.0f) {
			Brush brush = new SolidBrush(color);

			Font font = new(font_face, emSize);
			Handler.DrawString(text, font, brush, location.X + size / 2, location.Y + size / 2);
		}
	}
}
