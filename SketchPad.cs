using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Ink;

public class Sketchpad : Application {

	[STAThread]
	public static void Main(){
		var app = new Sketchpad();
		Window root = new Window();
		InkCanvas inkCanvas1 = new InkCanvas();

		root.Title = "Skortchpard";
		DrawingAttributes inkDA;
		DrawingAttributes highlighterDA;
		bool useHIghlighter = false;

		root.ResizeMode = ResizeMode.CanResizeWithGrip;
		inkCanvas1.Background = Brushes.DarkSlateBlue;
		inkCanvas1.DefaultDrawingAttributes.Color = Colors.SpringGreen;

		root.Content = inkCanvas1;

		inkDA = new DrawingAttributes();
		inkDA.Color = Colors.SpringGreen;
		inkDA.Height = 5;
		inkDA.Width = 5;
		inkDA.FitToCurve = false;

		highlighterDA = new DrawingAttributes();
		highlighterDA.Color = Colors.Orchid;
		highlighterDA.IgnorePressure = true;
		highlighterDA.StylusTip = StylusTip.Rectangle;
		highlighterDA.Height = 30;
		highlighterDA.Width = 10;

		inkCanvas1.DefaultDrawingAttributes = inkDA;

		root.Show();
		app.MainWindow = root;
		app.Run();
	}

	void SwitchHighlighter_Click(Object sender, RoutedEventArgs e){
	}
}
