using static GC.Resource.Config;

namespace GC.UI {
	public partial class MainForm: Form {
		readonly GraphicsHandler graphics_handler;
		Point[] generated_points;

		List<Point> drawn_points;
		bool draw_points;


		public MainForm() {
			InitializeComponent();
			FillSelectorBoxes();
			graphics_handler = new GraphicsHandler(MainCanvas);
			generated_points = new Point[0];
			draw_points = false;
		}

		public void FillSelectorBoxes() {
			for(int i = 0; i < EXERCISES.GetLength(0); i++) {
				ComboBoxDays.Items.Add(i + 1);
			}

			ComboBoxDays.SelectedIndex = ComboBoxDays.Items.Count - 1;
			PointsSelector.Value = 5;
			UpdateIdsComboBox();
		}

		private void UpdateIdsComboBox() {
			if(ComboBoxDays.SelectedItem == null)
				return;

			ComboBoxIds.Items.Clear();
			int day_id = int.Parse(ComboBoxDays.SelectedItem.ToString()) - 1;
			for(int j = 0; j < EXERCISES[day_id].Length; j++) {
				ComboBoxIds.Items.Add(j + 1);
			}
			ComboBoxIds.SelectedIndex = 0;
		}

		private void PreparePoints() {
			int nr = (int)PointsSelector.Value;
			generated_points = GeneratePoints(nr, graphics_handler);

			RefreshCanvas();
		}

		private void RefreshCanvas() {
			graphics_handler.ClearCanvas();
			graphics_handler.DrawPoints(generated_points, graphics_handler.StandardColor, label: DEV);
			graphics_handler.UpdateCanvas();
		}

		private void RunSelectedAction() {
			if(ComboBoxDays.SelectedItem == null || ComboBoxIds.SelectedItem == null)
				throw new NullReferenceException();


			if(generated_points == null)
				PreparePoints();

			RefreshCanvas();

			int day_id = int.Parse(ComboBoxDays.SelectedItem.ToString()) - 1;
			int action_id = int.Parse(ComboBoxIds.SelectedItem.ToString()) - 1;

			EXERCISES[day_id][action_id].Run(generated_points, graphics_handler);
			graphics_handler.UpdateCanvas();
		}

		private void RunButton_Click(object sender, EventArgs e) {
			RunSelectedAction();
		}

		private void GenerateButton_Click(object sender, EventArgs e) {
			PreparePoints();
		}

		private void ClearButton_Click(object sender, EventArgs e) {
			graphics_handler.ClearCanvas();
		}

		private void ComboBoxDays_SelectedIndexChanged(object sender, EventArgs e) {
			UpdateIdsComboBox();
		}

		private void AutoRunTimer_Tick(object sender, EventArgs e) {
			PreparePoints();
			RunSelectedAction();
		}

		private void AutoRunButton_Click(object sender, EventArgs e) {
			AutoRunTimer.Enabled = !AutoRunTimer.Enabled;

			if(AutoRunTimer.Enabled) {
				AutoRunButton.BackColor = graphics_handler.Aux_2Color;
			} else {
				AutoRunButton.BackColor = graphics_handler.BackgroundColor;
			}
		}

		private void DrawPointsButton_Click(object sender, EventArgs e) {
			drawn_points = new List<Point>();

			draw_points = !draw_points;
			SaveDrawPoints.Visible = draw_points;
			SaveDrawPoints.Enabled = draw_points;
		}

		private void SaveDrawPoints_Click(object sender, EventArgs e) {
			//Point[] existing_points = generated_points;
			List<Point> points = new List<Point>();
			points.AddRange(generated_points);
			points.AddRange(drawn_points);

			generated_points = points.ToArray();
			drawn_points = new List<Point>();
			RefreshCanvas();

			draw_points = !draw_points;
			SaveDrawPoints.Enabled = draw_points;
			SaveDrawPoints.Visible = draw_points;
		}

		private void MainCanvas_Click(object sender, EventArgs e) {
			if(!draw_points)
				return;

			MouseEventArgs ClickEvent = e as MouseEventArgs;
			if(ClickEvent == null)
				return;

			Point current_location = new Point(ClickEvent.X, ClickEvent.Y);
			drawn_points.Add(current_location);

			graphics_handler.DrawPoints(new Point[] { current_location }, graphics_handler.Aux_1Color, label: true, label_text: (drawn_points.Count - 1).ToString());
			graphics_handler.UpdateCanvas();
		}
	}
}