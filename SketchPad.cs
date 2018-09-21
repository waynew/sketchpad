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

		root = new Window();
		canvas = new InkCanvas();

		root.Title = "Skortchpard";

		root.ResizeMode = ResizeMode.CanResizeWithGrip;
		canvas.Background = Brushes.DarkSlateBlue;
		canvas.DefaultDrawingAttributes.Color = Colors.SpringGreen;
		canvas.DefaultDrawingAttributes.Height = 10;
		canvas.DefaultDrawingAttributes.Width = 10;
		canvas.EditingModeInverted = InkCanvasEditingMode.EraseByPoint;
		canvas.EditingMode = InkCanvasEditingMode.Ink;

		root.Content = canvas;
		root.Show();
	}

	[STAThread]
	public static void Main(){
		new Sketchpad().Run();
	}
}
