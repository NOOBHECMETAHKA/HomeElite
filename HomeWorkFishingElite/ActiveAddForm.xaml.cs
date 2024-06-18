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
    /// Логика взаимодействия для ActiveAddForm.xaml
    /// </summary>
    public partial class ActiveAddForm : Window
    {
        MainFunctionForHomeFishingElite func;

        public ActiveAddForm()
        {
            InitializeComponent();
            func = new MainFunctionForHomeFishingElite();
            Title = "Окно добавления активности";
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            ActivePanel panel = new ActivePanel();
            panel.Show();
            this.Close();
        }

        private void btnAddFishingAsset_Click(object sender, RoutedEventArgs e)
        {
            fishing_asset newFishingAsset = new fishing_asset()
            {
                created_at = DateTime.Now,
                title = tbNameActive.Text,
                category_id = (int)cbCategoryActive.SelectedValue,
                catch_cost_per = decimal.Parse(tbCatchCostPer.Text),
                count_of_individuals = int.Parse(tbCountOfIndividuals.Text),
                description = tbDescription.Text,
            };

            func.addFishingAsset(newFishingAsset);
            ActivePanel activePanelWindow = new ActivePanel();
            activePanelWindow.reFillList();
            activePanelWindow.Show();
            this.Close();
        }

        private void cbCategoryActive_Loaded(object sender, RoutedEventArgs e)
        {
            List<category> categories = func.getCategory();
            cbCategoryActive.ItemsSource = categories;

            cbCategoryActive.SelectedValuePath = "id";
            cbCategoryActive.DisplayMemberPath = "name";
        }
    }
}
