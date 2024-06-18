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
using System.Windows.Shapes;

namespace HomeWorkFishingElite
{
    /// <summary>
    /// Логика взаимодействия для ActivePanel.xaml
    /// </summary>
    public partial class ActivePanel : Window
    {
        MainFunctionForHomeFishingElite func;
        fishing_asset selectedFishingAssetElement;
        List<fishing_asset> fishingAssettsList;
        
        /// <summary>
        /// Функционал ограничения роли
        /// </summary>
        public void setRoles()
        {
            List<responsbilities> jobs = App.responsbilities;
            foreach (var job in jobs)
            {
                switch(job.role.title)
                {
                    case "Администратор                                                           ":
                        btnFeedFish.Visibility = Visibility.Visible;
                        btnTouristsPlan.Visibility = Visibility.Visible;
                        break;
                    case "Инструктор                                                              ":
                        btnTouristsPlan.Visibility = Visibility.Visible;
                        break;
                    case "Кормящий                                                                ":
                        btnFeedFish.Visibility = Visibility.Visible;
                        break;
                }
            }
        }

        public ActivePanel()
        {
            InitializeComponent();
            Title = "Панель активности";
            func = new MainFunctionForHomeFishingElite();
            reFillList();
            setRoles();

            dgFishingAssets.ItemsSource = fishingAssettsList;
            dgFishingAssets.SelectedValuePath = "id";
        }

        public void reFillList()
        {
            fishingAssettsList = func.getFishingAsset();
        }

        private void dgFishingAssets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dgFishingAssets.SelectedItem != null)
            {
                selectedFishingAssetElement = dgFishingAssets.SelectedItem as fishing_asset;
            }
        }

        private void btnDeleteFishingAsset_Click(object sender, RoutedEventArgs e)
        {
            if (selectedFishingAssetElement != null)
            {
                func.deleteFishingAsset(selectedFishingAssetElement);
                func.printMessage("Активность успешно удалена", MessageBoxImage.Information);
                selectedFishingAssetElement = null;
            }
            else
            {
                func.printMessage("Активность требуется выбрать", MessageBoxImage.Warning);
            }
        }

        private void btnAddFishingAsset_Click(object sender, RoutedEventArgs e)
        {
            ActiveAddForm activeAddForm = new ActiveAddForm();
            activeAddForm.Show();
            this.Close();
        }

        private void btnFeedFish_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnTouristsPlan_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
