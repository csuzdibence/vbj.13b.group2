using Newtonsoft.Json;
using Students.Model;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Windows;

namespace MyProject
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            string result = httpClient.GetStringAsync("http://localhost:5043/Teacher/All").Result;
            List<Teacher>? teachers = JsonConvert.DeserializeObject<List<Teacher>>(result);

            int a = 100;
            int b = 250;

            int sum = int.Parse(httpClient.GetStringAsync($"http://localhost:5043/Sum/{a}/{b}").Result);
        }
    }
}