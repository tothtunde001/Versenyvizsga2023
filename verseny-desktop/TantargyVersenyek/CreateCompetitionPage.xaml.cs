using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using TantargyVersenyek.Model;

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

        /// <summary>
        /// Új verseny létrehozása
        /// </summary>
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

            // Meghívjuk a verseny létrehozása API-t
            HttpResponseMessage response = client.PostAsync("verseny/tanar/create", content).Result;
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response);
                Console.WriteLine("verseny létrehozés sikertelen, ismeretlen hiba.");
                return;
            }

            var responseBody = await response.Content.ReadAsStringAsync();
            var body = JsonConvert.DeserializeObject<GeneralResponse>(responseBody);

            if (!body.Status.Equals("OK"))
            {
                // Kiírjuk a hibaüzenetet a response-ból
                Console.WriteLine(body.Message);
                return;
            }
            MessageBox.Show("Új verseny létrehozva!", "Operation Success");
            mainFrame.Navigate(new CompetitionList(mainFrame, username));
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new CompetitionList(mainFrame, username));   
        }
    }
}
