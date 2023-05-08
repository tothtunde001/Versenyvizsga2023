using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using TantargyVersenyek.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using Ubiety.Dns.Core.Common;

namespace TantargyVersenyek
{
    /// <summary>
    /// Interaction logic for EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        Frame mainFrame;
        string username;
        HttpClient client = new HttpClient();
        Verseny verseny;
        public EditPage(Frame navigationFram, string username, Verseny verseny)
        {
            InitializeComponent();
            client.BaseAddress = new Uri("http://127.0.0.1:8000/api/");
            mainFrame = navigationFram;
            this.username = username;
            this.verseny = verseny;
            LoadData();
        }

        private async void LoadData()
        {
            CompetitionNameTextBox.Text = verseny.Competition_name;
            DescriptionTextBox.Text = verseny.Description;
            // Meghívjuk a verseny lista API-t
            HttpResponseMessage response = client.GetAsync($"kerdes/list/{verseny.Id}").Result;
            //HttpResponseMessage response = client.GetAsync("tanarok").Result;
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response);
                Console.WriteLine("kérdés listázása sikertelen, ismeretlen hiba.");
                return;
            }
            var responseBody = await response.Content.ReadAsStringAsync();
            KerdesResponse body_kerdes = JsonConvert.DeserializeObject<KerdesResponse>(responseBody);
            //if (!body.Status.Equals("OK"))
            //{
            //    // Kiírjuk a hibaüzenetet a response-ból
            //    MessageLabel.Content = body.Message;
            //    return;
            //}
            RefreshDataTable(body_kerdes);
            //TODO: be kell tölteni a versenyeket, és megjeleníteni az oldalon
            //Mindegyikhez kell egy szerkesztés és egy törlés gomb
        }

        private void RefreshDataTable(KerdesResponse body_kerdes)
        {
            KerdesekDataGrid.ItemsSource = body_kerdes.Data;
        }

        private async void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Kerdes kerdes = (Kerdes)((Button)e.Source).DataContext;
            var answer = MessageBox.Show(
                $"Biztosan törlöd az alábbi kérdést?\n({kerdes.Id}) {kerdes.Question}",
                "Kérdés törlése", MessageBoxButton.YesNo);

            if (answer != MessageBoxResult.Yes)
            {
                return;
            }

            // Meghívjuk a törlés API-t
            var response = await client.DeleteAsync($"kerdes/delete/{kerdes.Id}");

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response);
                MessageBox.Show("Kérdés törlés sikertelen, ismeretlen hiba.", "Kérdés törlése");
                return;
            }

            var responseBody = await response.Content.ReadAsStringAsync();
            var body = JsonConvert.DeserializeObject<LoginResponse>(responseBody);

            if (!body.Status.Equals("OK"))
            {
                // Kiírjuk a hibaüzenetet a response-ból
                MessageBox.Show(body.Message, "Kérdés törlése");
                return;
            }

            LoadData();
        }

        private async void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            saveCompetitionData();
            saveQuestions();
        }

        private async void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            // Új kérdés hozzáadása a versenyhez
 
            var newQuestionData = new
            {
                competitionId = verseny.Id,
                question = "Mintakérdés",
                answer1 = "Válasz1",
                answer2 = "Válasz2",
                answer3 = "Válasz3",
                answer4 = "Válasz4",
                correctAnswer = 1,
            };


            string jsonObject = JsonConvert.SerializeObject(newQuestionData);
            var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");

            var response = client.PostAsync("kerdes/create", content).Result;

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response);
                MessageBox.Show("Kérdés létrehozás sikertelen, ismeretlen hiba.", "Error", MessageBoxButton.OK);
                return;
            }

            var responseBody = await response.Content.ReadAsStringAsync();
            var body = JsonConvert.DeserializeObject<LoginResponse>(responseBody);

            if (!body.Status.Equals("OK"))
            {
                // Kiírjuk a hibaüzenetet a response-ból
                MessageBox.Show(body.Message, "Error", MessageBoxButton.OK);
                return;
            }

            // Sikeres kérdés létrehozás
            MessageBox.Show(body.Message, "Kérdés hozzáadás", MessageBoxButton.OK);
                
            LoadData();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new CompetitionList(mainFrame, username));
        }

        private async void saveCompetitionData()
        {
            // Verseny alapadatok frissítése

            var newData = new
            {
                competition_name = CompetitionNameTextBox.Text,
                description = DescriptionTextBox.Text,
            };
            string jsonObject = JsonConvert.SerializeObject(newData);
            var content2 = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");

            var response2 = client.PutAsync($"verseny/tanar/update/{verseny.Id}", content2).Result;

            var responseBody = await response2.Content.ReadAsStringAsync();
            var body = JsonConvert.DeserializeObject<GeneralResponse>(responseBody);

            if (!body.Status.Equals("OK"))
            {
                // Kiírjuk a hibaüzenetet a response-ból
                MessageBox.Show(body.Message, "Error", MessageBoxButton.OK);
                return;
            }

            // Sikeres szerkesztés
            MessageBox.Show(body.Message, "Operation Success", MessageBoxButton.OK);

        }

        private async void saveQuestions()
        {
            // Kérdések mentése

            foreach (Kerdes kerdes in KerdesekDataGrid.ItemsSource)
            {
                var newQuestionData = new
                {
                    competitionId = verseny.Id,
                    question = kerdes.Question,
                    answer1 = kerdes.Answer1,
                    answer2 = kerdes.Answer2,
                    answer3 = kerdes.Answer3,
                    answer4 = kerdes.Answer4,
                    correctAnswer = kerdes.CorrectAnswer
                };


                var jsonObject = JsonConvert.SerializeObject(newQuestionData);
                var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");

                Console.WriteLine(jsonObject);

                var response = client.PutAsync($"kerdes/update/{kerdes.Id}", content).Result;

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine(response);
                    MessageBox.Show("Kérdés módosítása sikertelen, ismeretlen hiba.", "Error", MessageBoxButton.OK);
                    return;
                }

                var responseBody = await response.Content.ReadAsStringAsync();
                var body = JsonConvert.DeserializeObject<GeneralResponse>(responseBody);

                if (!body.Status.Equals("OK"))
                {
                    // Kiírjuk a hibaüzenetet a response-ból
                    MessageBox.Show(body.Message, "Error", MessageBoxButton.OK);
                    return;
                }

                // Sikeres kérdés módosítás
                //MessageBox.Show(body.Message, "Kérdés módosítása", MessageBoxButton.OK);
            }
        }
    }



    public class KerdesResponse
    {
        public string Status { get; set; }
        public List<Kerdes> Data { get; set; }
    }

    public class GeneralResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }
}
