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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MySqlConnection conn;
        
        public MainWindow()
        {
            InitializeComponent();
            Frame Savedframe = _NavigationFrame;
            Frame Savedframe2 = _NavigationFrame;
            //new LoginPage(_NavigationFrame) -> ezt hívjuk példányosításnak vagy más néven objektum létrehozásnak vagy 
            //úgyis mondhatom, hogy osztályból példányt hozok létre.
            Savedframe2.Navigate(new LoginPage(_NavigationFrame));
            //RegistrationBtn.Background = Brushes.Red;
            CreateDatabase();

            //ConnectToDatabase();//mar letezik az tantarg_versenyek adatbazis
            ////CreateTable();
            //ConnectionClose();
        }

        void CreateDatabase()
        {
            ConnectToMySQLServer();
            //CreateDB();//adatbazis elkeszitese
            var cmd = new MySqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "CREATE DATABASE IF NOT EXISTS verseny";
            cmd.ExecuteNonQuery();


            //Console.WriteLine("Database created!");
            ConnectionClose();
        }

        void ConnectToMySQLServer()
        {
            string myConnectionString;
            myConnectionString = "server=localhost;uid=root;" +
                "pwd=;";// database=eticketingdb";

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

        //public void CreateDB()
        //{
        //    var cmd = new MySqlCommand();
        //    cmd.Connection = conn;

        //    cmd.CommandText = "CREATE DATABASE IF NOT EXISTS tantargy_versenyek";
        //    cmd.ExecuteNonQuery();

        //    Console.WriteLine("Database created!");
        //}

        //public void DeleteDB()
        //{
        //    var cmd = new MySqlCommand();
        //    cmd.Connection = conn;

        //    cmd.CommandText = "DROP DATABASE user_2";
        //    cmd.ExecuteNonQuery();

        //    Console.WriteLine("Database deleted!");
        //}


        /// <summary>
        /// Create new database table
        /// </summary>
        void CreateTable()
        {
            //<type> <valtozonev>;
            int a;
            int tarolo;
            tarolo = 5;

            var cmd = new MySqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "DROP TABLE IF EXISTS user";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"CREATE TABLE user (email varchar(200) PRIMARY KEY NOT NULL, password text NOT NULL, address text NOT NULL, phone_number text NOT NULL, name text NOT NULL)";
            cmd.ExecuteNonQuery();

            Console.WriteLine("Data table created!");
        }

        ///// <summary>
        ///// Insert 3 row into database
        ///// </summary>
        //void InsertData()
        //{
        //    var cmd = new MySqlCommand();
        //    cmd.Connection = conn;
        //    //cmd.CommandText = "INSERT INTO user (password, address, phone_number, name, email) VALUES('83774','Szeged Nyúl utca 3.','06-30-123-2341','Kiss Katalin','katalin@gmail.com');";
        //    //cmd.ExecuteNonQuery();
        //    cmd.CommandText = "INSERT INTO user (email, password, address, phone_number, name) VALUES('gabor@gmail.com','83774','Zagyvarékas Keselyű utca 3.','06-30-123-2341','Nagy Gábor');";
        //    cmd.ExecuteNonQuery();
        //    cmd.CommandText = "INSERT INTO user (email, password, address, phone_number, name) VALUES('pista@gmail.com','895774','Gödöllő Árpád utca 3.','06-20-123-2341','Kovács Pista');";
        //    cmd.ExecuteNonQuery();
        //    //cmd.CommandText = "INSERT INTO user (email, password, address, phone_number, name) VALUES('roland@gmail.com','83774','Pécs Répa utca 3.','06-30-123-2341','Kovács Roland');";
        //    //cmd.ExecuteNonQuery();
        //    Console.WriteLine("Data insert finished!");
        //}

        ///// <summary>
        ///// Get database all rows.
        ///// </summary>
        //void GetRows()
        //{
        //    //string user1Name;
        //    //int user1Age;
        //    //string user1Address;

        //    //string user2Name;
        //    //int user2Age;
        //    //string user2Address;

        //    string sql = "SELECT * FROM user;";
        //    int a = 10;//32bites -||-
        //    int b;//32 bites területet lefoglal a memóriából
        //    b = a;//10
        //    a = 15;//
        //    Console.WriteLine($"a:{a}, b:{b}");//a:15, b:10
        //    //byte b;//8bit [0,255]
        //    //char c;//8bit [-128,127]
        //    //double d;//5.32

        //    //byte b2 = 255 & 1;
        //    //valtozok stack memóriaterületen jönnek létre.
        //    //objektumok pedig a heap memóriaterülten jönnek létre.


        //    User user = new User("Gabi", 18);//osztály példányosítás, user az egy objektum lesz, ekkor nem változónak hívjuk.
        //    user.Name = "Dénes";
        //    user.Name = "Dénes";
        //    Console.WriteLine(user.Name);
        //    Console.WriteLine(user.Name);
        //    Console.WriteLine(user.Name);

        //    User user2 = new User("Melinda", 19);
        //    //user2 = user;//nem érték átmásolása történik, hanem referencia átmásolás, címszerinti értékadás történik.
        //    //user.Name = "Botond";

        //    Console.WriteLine(user.Name);
        //    Console.WriteLine(user2.Name);
        //    MySqlCommand cmd = new MySqlCommand(sql, conn);

        //    MySqlDataReader rdr = cmd.ExecuteReader();

        //    while (rdr.Read())
        //    {
        //        Console.WriteLine("{0} {1} {2} {3} {4}", rdr.GetString(0), rdr.GetString(1),
        //                rdr.GetString(2), rdr.GetString(3), rdr.GetString(4));
        //    }
        //    rdr.Close();
        //    //Console.WriteLine("{0} {1} {2}", rdr.GetString(0), rdr.GetString(1),
        //    //            rdr.GetInt32(2));
        //    Console.WriteLine("Database selection finished!");
        //}

        ////DBSelection(DBQueryTextBox.Text);
        //void DBSelection(string sql)
        //{
        //    var cmd = new MySqlCommand(sql, conn);

        //    MySqlDataReader rdr = cmd.ExecuteReader();

        //    while (rdr.Read())
        //    {
        //        Console.WriteLine("{0} {1} {2} {3} {4}", rdr.GetString(0), rdr.GetString(1),
        //                rdr.GetString(2), rdr.GetString(3), rdr.GetString(4));
        //    }
        //    rdr.Close();
        //    //Console.WriteLine("{0} {1} {2}", rdr.GetString(0), rdr.GetString(1),
        //    //            rdr.GetInt32(2));
        //    Console.WriteLine("Database selection finished!");
        //}

        ///// <summary>
        ///// Modify one database row
        ///// </summary>
        //void ModifyRow()
        //{
        //    var cmd = new MySqlCommand();
        //    cmd.Connection = conn;
        //    cmd.CommandText = "UPDATE user SET phone_number = '06-20-256-1024', address = 'Szolnok Géza utca 10.' WHERE name = 'Nagy Gábor';";
        //    cmd.ExecuteNonQuery();
        //    Console.WriteLine("Row modifying finished!");
        //}

        ///// <summary>
        ///// Delete one row from database
        ///// </summary>
        //void DeleteRow()
        //{
        //    var cmd = new MySqlCommand();
        //    cmd.Connection = conn;
        //    cmd.CommandText = "DELETE FROM user WHERE name = 'Nagy Gábor';";
        //    cmd.ExecuteNonQuery();
        //    Console.WriteLine("Row deleting finished!");
        //}
    }
}
