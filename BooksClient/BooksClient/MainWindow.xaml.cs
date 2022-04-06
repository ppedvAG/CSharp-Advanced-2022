using Microsoft.Win32;
using NJsonSchema;
using NJsonSchema.CodeGeneration.CSharp;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Windows;
using System.Xml.Serialization;

namespace BooksClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void GetBooks(object sender, RoutedEventArgs e)
        {
            var url = $"https://www.googleapis.com/books/v1/volumes?q={searchTb.Text}";
            var http = new HttpClient();
            var json = await http.GetStringAsync(url);
            jsonTb.Text = json;

            BooksResults result = System.Text.Json.JsonSerializer.Deserialize<BooksResults>(json);
            myGrid.ItemsSource = result.items.Select(x => x.volumeInfo)
                                             .OrderBy(x => x.language)
                                             .ThenByDescending(x => x.pageCount).ToList();

            //dynamic dyn = System.Text.Json.JsonSerializer.Deserialize<BooksResults>(json);

            //MessageBox.Show(dyn.totalItems.ToString());
        }

        private async void GenCode(object sender, RoutedEventArgs e)
        {
            var url = $"https://www.googleapis.com/books/v1/volumes?q={searchTb.Text}";
            var http = new HttpClient();
            var json = await http.GetStringAsync(url);
            jsonTb.Text = json;

            var schema = await JsonSchema.FromJsonAsync(json);

            var generator = new CSharpGenerator(schema);
            var file = generator.GenerateFile();


        }

        private void SaveToXML(object sender, RoutedEventArgs e)
        {
            var dlg = new SaveFileDialog() { Title = "Save as XML file", Filter = "XML-File|*.xml|All Files|*.*" };
            if (dlg.ShowDialog().Value)
            {
                var xmlSerial = new XmlSerializer(typeof(List<Volumeinfo>));
                using var sw = new StreamWriter(dlg.FileName);
                xmlSerial.Serialize(sw, myGrid.ItemsSource);
            }
        }

        private void OpenXML(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog() { Title = "Select XML file", Filter = "XML-File|*.xml|All Files|*.*" };
            if (dlg.ShowDialog().Value)
            {
                var xmlSerial = new XmlSerializer(typeof(List<Volumeinfo>));
                using var sr = new StreamReader(dlg.FileName);
                myGrid.ItemsSource = (List<Volumeinfo>)xmlSerial.Deserialize(sr);
            }
        }

        private void ShowSum(object sender, RoutedEventArgs e)
        {
            var books = (List<Volumeinfo>)myGrid.ItemsSource;

            var sum = books.Where(x => x.language == "en").Sum(x => x.pageCount);

            MessageBox.Show($"Sum of PageCount {sum}");
        }

        private void ShowAno(object sender, RoutedEventArgs e)
        {
            var books = (List<Volumeinfo>)myGrid.ItemsSource;

            var query = from b in books
                        select new { Title = b.title, Pages = b.pageCount, Lang = b.language };

            myGrid.ItemsSource = query.ToList();
        }

        private void ShowSelected(object sender, RoutedEventArgs e)
        {
            if (myGrid.SelectedItem is Volumeinfo vi)
            {
                MessageBox.Show(vi.title);
            }
        }

        private void AllTitle(object sender, RoutedEventArgs e)
        {
            var books = (List<Volumeinfo>)myGrid.ItemsSource;

            var niceString = string.Join(", ", books.Select(x => x.title));

            MessageBox.Show(niceString);
        }
    }
}
