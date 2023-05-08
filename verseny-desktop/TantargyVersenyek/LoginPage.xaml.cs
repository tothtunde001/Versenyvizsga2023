using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using TantargyVersenyek.Model;

namespace TantargyVersenyek
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        Frame mainFrame;

        HttpClient client = new HttpClient();

        //konstruktor
        public LoginPage(Frame navigationFrame)
        {
            InitializeComponent();
            client.BaseAddress = new Uri("http://127.0.0.1:8000/api/");
            mainFrame = navigationFrame;
        }
        //konstrikutor vége

        /// <summary>
        /// Bejelentkezés
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            // Összerakjuk a request body-t a bejelentkezéshez
            var loginData = new
            {
                username = UserTextBox.Text,
                password = PasswordTextBox.Text,
            };
            string jsonData = JsonConvert.SerializeObject(loginData);
            var content = new StringContent(jsonData.ToString(), Encoding.UTF8, "application/json");

            // Meghívjuk a bejelentkezés API-t
            HttpResponseMessage response = client.PostAsync("tanarok/login", content).Result;
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response);
                MessageLabel.Content = "Bejelentkezés sikertelen, ismeretlen hiba.";
                return;
            }

            var responseBody = await response.Content.ReadAsStringAsync();
            var body = JsonConvert.DeserializeObject<LoginResponse>(responseBody);

            if (!body.Status.Equals("OK")) {
                // Kiírjuk a hibaüzenetet a response-ból
                MessageLabel.Content = body.Message;
                return;
            }

            // Sikeres bejelentkezés
            MessageLabel.Content = body.Message;


            //Itt kell átirányítani a verseny oldalra
            mainFrame.Navigate(new CompetitionList(mainFrame, UserTextBox.Text));

        }

        /// <summary>
        /// Regisztráció
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new RegistrationPage(mainFrame));
        }
    }

    public class LoginResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }

    public class TanarResponse
    {
        public string Status { get; set; }
        public List<Tanar> Data { get; set; }
    }

    public class VersenyResponse
    {
        public string Status { get; set; }
        public List<Verseny> Data { get; set; }
    }
}
