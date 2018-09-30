using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Ink;
using System.IO;
using System.Xml.Serialization;

namespace Sketchpad {

public class Settings {
	public string canvas_color = "#FFFFFF";
	public string brush_color = "#000000";

	public void fromSettings(Settings other){
		this.canvas_color = other.canvas_color ?? "#FFFFFF";
		this.brush_color = other.brush_color ?? "#000000";
	}
}

public class TheSketchpad : Application {

	Window root;
	InkCanvas canvas;

	public void saveCanvas(object sender, RoutedEventArgs e){
		var fd = new Microsoft.Win32.SaveFileDialog();
		fd.FileName = "Sketch";
		fd.DefaultExt = ".jpg";
		fd.Filter = "Images (.jpg) | *.jpg,*.jpeg";
		var result = fd.ShowDialog();
		if (result == true){
			Console.WriteLine("Gonna save to {0}", fd.FileName);
		}
		else {
			Console.WriteLine("Save was aborted");
		}
	}

	protected override void OnStartup(StartupEventArgs e) {
		base.OnStartup(e);

		string root_appdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
		string app_data_folder = Path.Combine(root_appdata, "sketchpad");
		string settings_path = Path.Combine(app_data_folder, "settings.txt");
		var settings = new Settings();
		var settings_serializer = new XmlSerializer(settings.GetType());

		if (File.Exists(settings_path)){
			using(var fs = File.OpenRead(settings_path)){
				settings = (Settings)settings_serializer.Deserialize(fs);
			}
		}
		else {
			Directory.CreateDirectory(app_data_folder);
			var s = new Settings();
			s.canvas_color = Brushes.DarkBlue.Color.ToString();
			var serializer = new XmlSerializer(s.GetType());
			using(var fs = File.OpenWrite(settings_path)){
				serializer.Serialize(fs, s);
			}
		}


		root = new Window();
		var grid = new Grid();
		var col_1 = new ColumnDefinition();
		var col_2 = new ColumnDefinition();
		var row_1 = new RowDefinition();
		var row_2 = new RowDefinition();
		var row_3 = new RowDefinition();
		var row_4 = new RowDefinition();
		var row_5 = new RowDefinition();
		var row_6 = new RowDefinition();
		var row_7 = new RowDefinition();

		col_1.Width = new GridLength(40, GridUnitType.Pixel);
		row_1.Height = new GridLength(40, GridUnitType.Pixel);

		grid.ColumnDefinitions.Add(col_1);
		grid.ColumnDefinitions.Add(col_2);

		grid.RowDefinitions.Add(row_1);
		grid.RowDefinitions.Add(row_2);
		grid.RowDefinitions.Add(row_3);
		grid.RowDefinitions.Add(row_4);
		grid.RowDefinitions.Add(row_5);
		grid.RowDefinitions.Add(row_6);
		grid.RowDefinitions.Add(row_7);


		canvas = new InkCanvas();
		Grid.SetRow(canvas, 0);
		Grid.SetColumn(canvas, 1);
		Grid.SetRowSpan(canvas, 100);

		var save_button = new Button();
		save_button.Content = "Save";
		save_button.Click += new RoutedEventHandler(this.saveCanvas);
		Grid.SetRow(save_button, 0);
		Grid.SetColumn(save_button, 0);

		var white_button = new Button();
		white_button.Background = Brushes.White;
		white_button.Click += new RoutedEventHandler((sender, evt) => { canvas.DefaultDrawingAttributes.Color = Colors.White; });
		Grid.SetRow(white_button, 1);
		Grid.SetColumn(white_button, 0);

		var black_button = new Button();
		black_button.Background = Brushes.Black;
		black_button.Click += new RoutedEventHandler((sender, evt) => { canvas.DefaultDrawingAttributes.Color = Colors.Black; });
		Grid.SetRow(black_button, 2);
		Grid.SetColumn(black_button, 0);

		var red_button = new Button();
		red_button.Background = Brushes.Red;
		red_button.Click += new RoutedEventHandler((sender, evt) => { canvas.DefaultDrawingAttributes.Color = Colors.Red; });
		Grid.SetRow(red_button, 3);
		Grid.SetColumn(red_button, 0);

		var green_button = new Button();
		green_button.Background = Brushes.Green;
		green_button.Click += new RoutedEventHandler((sender, evt) => { canvas.DefaultDrawingAttributes.Color = Colors.Green; });
		Grid.SetRow(green_button, 4);
		Grid.SetColumn(green_button, 0);

		var yellow_button = new Button();
		yellow_button.Background = Brushes.Yellow;
		yellow_button.Click += new RoutedEventHandler((sender, evt) => { canvas.DefaultDrawingAttributes.Color = Colors.Yellow; });
		Grid.SetRow(yellow_button, 5);
		Grid.SetColumn(yellow_button, 0);

		var blue_button = new Button();
		blue_button.Background = Brushes.Blue;
		blue_button.Click += new RoutedEventHandler((sender, evt) => { canvas.DefaultDrawingAttributes.Color = Colors.Blue; });
		Grid.SetRow(blue_button, 6);
		Grid.SetColumn(blue_button, 0);

		root.Title = "Simply Sketch";
		grid.Children.Add(save_button);
		grid.Children.Add(black_button);
		grid.Children.Add(white_button);
		grid.Children.Add(green_button);
		grid.Children.Add(red_button);
		grid.Children.Add(yellow_button);
		grid.Children.Add(blue_button);
		grid.Children.Add(canvas);

		root.ResizeMode = ResizeMode.CanResizeWithGrip;
		canvas.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(settings.canvas_color));
		canvas.DefaultDrawingAttributes.Color = (Color)(new ColorConverter().ConvertFrom(settings.brush_color));
		canvas.DefaultDrawingAttributes.Height = 10;
		canvas.DefaultDrawingAttributes.Width = 10;
		canvas.EditingModeInverted = InkCanvasEditingMode.EraseByPoint;
		canvas.EditingMode = InkCanvasEditingMode.Ink;

		root.Content = grid;
		root.Show();
	}

	[STAThread]
	public static void Main(){
		new TheSketchpad().Run();
	}
}

}