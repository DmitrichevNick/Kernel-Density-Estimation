﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace KernelDensityEstimation
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {


            //double[] u = {0.0062, 0.0067, 0.0075, 0.0083, 0.0091,
            //    0.010, 0.011, 0.012, 0.013, 0.015,
            //    0.016, 0.018, 0.020, 0.022, 0.024,
            //    0.026, 0.029, 0.031, 0.035, 0.039,
            //    0.042, 0.046, 0.050, 0.056, 0.061,
            //    0.067, 0.074, 0.080, 0.087, 0.095,
            //    0.100, 0.110, 0.125, 0.140, 0.154,
            //    0.167, 0.182, 0.200, 0.222, 0.250,
            //    0.278, 0.303, 0.333, 0.370, 0.400,
            //    0.435, 0.476, 0.500, 0.526, 0.556,
            //    0.625, 0.667, 0.769, 0.833, 0.909, 1.000};
            //double[] w = {0.0, 0.0, 0.0, 0.0, 0.0,
            //    2.0/6.0, 2.0/6.0, 0.0, 1.0/6.0, 2.0/6.0,
            //    2.0/6.0, 2.0/6.0, 3.0/6.0, 2.0/6.0, 1.0/6.0,
            //    3.0/6.0, 3.0/6.0, 1.0/6.0, 2.0/6.0, 3.0/6.0,
            //    1.0/6.0, 2.0/6.0, 2.0/6.0, 2.0/6.0, 3.0/6.0,
            //    2.0/6.0, 2.0/6.0, 4.0/6.0, 2.0/6.0, 1.0/6.0,
            //    3.0/6.0, 1.0/6.0, 3.0/6.0, 2.0/6.0, 3.0/6.0,
            //    2.0/6.0, 4.0/6.0, 4.0/6.0, 4.0/6.0, 3.0/6.0,
            //    5.0/6.0, 3.0/6.0, 4.0/6.0, 5.0/6.0, 2.0/5.0,
            //    5.0/6.0, 4.0/6.0, 2.0/6.0, 4.0/6.0, 3.0/6.0,
            //    5.0/6.0, 4.0/6.0, 5.0/6.0, 8.0/12.0, 12.0/12.0, 12.0/12.0};
            //var nw = new NWMethod(0, u, w, 0.175);
            //var knn = new KnnMethod(0, u, w, 6);
            //Console.WriteLine(); Console.WriteLine();
            //for (double x = -0.5; x < 1.8; x += 0.05)
            //{
            //    Console.Write(nw.Fb(x) + ", ");
            //}
            //Console.WriteLine();

            //for (double x = -0.5; x < 1.8; x += 0.05)
            //{
            //    Console.Write(nw.Fu(x) + ", ");
            //}
            //Console.WriteLine();
            //for (double x = -0.5; x < 1.8; x += 0.05)
            //{
            //    Console.Write(knn.F(x) + ", ");
            //}
            //Console.WriteLine();
            //Console.WriteLine();
            InitializeComponent();
            var kernels = new List<Tuple<string, int>>
            {
                new Tuple<string, int>("Ядро Епачечникова", 0),
                new Tuple<string, int>("Квартическое ядро", 1),
                new Tuple<string, int>("Равномерное ядро", 2),
                new Tuple<string, int>("Треугольное ядро", 3),
                new Tuple<string, int>("Косинус-ядро", 4),
                new Tuple<string, int>("Лапласа ядро", 5),
                new Tuple<string, int>("Гауссово ядро", 6),
            };
            KernelList.DataSource = kernels;
            KernelList.DisplayMember = "Item1";
            KernelList.ValueMember = "Item2";
        }

        private void DrawButton_Click(object sender, EventArgs e)
        {
            double[] u = {0.0062, 0.0067, 0.0075, 0.0083, 0.0091,
                0.010, 0.011, 0.012, 0.013, 0.015,
                0.016, 0.018, 0.020, 0.022, 0.024,
                0.026, 0.029, 0.031, 0.035, 0.039,
                0.042, 0.046, 0.050, 0.056, 0.061,
                0.067, 0.074, 0.080, 0.087, 0.095,
                0.100, 0.110, 0.125, 0.140, 0.154,
                0.167, 0.182, 0.200, 0.222, 0.250,
                0.278, 0.303, 0.333, 0.370, 0.400,
                0.435, 0.476, 0.500, 0.526, 0.556,
                0.625, 0.667, 0.769, 0.833, 0.909, 1.000};
            double[] w = {0.0, 0.0, 0.0, 0.0, 0.0,
                2.0/6.0, 2.0/6.0, 0.0, 1.0/6.0, 2.0/6.0,
                2.0/6.0, 2.0/6.0, 3.0/6.0, 2.0/6.0, 1.0/6.0,
                3.0/6.0, 3.0/6.0, 1.0/6.0, 2.0/6.0, 3.0/6.0,
                1.0/6.0, 2.0/6.0, 2.0/6.0, 2.0/6.0, 3.0/6.0,
                2.0/6.0, 2.0/6.0, 4.0/6.0, 2.0/6.0, 1.0/6.0,
                3.0/6.0, 1.0/6.0, 3.0/6.0, 2.0/6.0, 3.0/6.0,
                2.0/6.0, 4.0/6.0, 4.0/6.0, 4.0/6.0, 3.0/6.0,
                5.0/6.0, 3.0/6.0, 4.0/6.0, 5.0/6.0, 2.0/5.0,
                5.0/6.0, 4.0/6.0, 2.0/6.0, 4.0/6.0, 3.0/6.0,
                5.0/6.0, 4.0/6.0, 5.0/6.0, 8.0/12.0, 12.0/12.0, 12.0/12.0};


            
            if (string.IsNullOrEmpty(KValue.Text) || string.IsNullOrEmpty(HValue.Text) || !int.TryParse(KValue.Text, out _) || !double.TryParse(HValue.Text, out _)) return;

            var k = int.Parse(KValue.Text);
            var h = double.Parse(HValue.Text);
          
            var kernel = (int)KernelList.SelectedValue;

            var nw = new NWMethod(kernel, u, w, h);
            var knn = new KnnMethod(kernel,u,w,k);

            var minX = -0.5;
            var maxX = 1.15;
            var step = 0.025;
            Graphic.Series.All(series =>
            {
                series.Points.Clear();
                return true;
            });
            for (double x = minX; x < maxX; x += step)
            {
                Graphic.Series["Nw"].Points.AddXY(x, nw.Fb(x));
                Graphic.Series["Knn"].Points.AddXY(x, knn.F(x));
            }
        }
    }
}