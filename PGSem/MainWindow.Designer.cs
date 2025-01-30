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
            ImageChckBox = new CheckBox();
            CreateCurve = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Controls.Add(ImageChckBox);
            panel1.Controls.Add(CreateCurve);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(207, 736);
            panel1.TabIndex = 0;
            // 
            // ImageChckBox
            // 
            ImageChckBox.AutoSize = true;
            ImageChckBox.Checked = true;
            ImageChckBox.CheckState = CheckState.Checked;
            ImageChckBox.Location = new Point(34, 126);
            ImageChckBox.Name = "ImageChckBox";
            ImageChckBox.Size = new Size(153, 34);
            ImageChckBox.TabIndex = 1;
            ImageChckBox.Text = "Show Image";
            ImageChckBox.UseVisualStyleBackColor = true;
            ImageChckBox.Click += ShowImageChckBox;
            // 
            // CreateCurve
            // 
            CreateCurve.Cursor = Cursors.Hand;
            CreateCurve.ImageAlign = ContentAlignment.TopCenter;
            CreateCurve.Location = new Point(23, 26);
            CreateCurve.Name = "CreateCurve";
            CreateCurve.Size = new Size(159, 72);
            CreateCurve.TabIndex = 0;
            CreateCurve.Text = "Create \r\nCurve\r\n";
            CreateCurve.UseVisualStyleBackColor = true;
            CreateCurve.Click += CreateCurveButton;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1176, 736);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Window";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button CreateCurve;
        private CheckBox ImageChckBox;
    }
}
