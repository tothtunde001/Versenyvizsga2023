using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace TantargyVersenyek
{
    /// <summary>
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        Frame mainFrame;

        HttpClient client = new HttpClient();
        public RegistrationPage(Frame frame)
        {
            InitializeComponent();
            client.BaseAddress = new Uri("http://127.0.0.1:8000/api/");
            mainFrame = frame;
        }

        //felhasználó létrehozás gomb kattintás
        private async void CreateUser_Click(object sender, RoutedEventArgs e)
        {
            // Létrehozzuk a request body-t
            var registrationData = new
            {
                username = UserNameTextBox.Text,
                password = PasswordTextBox.Text,
                email = EmailTextBox.Text,
                fullname = FullnameTextBox.Text,
                subject = "none",
                @class = "none"
            };
            string jsonData = JsonConvert.SerializeObject(registrationData);
            var content = new StringContent(jsonData.ToString(), Encoding.UTF8, "application/json");

            // Meghívjuk a regisztráció API-t
            HttpResponseMessage response = client.PostAsync("tanarok/signup", content).Result;
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response);
                MessageLabel.Content = "Regisztráció sikertelen. Ismeretlen hiba.";
            }

            var responseBody = await response.Content.ReadAsStringAsync();
            var body = JsonConvert.DeserializeObject<RegistrationResponse>(responseBody);

            if (!body.Status.Equals("OK"))
            {
                // Kiírjuk a hibaüzenetet a response-ból
                MessageLabel.Content = body.Message;
                return;
            }

            // Sikeres regisztráció
            MessageLabel.Content = body.Message;
            //mainFrame.Navigate(new LoginPage(mainFrame));

        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new LoginPage(mainFrame));
        }
    }

    public class RegistrationResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }
}
