using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using TestApi.Entities;

namespace KeeperPro
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //GetVisitors();
        }

        HttpClient client = new HttpClient();
        List<Visitors> v;
        public async void GetVisitors()
        {
            var response = await client.GetAsync("http://localhost:2904/api/visitors");
            if (response.IsSuccessStatusCode)
                v = JsonConvert.DeserializeObject<List<Visitors>>(await response.Content.ReadAsStringAsync());
            else
                MessageBox.Show(response.StatusCode.ToString());
            DG.ItemsSource = v;
        }
    }
}
