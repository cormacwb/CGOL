namespace CGOL
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Run = new System.Windows.Forms.Button();
            this.Step = new System.Windows.Forms.Button();
            this.UserControlsLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Pause = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.StatisticsLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GenerationNumber = new System.Windows.Forms.Label();
            this.AliveCellCount = new System.Windows.Forms.Label();
            this.UserControlsLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.StatisticsLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork_1);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged_1);
            // 
            // Run
            // 
            this.Run.Location = new System.Drawing.Point(3, 3);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(75, 23);
            this.Run.TabIndex = 0;
            this.Run.Text = "Run";
            this.Run.UseVisualStyleBackColor = true;
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // Step
            // 
            this.Step.Location = new System.Drawing.Point(165, 3);
            this.Step.Name = "Step";
            this.Step.Size = new System.Drawing.Size(73, 23);
            this.Step.TabIndex = 1;
            this.Step.Text = "Step";
            this.Step.UseVisualStyleBackColor = true;
            this.Step.Click += new System.EventHandler(this.Step_Click);
            // 
            // UserControlsLayoutPanel
            // 
            this.UserControlsLayoutPanel.Controls.Add(this.Run);
            this.UserControlsLayoutPanel.Controls.Add(this.Pause);
            this.UserControlsLayoutPanel.Controls.Add(this.Step);
            this.UserControlsLayoutPanel.Location = new System.Drawing.Point(12, 150);
            this.UserControlsLayoutPanel.Name = "UserControlsLayoutPanel";
            this.UserControlsLayoutPanel.Size = new System.Drawing.Size(260, 38);
            this.UserControlsLayoutPanel.TabIndex = 2;
            // 
            // Pause
            // 
            this.Pause.Enabled = false;
            this.Pause.Location = new System.Drawing.Point(84, 3);
            this.Pause.Name = "Pause";
            this.Pause.Size = new System.Drawing.Size(75, 23);
            this.Pause.TabIndex = 2;
            this.Pause.Text = "Pause";
            this.Pause.UseVisualStyleBackColor = true;
            this.Pause.Click += new System.EventHandler(this.Pause_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // StatisticsLayoutPanel
            // 
            this.StatisticsLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StatisticsLayoutPanel.ColumnCount = 2;
            this.StatisticsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.StatisticsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.StatisticsLayoutPanel.Controls.Add(this.label1, 0, 0);
            this.StatisticsLayoutPanel.Controls.Add(this.label2, 0, 1);
            this.StatisticsLayoutPanel.Controls.Add(this.GenerationNumber, 1, 0);
            this.StatisticsLayoutPanel.Controls.Add(this.AliveCellCount, 1, 1);
            this.StatisticsLayoutPanel.Location = new System.Drawing.Point(305, 12);
            this.StatisticsLayoutPanel.Name = "StatisticsLayoutPanel";
            this.StatisticsLayoutPanel.RowCount = 2;
            this.StatisticsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.82313F));
            this.StatisticsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.17687F));
            this.StatisticsLayoutPanel.Size = new System.Drawing.Size(167, 58);
            this.StatisticsLayoutPanel.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Generation number:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "# Alive Cells:";
            // 
            // GenerationNumber
            // 
            this.GenerationNumber.AutoSize = true;
            this.GenerationNumber.Location = new System.Drawing.Point(86, 0);
            this.GenerationNumber.Name = "GenerationNumber";
            this.GenerationNumber.Size = new System.Drawing.Size(13, 13);
            this.GenerationNumber.TabIndex = 2;
            this.GenerationNumber.Text = "0";
            // 
            // AliveCellCount
            // 
            this.AliveCellCount.AutoSize = true;
            this.AliveCellCount.Location = new System.Drawing.Point(86, 33);
            this.AliveCellCount.Name = "AliveCellCount";
            this.AliveCellCount.Size = new System.Drawing.Size(13, 13);
            this.AliveCellCount.TabIndex = 3;
            this.AliveCellCount.Text = "0";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(484, 262);
            this.Controls.Add(this.StatisticsLayoutPanel);
            this.Controls.Add(this.UserControlsLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Conway\'s Game of Life";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint_1);
            this.UserControlsLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.StatisticsLayoutPanel.ResumeLayout(false);
            this.StatisticsLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button Run;
        private System.Windows.Forms.Button Step;
        private System.Windows.Forms.FlowLayoutPanel UserControlsLayoutPanel;
        private System.Windows.Forms.Button Pause;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.TableLayoutPanel StatisticsLayoutPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label GenerationNumber;
        private System.Windows.Forms.Label AliveCellCount;
     
    }
}

