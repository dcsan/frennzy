using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace MouseEffect01
{
    public partial class Page : UserControl
    {
        private Point pt;
        private Point ptHistory1;
        private Point ptHistory2;
        private Point ptHistory3;
        private Point ptHistory4;
        private Point ptHistory5;
        private bool MouseDraw = false;
        private string BrushColour = "white";
        public Page()
        {
            InitializeComponent();
            ptHistory1 = pt;
            ptHistory2 = ptHistory1;
            ptHistory3 = ptHistory2;
            ptHistory4 = ptHistory3;
            ptHistory5 = ptHistory4;
            BrushSize.Minimum = 1;
            BrushSize.Maximum = 30;
            BrushSize.Value = 3;
            BrushOpacity.Minimum = 0.1;
            BrushOpacity.Maximum = 1;
            BrushOpacity.Value = 1;
            Loaded += new RoutedEventHandler(Page_Loaded);
        }

        void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LayoutRoot.MouseMove += new MouseEventHandler(LayoutRoot_MouseMove);
            LayoutRoot.MouseLeftButtonDown += new MouseButtonEventHandler(LayoutRoot_MouseLeftButtonDown);
            LayoutRoot.MouseLeftButtonUp += new MouseButtonEventHandler(LayoutRoot_MouseLeftButtonUp);
            black.MouseLeftButtonDown += new MouseButtonEventHandler(black_MouseLeftButtonDown);
            white.MouseLeftButtonDown += new MouseButtonEventHandler(white_MouseLeftButtonDown);
            red.MouseLeftButtonDown += new MouseButtonEventHandler(red_MouseLeftButtonDown);
            purple.MouseLeftButtonDown += new MouseButtonEventHandler(purple_MouseLeftButtonDown);
            blue.MouseLeftButtonDown += new MouseButtonEventHandler(blue_MouseLeftButtonDown);
            cyan.MouseLeftButtonDown += new MouseButtonEventHandler(cyan_MouseLeftButtonDown);
            green.MouseLeftButtonDown += new MouseButtonEventHandler(green_MouseLeftButtonDown);
            brown.MouseLeftButtonDown += new MouseButtonEventHandler(brown_MouseLeftButtonDown);
            orange.MouseLeftButtonDown += new MouseButtonEventHandler(orange_MouseLeftButtonDown);
            yellow.MouseLeftButtonDown += new MouseButtonEventHandler(yellow_MouseLeftButtonDown);
        }

        void yellow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BrushColour = "yellow";
        }

        void orange_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BrushColour = "orange";
        }

        void brown_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BrushColour = "brown";
        }

        void green_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BrushColour = "green";
        }

        void cyan_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BrushColour = "cyan";
        }

        void blue_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BrushColour = "blue";
        }

        void purple_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BrushColour = "purple";
        }

        void red_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BrushColour = "red";
        }

        void white_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BrushColour = "white";
        }

        void black_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BrushColour = "black";
        }

        void LayoutRoot_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MouseDraw = false;
        }

        void LayoutRoot_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            pt = e.GetPosition(LayoutRoot);
            ptHistory1 = pt;
            MouseDraw = true;
        }

        void LayoutRoot_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseDraw)
            {
                pt = e.GetPosition(LayoutRoot);
                Line Line1 = new Line();
                Line1.X1 = pt.X;
                Line1.Y1 = pt.Y;
                Line1.X2 = ptHistory1.X;
                Line1.Y2 = ptHistory1.Y;
                if (BrushColour == "white")
                {
                    Line1.Stroke = new SolidColorBrush(Colors.White);
                }
                else if (BrushColour == "black")
                {
                    Line1.Stroke = new SolidColorBrush(Colors.Black);
                }
                else if (BrushColour == "red")
                {
                    Line1.Stroke = new SolidColorBrush(Colors.Red);
                }
                else if (BrushColour == "purple")
                {
                    Line1.Stroke = new SolidColorBrush(Colors.Purple);
                }
                else if (BrushColour == "blue")
                {
                    Line1.Stroke = new SolidColorBrush(Colors.Blue);
                }
                else if (BrushColour == "cyan")
                {
                    Line1.Stroke = new SolidColorBrush(Colors.Cyan);
                }
                else if (BrushColour == "green")
                {
                    Line1.Stroke = new SolidColorBrush(Colors.Green);
                }
                else if (BrushColour == "brown")
                {
                    Line1.Stroke = new SolidColorBrush(Colors.Brown);
                }
                else if (BrushColour == "orange")
                {
                    Line1.Stroke = new SolidColorBrush(Colors.Orange);
                }
                else if (BrushColour == "yellow")
                {
                    Line1.Stroke = new SolidColorBrush(Colors.Yellow);
                }
                Line1.StrokeStartLineCap = PenLineCap.Round;
                Line1.StrokeEndLineCap = PenLineCap.Round;
                Line1.StrokeThickness = BrushSize.Value;
                Line1.Opacity = BrushOpacity.Value;
                LayoutRoot.Children.Add(Line1);
                ptHistory1 = pt;
            }
            ptHistory1 = pt;
        }
    }
}
