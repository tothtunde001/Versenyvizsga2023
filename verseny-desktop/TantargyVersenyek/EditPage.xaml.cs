using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
using TantargyVersenyek.Model;

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

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EditDataGridModel dataRowView = (EditDataGridModel)((Button)e.Source).DataContext;
                //String Competition = dataRowView[1].ToString();
                //String Description = dataRowView[2].ToString();
                //MessageBox.Show("You Clicked : " + dataRowView.Competition + "\r\n " + dataRowView.Description);
                //This is the code which will show the button click row data. Thank you.
                //mainFrame.Navigate(new EditPage(mainFrame, username));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EditDataGridModel dataRowView = (EditDataGridModel)((Button)e.Source).DataContext;
                //String Competition = dataRowView[1].ToString();
                //String Description = dataRowView[2].ToString();
                //MessageBox.Show("You Clicked : " + dataRowView.Competition + "\r\n " + dataRowView.Description);
                //This is the code which will show the button click row data. Thank you.
                //mainFrame.Navigate(new EditPage(mainFrame, username));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private async void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            using (HttpClient client2 = new HttpClient())
            {
                var newDAta = new
                {
                    competition_name = CompetitionNameTextBox.Text,
                    description = DescriptionTextBox.Text,
                };
                string jsonObject = JsonConvert.SerializeObject(newDAta);
                var content2 = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");

                client2.BaseAddress = new Uri("http://127.0.0.1:8000/");
                var response2= client2.PutAsync("api/verseny/tanar/update/", content2).Result;

                if (response2.IsSuccessStatusCode) Console.Write("Success");
                else Console.Write("Error");
            }

            // Összerakjuk a request body-t a bejelentkezéshez
            //var VersenyData = new Verseny
            //{
            //    Competition_name = CompetitionNameTextBox.Text,
            //    Description = DescriptionTextBox.Text,
            //};
            //string jsonData = JsonConvert.SerializeObject(VersenyData);
            //var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            ////var company = JsonSerializer.Serialize(newData);
            //var request = new HttpRequestMessage(HttpMethod.Put, $"verseny/tanar/update/{jsonData}");
            //request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //request.Content = new StringContent(jsonData.ToString(), Encoding.UTF8);
            //request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //var response = await client.SendAsync(request);
            //response.EnsureSuccessStatusCode();

            //var httpClient = new HttpClient();
            // Meghívjuk a bejelentkezés API-t
            //HttpResponseMessage response = client.PutAsync("verseny/tanar/update", content).Result;
            ////var message = await httpClient.PutAsync("http://127.0.0.1:8000/api/verseny/tanar/update/", content);
            //if (!response.IsSuccessStatusCode)
            //{
            //    Console.WriteLine(response);
            //    Console.WriteLine("versenyek tabla modositasa sikertelen, ismeretlen hiba.");
            //    return;
            //}

            //var responseBody = await response.Content.ReadAsStringAsync();
            //var body = JsonConvert.DeserializeObject<LoginResponse>(responseBody);

            //if (!body.Status.Equals("OK"))
            //{
            //    // Kiírjuk a hibaüzenetet a response-ból
            //    Console.WriteLine(body.Message);
            //    return;
            //}
            MessageBoxResult result = MessageBox.Show("Mentes sikeres!", "Operation Success", MessageBoxButton.OK);
            //switch (result)
            //{
            //    case MessageBoxResult.OK:
            //        mainFrame.Navigate(new CompetitionList(mainFrame, username));
            //        break;
            //    case MessageBoxResult.No:
            //        MessageBox.Show("Oh well, too bad!", "My App");
            //        break;
            //    case MessageBoxResult.Cancel:
            //        MessageBox.Show("Nevermind then...", "My App");
            //        break;
            //}
        }

        private void DeleteBtn_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new CompetitionList(mainFrame, username));
        }
    }
}
