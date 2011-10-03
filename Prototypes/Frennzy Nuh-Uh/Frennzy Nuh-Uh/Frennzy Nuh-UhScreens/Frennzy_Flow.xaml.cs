using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Frennzy_Nuh_UhScreens
{
	public partial class Frennzy_Flow : UserControl
	{
		public Frennzy_Flow()
		{
			// Required to initialize variables
			InitializeComponent();
            LayoutRoot.DataContext = VM.StaticVM;
		}
	}
}