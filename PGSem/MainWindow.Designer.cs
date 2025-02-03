namespace PGSem
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            NumFieldLabel = new Label();
            NumericField = new NumericUpDown();
            CyclicBut = new Button();
            bClearBut = new Button();
            SobelBut = new Button();
            GaussBut = new Button();
            button1 = new Button();
            CreateCurve = new Button();
            groupBox1 = new GroupBox();
            BezierBut = new Button();
            label1 = new Label();
            OtsuBut = new Button();
            TimeTextBox = new TextBox();
            ImageChckBox = new CheckBox();
            doubleBuffPanel = new DoubleBuffPanel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumericField).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Controls.Add(NumFieldLabel);
            panel1.Controls.Add(NumericField);
            panel1.Controls.Add(CyclicBut);
            panel1.Controls.Add(bClearBut);
            panel1.Controls.Add(SobelBut);
            panel1.Controls.Add(GaussBut);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(CreateCurve);
            panel1.Controls.Add(groupBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(222, 936);
            panel1.TabIndex = 0;
            // 
            // NumFieldLabel
            // 
            NumFieldLabel.AutoSize = true;
            NumFieldLabel.Location = new Point(39, 806);
            NumFieldLabel.MaximumSize = new Size(180, 0);
            NumFieldLabel.Name = "NumFieldLabel";
            NumFieldLabel.Size = new Size(131, 30);
            NumFieldLabel.TabIndex = 11;
            NumFieldLabel.Text = "Počet iterácií";
            // 
            // NumericField
            // 
            NumericField.Location = new Point(23, 848);
            NumericField.Name = "NumericField";
            NumericField.Size = new Size(164, 35);
            NumericField.TabIndex = 10;
            // 
            // CyclicBut
            // 
            CyclicBut.Location = new Point(23, 708);
            CyclicBut.Name = "CyclicBut";
            CyclicBut.Size = new Size(164, 79);
            CyclicBut.TabIndex = 9;
            CyclicBut.Text = "Cyklické spustenie";
            CyclicBut.UseVisualStyleBackColor = true;
            CyclicBut.Click += CyclicOnClick;
            // 
            // bClearBut
            // 
            bClearBut.Location = new Point(23, 662);
            bClearBut.Name = "bClearBut";
            bClearBut.Size = new Size(164, 40);
            bClearBut.TabIndex = 8;
            bClearBut.Text = "Clear";
            bClearBut.UseVisualStyleBackColor = true;
            bClearBut.Click += ClearOnClick;
            // 
            // SobelBut
            // 
            SobelBut.Font = new Font("Segoe UI", 6.857143F, FontStyle.Regular, GraphicsUnit.Point, 238);
            SobelBut.Location = new Point(23, 350);
            SobelBut.Name = "SobelBut";
            SobelBut.Size = new Size(164, 41);
            SobelBut.TabIndex = 4;
            SobelBut.Text = "Sobel Edge Detector";
            SobelBut.UseVisualStyleBackColor = true;
            SobelBut.Click += SobelEdgeOnClick;
            // 
            // GaussBut
            // 
            GaussBut.Location = new Point(23, 295);
            GaussBut.Name = "GaussBut";
            GaussBut.Size = new Size(164, 40);
            GaussBut.TabIndex = 3;
            GaussBut.Text = "Gauss Filter";
            GaussBut.UseVisualStyleBackColor = true;
            GaussBut.Click += GaussFilterOnClick;
            // 
            // button1
            // 
            button1.Location = new Point(23, 125);
            button1.Name = "button1";
            button1.Size = new Size(173, 77);
            button1.TabIndex = 2;
            button1.Text = "Vyberte obrázok";
            button1.UseVisualStyleBackColor = true;
            button1.Click += SelectImageOnClick;
            // 
            // CreateCurve
            // 
            CreateCurve.Cursor = Cursors.Hand;
            CreateCurve.ImageAlign = ContentAlignment.TopCenter;
            CreateCurve.Location = new Point(23, 26);
            CreateCurve.Name = "CreateCurve";
            CreateCurve.Size = new Size(173, 69);
            CreateCurve.TabIndex = 0;
            CreateCurve.Text = "Spustiť všetky metódy";
            CreateCurve.UseVisualStyleBackColor = true;
            CreateCurve.Click += CreateCurveButton;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(BezierBut);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(OtsuBut);
            groupBox1.Controls.Add(TimeTextBox);
            groupBox1.Controls.Add(ImageChckBox);
            groupBox1.Location = new Point(3, 248);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(216, 391);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Samostatne metódy";
            // 
            // BezierBut
            // 
            BezierBut.Location = new Point(20, 214);
            BezierBut.Name = "BezierBut";
            BezierBut.Size = new Size(164, 40);
            BezierBut.TabIndex = 6;
            BezierBut.Text = "Bezier Curve";
            BezierBut.UseVisualStyleBackColor = true;
            BezierBut.Click += BezierCurveOnClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 299);
            label1.Name = "label1";
            label1.Size = new Size(171, 30);
            label1.TabIndex = 1;
            label1.Text = "Čas metódy v ms";
            // 
            // OtsuBut
            // 
            OtsuBut.Location = new Point(20, 158);
            OtsuBut.Name = "OtsuBut";
            OtsuBut.Size = new Size(164, 40);
            OtsuBut.TabIndex = 5;
            OtsuBut.Text = "Otsu Treshold";
            OtsuBut.UseVisualStyleBackColor = true;
            OtsuBut.Click += OtsuTresholdOnClick;
            // 
            // TimeTextBox
            // 
            TimeTextBox.Enabled = false;
            TimeTextBox.Location = new Point(24, 341);
            TimeTextBox.Name = "TimeTextBox";
            TimeTextBox.PlaceholderText = "00:00";
            TimeTextBox.Size = new Size(160, 35);
            TimeTextBox.TabIndex = 0;
            TimeTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // ImageChckBox
            // 
            ImageChckBox.Anchor = AnchorStyles.None;
            ImageChckBox.AutoSize = true;
            ImageChckBox.Location = new Point(20, 262);
            ImageChckBox.Name = "ImageChckBox";
            ImageChckBox.Size = new Size(184, 34);
            ImageChckBox.TabIndex = 1;
            ImageChckBox.Text = "Ukázať obrázok";
            ImageChckBox.UseVisualStyleBackColor = true;
            ImageChckBox.Click += ShowImageChckBox;
            // 
            // doubleBuffPanel
            // 
            doubleBuffPanel.AutoSize = true;
            doubleBuffPanel.Dock = DockStyle.Fill;
            doubleBuffPanel.Location = new Point(222, 0);
            doubleBuffPanel.Name = "doubleBuffPanel";
            doubleBuffPanel.Size = new Size(954, 936);
            doubleBuffPanel.TabIndex = 1;
            doubleBuffPanel.Paint += DoubleBuffPanel_Paint;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1176, 936);
            Controls.Add(doubleBuffPanel);
            Controls.Add(panel1);
            Name = "MainWindow";
            Text = "Window";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NumericField).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button CreateCurve;
        private CheckBox ImageChckBox;
        private Button button1;
        private DoubleBuffPanel doubleBuffPanel;
        private Button SobelBut;
        private Button GaussBut;
        private Button OtsuBut;
        private Button BezierBut;
        private GroupBox groupBox1;
        private Label label1;
        private TextBox TimeTextBox;
        private Button bClearBut;
        private Button CyclicBut;
        private NumericUpDown NumericField;
        private Label NumFieldLabel;
    }
}
