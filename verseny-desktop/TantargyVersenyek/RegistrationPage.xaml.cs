using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        Frame mainFrame;
        MySqlConnection conn;
        public RegistrationPage(Frame frame)
        {
            InitializeComponent();
            mainFrame = frame;
        }

        void ConnectToDatabase()
        {
            string myConnectionString;
            myConnectionString = "server=localhost;uid=root;" +
                "pwd=012345; database=tantargy_versenyek";

            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                Console.WriteLine("Database connection was successfull!");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        void ConnectionClose()
        {
            conn.Close();
            Console.WriteLine("Database connection closed.");
        }

        //felhasználó létrehozás gomb kattintás
        private void CreateUser_Click(object sender, RoutedEventArgs e)
        {
            ConnectToDatabase();//mar letezik az tantarg_versenyek adatbazis
            var cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = $"INSERT INTO user (email, password, address, phone_number, name) VALUES('{EmailTextBox.Text}','{PasswordTextBox.Text}','{AddrTextBox.Text}','{PhoneNumberTextBox.Text}','{UserNameTextBox}');";
            cmd.ExecuteNonQuery();

            ConnectionClose();
            mainFrame.Navigate(new LoginPage(mainFrame));
        }


        /// <summary>
        /// Insert 3 row into database
        /// </summary>
        void InsertData()
        {
            var cmd = new MySqlCommand();
            cmd.Connection = conn;
            //cmd.CommandText = "INSERT INTO user (password, address, phone_number, name, email) VALUES('83774','Szeged Nyúl utca 3.','06-30-123-2341','Kiss Katalin','katalin@gmail.com');";
            //cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO user (email, password, address, phone_number, name) VALUES('gabor@gmail.com','83774','Zagyvarékas Keselyű utca 3.','06-30-123-2341','Nagy Gábor');";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO user (email, password, address, phone_number, name) VALUES('pista@gmail.com','895774','Gödöllő Árpád utca 3.','06-20-123-2341','Kovács Pista');";
            cmd.ExecuteNonQuery();
            //cmd.CommandText = "INSERT INTO user (email, password, address, phone_number, name) VALUES('roland@gmail.com','83774','Pécs Répa utca 3.','06-30-123-2341','Kovács Roland');";
            //cmd.ExecuteNonQuery();
            Console.WriteLine("Data insert finished!");
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new LoginPage(mainFrame));
        }
    }
}
