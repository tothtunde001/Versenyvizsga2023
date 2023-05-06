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

namespace TantargyVersenyek
{
    /// <summary>
    /// Interaction logic for CreateCompetitionPage.xaml
    /// </summary>
    public partial class CreateCompetitionPage : Page
    {
        HttpClient client = new HttpClient();
        Frame mainFrame;
        string username;
        public CreateCompetitionPage(Frame navigationFram, string username)
        {
            InitializeComponent();
            client.BaseAddress = new Uri("http://127.0.0.1:8000/api/");
            mainFrame = navigationFram;
            this.username = username;
        }

        private async void CreateCompetitionBtn_Click(object sender, RoutedEventArgs e)
        {
            // Összerakjuk a request body-t a bejelentkezéshez
            var newCompetitionData = new
            {
                competition_name = CompetitionNameTextBox.Text,
                description = DescriptionTextBox.Text,
            };
            string jsonData = JsonConvert.SerializeObject(newCompetitionData);
            var content = new StringContent(jsonData.ToString(), Encoding.UTF8, "application/json");

            // Meghívjuk a bejelentkezés API-t
            HttpResponseMessage response = client.PostAsync("verseny/tanar/create", content).Result;
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response);
                Console.WriteLine("verseny létrehozés sikertelen, ismeretlen hiba.");
                return;
            }

            var responseBody = await response.Content.ReadAsStringAsync();
            var body = JsonConvert.DeserializeObject<LoginResponse>(responseBody);

            if (!body.Status.Equals("OK"))
            {
                // Kiírjuk a hibaüzenetet a response-ból
                Console.WriteLine(body.Message);
                return;
            }
            MessageBoxResult result = MessageBox.Show("Új verseny létrehozva!", "Operation Success", MessageBoxButton.OK);
            switch (result)
            {
                case MessageBoxResult.OK:
                    mainFrame.Navigate(new CompetitionList(mainFrame, username));
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("Oh well, too bad!", "My App");
                    break;
                case MessageBoxResult.Cancel:
                    MessageBox.Show("Nevermind then...", "My App");
                    break;
            }
            //....
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new CompetitionList(mainFrame, username));
            
        }
    }
}
