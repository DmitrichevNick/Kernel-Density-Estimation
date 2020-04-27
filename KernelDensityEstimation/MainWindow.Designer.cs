namespace KernelDensityEstimation
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Graphic = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.KernelList = new System.Windows.Forms.ComboBox();
            this.KValue = new System.Windows.Forms.TextBox();
            this.HValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DrawButton = new System.Windows.Forms.Button();
            this.Settings = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.Graphic)).BeginInit();
            this.Settings.SuspendLayout();
            this.SuspendLayout();
            // 
            // Graphic
            // 
            chartArea1.Name = "ChartArea1";
            this.Graphic.ChartAreas.Add(chartArea1);
            this.Graphic.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.Graphic.Legends.Add(legend1);
            this.Graphic.Location = new System.Drawing.Point(221, 0);
            this.Graphic.Name = "Graphic";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Nw";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Knn";
            this.Graphic.Series.Add(series1);
            this.Graphic.Series.Add(series2);
            this.Graphic.Size = new System.Drawing.Size(579, 450);
            this.Graphic.TabIndex = 0;
            this.Graphic.Text = "chart1";
            // 
            // KernelList
            // 
            this.KernelList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KernelList.FormattingEnabled = true;
            this.KernelList.Location = new System.Drawing.Point(12, 26);
            this.KernelList.Name = "KernelList";
            this.KernelList.Size = new System.Drawing.Size(201, 24);
            this.KernelList.TabIndex = 2;
            // 
            // KValue
            // 
            this.KValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KValue.Location = new System.Drawing.Point(37, 114);
            this.KValue.Name = "KValue";
            this.KValue.Size = new System.Drawing.Size(100, 23);
            this.KValue.TabIndex = 3;
            // 
            // HValue
            // 
            this.HValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HValue.Location = new System.Drawing.Point(37, 71);
            this.HValue.Name = "HValue";
            this.HValue.Size = new System.Drawing.Size(100, 23);
            this.HValue.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "K";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "H";
            // 
            // DrawButton
            // 
            this.DrawButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DrawButton.Location = new System.Drawing.Point(12, 154);
            this.DrawButton.Name = "DrawButton";
            this.DrawButton.Size = new System.Drawing.Size(192, 46);
            this.DrawButton.TabIndex = 7;
            this.DrawButton.Text = "Нарисовать";
            this.DrawButton.UseVisualStyleBackColor = true;
            this.DrawButton.Click += new System.EventHandler(this.DrawButton_Click);
            // 
            // Settings
            // 
            this.Settings.Controls.Add(this.KernelList);
            this.Settings.Controls.Add(this.DrawButton);
            this.Settings.Controls.Add(this.KValue);
            this.Settings.Controls.Add(this.label2);
            this.Settings.Controls.Add(this.HValue);
            this.Settings.Controls.Add(this.label1);
            this.Settings.Dock = System.Windows.Forms.DockStyle.Left;
            this.Settings.Location = new System.Drawing.Point(0, 0);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(221, 450);
            this.Settings.TabIndex = 8;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Graphic);
            this.Controls.Add(this.Settings);
            this.Name = "MainWindow";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Graphic)).EndInit();
            this.Settings.ResumeLayout(false);
            this.Settings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart Graphic;
        private System.Windows.Forms.ComboBox KernelList;
        private System.Windows.Forms.TextBox KValue;
        private System.Windows.Forms.TextBox HValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button DrawButton;
        private System.Windows.Forms.Panel Settings;
    }
}

