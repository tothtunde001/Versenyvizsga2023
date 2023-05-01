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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        Frame mainFrame;
        //konstruktor
        public LoginPage(Frame navigationFrame)
        {
            InitializeComponent();
            mainFrame = navigationFrame;
        }
        //konstrikutor vége

        //konstruktor
        public LoginPage()
        {
            InitializeComponent();
        }
        //konstrikutor vége

        /// <summary>
        /// Bejelentkezés
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            PasswordTextBox.Visibility = Visibility.Visible;
            UserTextBox.Visibility = Visibility.Visible;
            LoginLabel.Visibility = Visibility.Visible;

            //Button btn = new Button();
            //GridTarolo.Children.Add(btn);
            //Button btn2 = new Button();
            //GridTarolo.Children.Add(btn2);
            //Button btn3 = new Button();
            //GridTarolo.Children.Add(btn3);
        }

        /// <summary>
        /// Regisztráció
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new RegistrationPage(mainFrame));

            //RegistrationWindow registrationWindow = new RegistrationWindow();
            //registrationWindow.Show();
        }
    }
}
