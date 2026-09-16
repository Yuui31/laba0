using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace laba0
{
    public partial class MainWindow : Window
    {
        Triangle tr;
        Rectangle rect;
        Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();
            CreateRandomTriangle();
        }
        public void DrawLine(Point2D p1, Point2D p2)
        {
            Line line = new Line();
            line.Stroke = Brushes.Red;
            line.StrokeThickness = 3;
            line.X1 = p1.X;
            line.Y1 = p1.Y;
            line.X2 = p2.X;
            line.Y2 = p2.Y;
            Scene.Children.Add(line);
        }
        public void DrawTriangle(Triangle tr)
        {
            DrawLine(tr.P1, tr.P2);
            DrawLine(tr.P2, tr.P3);
            DrawLine(tr.P3, tr.P1);
        }
        public void DrawRectangle(Rectangle rect)
        {
            DrawLine(rect.TopLeft, rect.TopRight);
            DrawLine(rect.TopRight, rect.BottomRight);
            DrawLine(rect.BottomRight, rect.BottomLeft);
            DrawLine(rect.BottomLeft, rect.TopLeft);
        }
        public void ClearScene()
        {
            Scene.Children.Clear();
        }
        public void CreateRandomTriangle()
        {
            ClearScene();
            Point2D p1 = new Point2D(rnd.Next(0, (int)Scene.Width), rnd.Next(0, (int)Scene.Height));
            Point2D p2 = new Point2D(rnd.Next(0, (int)Scene.Width), rnd.Next(0, (int)Scene.Height));
            Point2D p3 = new Point2D(rnd.Next(0, (int)Scene.Width), rnd.Next(0, (int)Scene.Height));
            tr = new Triangle(p1, p2, p3);
            DrawTriangle(tr);
        }
        public void CreateRandomRectangle()
        {
            ClearScene();
            int x = rnd.Next(10, (int)Scene.Width - 100);
            int y = rnd.Next(10, (int)Scene.Height - 100);
            int w = rnd.Next(50, 150);
            int h = rnd.Next(50, 150);
            rect = new Rectangle(new Point2D(x, y), w, h);
            DrawRectangle(rect);
        }
        public void CreateRandomSquare()
        {
            ClearScene();
            int x = rnd.Next(10, (int)Scene.Width - 100);
            int y = rnd.Next(10, (int)Scene.Height - 100);
            int size = rnd.Next(50, 150);
            rect = new Rectangle(new Point2D(x, y), size, size);
            DrawRectangle(rect);
        }
        private void BtnRandomTriangle_Click(object sender, RoutedEventArgs e)
        {
            CreateRandomTriangle();
        }
        private void BtnRandomRectangle_Click(object sender, RoutedEventArgs e)
        {
            CreateRandomRectangle();
        }
        private void BtnSquare_Click(object sender, RoutedEventArgs e)
        {
            CreateRandomSquare();
        }
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearScene();
        }
    }
}