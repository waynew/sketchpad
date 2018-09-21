using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Ink;

public class Sketchpad : Application {

	Window root;
	InkCanvas canvas;

	protected override void OnStartup(StartupEventArgs e) {
		base.OnStartup(e);

		Window root = new Window();
		InkCanvas inkCanvas1 = new InkCanvas();

		root.Title = "Skortchpard";

		root.ResizeMode = ResizeMode.CanResizeWithGrip;
		inkCanvas1.Background = Brushes.DarkSlateBlue;
		inkCanvas1.DefaultDrawingAttributes.Color = Colors.SpringGreen;
		inkCanvas1.DefaultDrawingAttributes.Height = 10;
		inkCanvas1.DefaultDrawingAttributes.Width = 10;
		inkCanvas1.EditingModeInverted = InkCanvasEditingMode.EraseByPoint;
		inkCanvas1.EditingMode = InkCanvasEditingMode.Ink;

		root.Content = inkCanvas1;
		root.Show();
	}

	[STAThread]
	public static void Main(){
		new Sketchpad().Run();
	}
}
