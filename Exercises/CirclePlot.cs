using System;
using System.Drawing.Text;

namespace Exercises
{
    public class CirclePlot : Form
    {
        private const double DotSize = 0.05;
        private const int CircleRadius = 200;
        private const int FormHeight = 800;
        private const int FormWidth = 800;

        private int dotCount;
        private double connectionProbability;

        private Point[] points;
        private Random random;

        public CirclePlot(int dotCount, double connectionProbability)
        {
            this.connectionProbability = connectionProbability;
            this.dotCount = dotCount;

            random = new Random();

            GeneratePoints();
            InitializeForm();
        }



        private void GeneratePoints()
        {
            points = new Point[dotCount];
            double angleIncrement = 2 * Math.PI / dotCount;

            for (int i = 0; i < dotCount; i++)
            {
                double angle = i * angleIncrement;
                int x = (int)(CircleRadius * Math.Cos(angle)) + FormWidth / 2;
                int y = (int)(CircleRadius * Math.Sin(angle)) + FormHeight / 2;
                points[i] = new Point(x, y);
            }
        }

        private void InitializeForm()
        {
            Text = "Circle Plot";
            Size = new Size(FormWidth, FormHeight);
            CenterToScreen();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Draw dots on the circumference of the circle
            foreach (Point point in points)
            {
                int dotSize = (int)(DotSize * CircleRadius);
                int x = point.X - dotSize / 2;
                int y = point.Y - dotSize / 2;
                g.FillEllipse(Brushes.Black, x, y, dotSize, dotSize);
            }

            // Connect points with gray lines based on the given probability
            for (int i = 0; i < dotCount; i++)
            {
                for (int j = i + 1; j < dotCount; j++) 
                {
                    if(random.NextDouble()<connectionProbability)
                    {
                        g.DrawLine(Pens.Gray, points[i], points[j]);
                    }
                }
            }
        }

    }
}
