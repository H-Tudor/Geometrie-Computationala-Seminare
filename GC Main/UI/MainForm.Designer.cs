using System.Drawing;

namespace GC.UI {
	partial class MainForm {
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			components = new System.ComponentModel.Container();
			MainCanvas = new PictureBox();
			ComboBoxDays = new ComboBox();
			label1 = new Label();
			label2 = new Label();
			label3 = new Label();
			label4 = new Label();
			ComboBoxIds = new ComboBox();
			RunButton = new Button();
			GenerateButton = new Button();
			ClearButton = new Button();
			AutoRunTimer = new Timer(components);
			AutoRunButton = new Button();
			PointsSelector = new NumericUpDown();
			DrawPointsButton = new Button();
			SaveDrawPoints = new Button();
			TextOutputHeader = new Label();
			TextOutputLabel = new Label();
			((System.ComponentModel.ISupportInitialize)MainCanvas).BeginInit();
			((System.ComponentModel.ISupportInitialize)PointsSelector).BeginInit();
			SuspendLayout();
			// 
			// MainCanvas
			// 
			MainCanvas.BackColor = Color.WhiteSmoke;
			MainCanvas.BorderStyle = BorderStyle.FixedSingle;
			MainCanvas.Location = new System.Drawing.Point(185, 12);
			MainCanvas.Name = "MainCanvas";
			MainCanvas.Size = new Size(537, 537);
			MainCanvas.TabIndex = 0;
			MainCanvas.TabStop = false;
			MainCanvas.Click += MainCanvas_Click;
			// 
			// ComboBoxDays
			// 
			ComboBoxDays.BackColor = Color.LightGray;
			ComboBoxDays.FormattingEnabled = true;
			ComboBoxDays.Location = new System.Drawing.Point(12, 75);
			ComboBoxDays.Name = "ComboBoxDays";
			ComboBoxDays.Size = new Size(121, 23);
			ComboBoxDays.TabIndex = 1;
			ComboBoxDays.SelectedIndexChanged += ComboBoxDays_SelectedIndexChanged;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.BackColor = SystemColors.Window;
			label1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
			label1.ForeColor = SystemColors.ControlText;
			label1.Location = new System.Drawing.Point(12, 53);
			label1.Name = "label1";
			label1.Size = new Size(34, 19);
			label1.TabIndex = 2;
			label1.Text = "Day";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.BackColor = SystemColors.Window;
			label2.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
			label2.ForeColor = SystemColors.ControlText;
			label2.Location = new System.Drawing.Point(12, 111);
			label2.Name = "label2";
			label2.Size = new Size(22, 19);
			label2.TabIndex = 3;
			label2.Text = "Id";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.BackColor = SystemColors.Window;
			label3.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
			label3.ForeColor = SystemColors.ControlText;
			label3.Location = new System.Drawing.Point(12, 12);
			label3.Name = "label3";
			label3.Size = new Size(123, 21);
			label3.TabIndex = 4;
			label3.Text = "Select Exercise";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.BackColor = SystemColors.Window;
			label4.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
			label4.ForeColor = SystemColors.ControlText;
			label4.Location = new System.Drawing.Point(12, 172);
			label4.Name = "label4";
			label4.Size = new Size(83, 19);
			label4.TabIndex = 5;
			label4.Text = "Nr of Points";
			// 
			// ComboBoxIds
			// 
			ComboBoxIds.BackColor = Color.LightGray;
			ComboBoxIds.FormattingEnabled = true;
			ComboBoxIds.Location = new System.Drawing.Point(12, 133);
			ComboBoxIds.Name = "ComboBoxIds";
			ComboBoxIds.Size = new Size(121, 23);
			ComboBoxIds.TabIndex = 7;
			// 
			// RunButton
			// 
			RunButton.BackColor = SystemColors.Window;
			RunButton.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
			RunButton.ForeColor = Color.Firebrick;
			RunButton.Location = new System.Drawing.Point(12, 352);
			RunButton.Name = "RunButton";
			RunButton.Size = new Size(152, 35);
			RunButton.TabIndex = 8;
			RunButton.Text = "Run Exercise";
			RunButton.UseVisualStyleBackColor = false;
			RunButton.Click += RunButton_Click;
			// 
			// GenerateButton
			// 
			GenerateButton.BackColor = SystemColors.Window;
			GenerateButton.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
			GenerateButton.ForeColor = Color.Firebrick;
			GenerateButton.Location = new System.Drawing.Point(12, 434);
			GenerateButton.Name = "GenerateButton";
			GenerateButton.Size = new Size(152, 33);
			GenerateButton.TabIndex = 9;
			GenerateButton.Text = "Generate Points";
			GenerateButton.UseVisualStyleBackColor = false;
			GenerateButton.Click += GenerateButton_Click;
			// 
			// ClearButton
			// 
			ClearButton.BackColor = SystemColors.Window;
			ClearButton.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
			ClearButton.ForeColor = Color.Firebrick;
			ClearButton.Location = new System.Drawing.Point(12, 512);
			ClearButton.Name = "ClearButton";
			ClearButton.Size = new Size(152, 33);
			ClearButton.TabIndex = 10;
			ClearButton.Text = "Clear Canvas";
			ClearButton.UseVisualStyleBackColor = false;
			ClearButton.Click += ClearButton_Click;
			// 
			// AutoRunTimer
			// 
			AutoRunTimer.Interval = 1000;
			AutoRunTimer.Tick += AutoRunTimer_Tick;
			// 
			// AutoRunButton
			// 
			AutoRunButton.BackColor = SystemColors.Window;
			AutoRunButton.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
			AutoRunButton.ForeColor = Color.Firebrick;
			AutoRunButton.Location = new System.Drawing.Point(12, 393);
			AutoRunButton.Name = "AutoRunButton";
			AutoRunButton.Size = new Size(152, 35);
			AutoRunButton.TabIndex = 11;
			AutoRunButton.Text = "Auto Run";
			AutoRunButton.UseVisualStyleBackColor = false;
			AutoRunButton.Click += AutoRunButton_Click;
			// 
			// PointsSelector
			// 
			PointsSelector.Location = new System.Drawing.Point(12, 194);
			PointsSelector.Name = "PointsSelector";
			PointsSelector.Size = new Size(123, 23);
			PointsSelector.TabIndex = 12;
			// 
			// DrawPointsButton
			// 
			DrawPointsButton.BackColor = SystemColors.Window;
			DrawPointsButton.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
			DrawPointsButton.ForeColor = Color.Firebrick;
			DrawPointsButton.Location = new System.Drawing.Point(12, 473);
			DrawPointsButton.Name = "DrawPointsButton";
			DrawPointsButton.Size = new Size(152, 33);
			DrawPointsButton.TabIndex = 13;
			DrawPointsButton.Text = "Draw Points";
			DrawPointsButton.UseVisualStyleBackColor = false;
			DrawPointsButton.Click += DrawPointsButton_Click;
			// 
			// SaveDrawPoints
			// 
			SaveDrawPoints.BackColor = SystemColors.Window;
			SaveDrawPoints.Enabled = false;
			SaveDrawPoints.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
			SaveDrawPoints.ForeColor = Color.ForestGreen;
			SaveDrawPoints.Location = new System.Drawing.Point(12, 313);
			SaveDrawPoints.Name = "SaveDrawPoints";
			SaveDrawPoints.Size = new Size(152, 33);
			SaveDrawPoints.TabIndex = 14;
			SaveDrawPoints.Text = "Save Draw Points";
			SaveDrawPoints.UseVisualStyleBackColor = false;
			SaveDrawPoints.Visible = false;
			SaveDrawPoints.Click += SaveDrawPoints_Click;
			// 
			// TextOutputHeader
			// 
			TextOutputHeader.AutoSize = true;
			TextOutputHeader.Enabled = false;
			TextOutputHeader.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
			TextOutputHeader.Location = new System.Drawing.Point(12, 232);
			TextOutputHeader.Name = "TextOutputHeader";
			TextOutputHeader.Size = new Size(130, 19);
			TextOutputHeader.TabIndex = 15;
			TextOutputHeader.Text = "Text Output Header";
			TextOutputHeader.Visible = false;
			// 
			// TextOutputLabel
			// 
			TextOutputLabel.AutoSize = true;
			TextOutputLabel.Enabled = false;
			TextOutputLabel.Location = new System.Drawing.Point(12, 260);
			TextOutputLabel.Name = "TextOutputLabel";
			TextOutputLabel.Size = new Size(69, 15);
			TextOutputLabel.TabIndex = 16;
			TextOutputLabel.Text = "Text Output";
			TextOutputLabel.Visible = false;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.Window;
			ClientSize = new Size(734, 561);
			Controls.Add(TextOutputLabel);
			Controls.Add(TextOutputHeader);
			Controls.Add(SaveDrawPoints);
			Controls.Add(DrawPointsButton);
			Controls.Add(PointsSelector);
			Controls.Add(AutoRunButton);
			Controls.Add(ClearButton);
			Controls.Add(GenerateButton);
			Controls.Add(RunButton);
			Controls.Add(ComboBoxIds);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(ComboBoxDays);
			Controls.Add(MainCanvas);
			ForeColor = SystemColors.ControlText;
			Name = "MainForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = " ";
			((System.ComponentModel.ISupportInitialize)MainCanvas).EndInit();
			((System.ComponentModel.ISupportInitialize)PointsSelector).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private PictureBox MainCanvas;
		private ComboBox ComboBoxDays;
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private ComboBox ComboBoxIds;
		private Button RunButton;
		private Button GenerateButton;
		private Button ClearButton;
		private Timer AutoRunTimer;
		private Button AutoRunButton;
		private NumericUpDown PointsSelector;
		private Button DrawPointsButton;
		private Button SaveDrawPoints;
		private Label TextOutputHeader;
		private Label TextOutputLabel;
	}
}