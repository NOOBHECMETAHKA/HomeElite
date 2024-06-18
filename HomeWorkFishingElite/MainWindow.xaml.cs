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

namespace HomeWorkFishingElite
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainFunctionForHomeFishingElite func;
        public MainWindow()
        {
            InitializeComponent();
            Title = "Элитная рыбалка";
            func = new MainFunctionForHomeFishingElite();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            List<responsbilities> jobs = func.authUserByLoginAndPassword(tbLogin.Text, pdPassword.Password);
            if(jobs == null)
            {
                func.printMessage("Неверный логин или пароль", MessageBoxImage.Error); 
            }
            else
            {
                func.printMessage("Успешная авторизация! Добро пожаловать", MessageBoxImage.Information);
                App.responsbilities = jobs;
                ActivePanel activePanelWindow = new ActivePanel();
                activePanelWindow.Show();
                this.Close();
            }
        }

        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
