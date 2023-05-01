using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace TantargyVersenyek
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class CompetitionList : Page
    {
        Frame mainFrame;

        HttpClient client = new HttpClient();

        //konstruktor
        public CompetitionList(Frame navigationFrame)
        {
            InitializeComponent();
            client.BaseAddress = new Uri("http://127.0.0.1:8000/api/");
            mainFrame = navigationFrame;

            loadCompetitions();
            
        }
        //konstrikutor vége


        private void NewCompetition_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Át kell navigálni egy új oldalra, ahol a versenyt lehet létrehozni
        }

        private async void loadCompetitions()
        {
            // Meghívjuk a verseny lista API-t
            HttpResponseMessage response = client.GetAsync("verseny/tanar/list").Result;
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response);
                MessageLabel.Content = "Versenyek listázása sikertelen, ismeretlen hiba.";
                return;
            }

            var responseBody = await response.Content.ReadAsStringAsync();
            var body = JsonConvert.DeserializeObject<LoginResponse>(responseBody);

            if (!body.Status.Equals("OK"))
            {
                // Kiírjuk a hibaüzenetet a response-ból
                MessageLabel.Content = body.Message;
                return;
            }

            //TODO: be kell tölteni a versenyeket, és megjeleníteni az oldalon
            //Mindegyikhez kell egy szerkesztés és egy törlés gomb
        }
    }
}
