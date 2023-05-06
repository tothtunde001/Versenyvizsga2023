using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
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
    public partial class CompetitionList : Page
    {
        Frame mainFrame;

        HttpClient client = new HttpClient();
        string username;
        List<Verseny> szurtVersenyLista;

        //konstruktor
        public CompetitionList(Frame navigationFrame, string username)
        {
            InitializeComponent();
            client.BaseAddress = new Uri("http://127.0.0.1:8000/api/");
            mainFrame = navigationFrame;
            this.username = username;
            szurtVersenyLista = new List<Verseny>();//ures versenyeket tartalmazo lista
            loadCompetitions();

            
        }
        //konstrikutor vége


        private void NewCompetition_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Át kell navigálni egy új oldalra, ahol a versenyt lehet létrehozni
            //Itt kell átirányítani a verseny oldalra
            mainFrame.Navigate(new CreateCompetitionPage(mainFrame, username));
        }

        private async void loadCompetitions()
        {
            //// Meghívjuk a taná lista API-t -> Ez az API nem került implementáéásra
            //HttpResponseMessage response = client.GetAsync("tanarok").Result;
            ////HttpResponseMessage response = client.GetAsync("tanarok").Result;
            //if (!response.IsSuccessStatusCode)
            //{
            //    Console.WriteLine(response);
            //    MessageLabel.Content = "tanarok listázása sikertelen, ismeretlen hiba.";
            //    return;
            //}
            //var responseBody = await response.Content.ReadAsStringAsync();
            //TanarResponse body_tanar = JsonConvert.DeserializeObject<TanarResponse>(responseBody);
            //string tanartargy = "";
            //foreach(Tanar tanar in body_tanar.Data)
            //{
            //    if(tanar.Username == this.username)
            //    {
            //        tanartargy = tanar.Subject;
            //        break;
            //    }
            //}
            //string verseny_szuro = "";
            //switch(tanartargy)
            //{
            //    case "matek":
            //        verseny_szuro = "Ez egy matematika verseny";
            //        break;
            //    case "környezet":
            //        verseny_szuro = "Ez egy környezet verseny";
            //        break;
            //    case "informatika":
            //        verseny_szuro = "Ez egy informatika verseny";
            //        break;
            //}

            // Meghívjuk a verseny lista API-t
            HttpResponseMessage response = client.GetAsync("verseny/tanar/list").Result;
            //HttpResponseMessage response = client.GetAsync("tanarok").Result;
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response);
                MessageLabel.Content = "Versenyek listázása sikertelen, ismeretlen hiba.";
                return;
            }

            var responseBody = await response.Content.ReadAsStringAsync();
            VersenyResponse body_verseny = JsonConvert.DeserializeObject<VersenyResponse>(responseBody);
            szurtVersenyLista.Clear();
            foreach(Verseny verseny in body_verseny.Data)
            {
                //if(verseny.Description == verseny_szuro)
                //{
                    szurtVersenyLista.Add(verseny);
                //}

            }
            //if (!body.Status.Equals("OK"))
            //{
            //    // Kiírjuk a hibaüzenetet a response-ból
            //    MessageLabel.Content = body.Message;
            //    return;
            //}
            MessageLabel.Content = body_verseny.Data;
            RefreshDataTable();
            //TODO: be kell tölteni a versenyeket, és megjeleníteni az oldalon
            //Mindegyikhez kell egy szerkesztés és egy törlés gomb
        }

        private void RefreshDataTable()
        {
            List<DataGridModel> dataGridModelList = new List<DataGridModel>();
            foreach (Verseny verseny in szurtVersenyLista)
            {
                dataGridModelList.Add(new DataGridModel()
                {
                    Id = verseny.Id,
                    Competition = verseny.Competition_name,
                    Description = verseny.Description,
                }
                );
            }
            VersenyekDataGrid.ItemsSource = dataGridModelList;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataGridModel dataRowView = (DataGridModel)((Button)e.Source).DataContext;
                Verseny versenyObjektum = null;
                foreach (Verseny verseny in szurtVersenyLista)
                {
                    if (verseny.Id == dataRowView.Id)
                    {
                        versenyObjektum = verseny;
                    }
                }
                if(versenyObjektum != null)
                {
                    mainFrame.Navigate(new EditPage(mainFrame, username, versenyObjektum));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private async void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Verseny versenyObjektum = null;
            try
            {
                DataGridModel dataRowView = (DataGridModel)((Button)e.Source).DataContext;
                //String Competition = dataRowView[1].ToString();
                //String Description = dataRowView[2].ToString();
                MessageBox.Show("You Clicked : " + dataRowView.Competition + "\r\n " + dataRowView.Description);
                //This is the code which will show the button click row data. Thank you.


                var versenyId = dataRowView.Id;

                ////$"/api/sessions/{id}"
                // Meghívjuk a bejelentkezés API-t
                await client.DeleteAsync($"verseny/tanar/delete/{versenyId}");
                //if (!response.IsSuccessStatusCode)
                //{
                //    Console.WriteLine(response);
                //    Console.WriteLine("verseny törlés sikertelen, ismeretlen hiba.");
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

                loadCompetitions();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new LoginPage(mainFrame));
        }
    }
}
