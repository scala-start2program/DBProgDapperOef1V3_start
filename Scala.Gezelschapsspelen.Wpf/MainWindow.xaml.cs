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
using Scala.Gezelschapsspelen.Core.Entities;
using Scala.Gezelschapsspelen.Core.Services;

namespace Scala.Gezelschapsspelen.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        SpelService spelService = new SpelService();
        bool isNew;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ActivateLeft();
            PopulateCategoriën();
            PopulateSpelen();

        }
        private void ActivateLeft()
        {
            grpLeft.IsEnabled = true;
            grpRight.IsEnabled = false;
            btnBewaren.Visibility = Visibility.Hidden;
            btnAnnuleren.Visibility = Visibility.Hidden;
        }
        private void ActivateRight()
        {
            grpLeft.IsEnabled = false;
            grpRight.IsEnabled = true;
            btnBewaren.Visibility = Visibility.Visible;
            btnAnnuleren.Visibility = Visibility.Visible;
        }
        private void PopulateSpelen()
        {
            if(cmbFilter.SelectedIndex == -1)
                lstSpelen.ItemsSource = spelService.GetSpelen();
            else
            {
                string catId = cmbFilter.SelectedValue.ToString();
                lstSpelen.ItemsSource = spelService.GetSpelen(catId);
            }
            lstSpelen.Items.Refresh();
        }
        private void PopulateCategoriën()
        {
            cmbCategorie.ItemsSource = spelService.GetCategorieën();
            cmbCategorie.Items.Refresh();

            cmbFilter.ItemsSource = spelService.GetCategorieën();
            cmbFilter.Items.Refresh();
        }
        private void ClearControls()
        {
            txtTitel.Text = "";
            txtMinLeeftijd.Text = "";
            txtMaxSpelers.Text = "";
            txtSpelduur.Text = "";
            cmbCategorie.SelectedIndex = -1;

        }

        private void LstSpelen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearControls();
            if (lstSpelen.SelectedItem != null)
            {
                Spel spel = (Spel)lstSpelen.SelectedItem;
                txtTitel.Text = spel.Titel;
                txtMinLeeftijd.Text = spel.MinimumLeeftijd.ToString();
                txtMaxSpelers.Text = spel.MaximumSpelers.ToString();
                txtSpelduur.Text = spel.Spelduur.ToString();
                cmbCategorie.SelectedValue = spel.CatId;
            }
        }

        private void BtnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            isNew = true;
            ActivateRight();
            ClearControls();
            txtTitel.Focus();
        }

        private void BtnWijzigen_Click(object sender, RoutedEventArgs e)
        {
            if (lstSpelen.SelectedItem != null)
            {
                isNew = false;
                ActivateRight();
                txtTitel.Focus();
            }
        }

        private void BtnVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            if (lstSpelen.SelectedItem != null)
            {
                if (MessageBox.Show("Ben je zeker?", "Spel verwijderen", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Spel spel = (Spel)lstSpelen.SelectedItem;
                    spelService.DeleteSpel(spel);
                    ClearControls();
                    PopulateSpelen();
                }
            }
        }

        private void BtnBewaren_Click(object sender, RoutedEventArgs e)
        {
            Spel spel;
            if (isNew)
            {
                spel = new Spel();
            }
            else
            {
                spel = (Spel)lstSpelen.SelectedItem;
            }
            spel.Titel = txtTitel.Text.Trim();
            int.TryParse(txtMinLeeftijd.Text, out int minimumLeeftijd);
            int.TryParse(txtMaxSpelers.Text, out int maximumSpelers);
            int.TryParse(txtSpelduur.Text, out int spelduur);

            spel.MinimumLeeftijd = minimumLeeftijd;
            spel.MaximumSpelers = maximumSpelers;
            spel.Spelduur = spelduur;
            spel.CatId = cmbCategorie.SelectedValue.ToString();

            if (isNew)
                spelService.AddSpel(spel);
            else
                spelService.UpdateSpel(spel);
            ActivateLeft();
            PopulateSpelen();
            lstSpelen.SelectedValue = spel.Id;
            LstSpelen_SelectionChanged(null, null);
        }

        private void BtnAnnuleren_Click(object sender, RoutedEventArgs e)
        {
            ClearControls();
            ActivateLeft();
            LstSpelen_SelectionChanged(null, null);
        }

        private void CmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateSpelen();
        }

        private void BtnClearFilter_Click(object sender, RoutedEventArgs e)
        {
            cmbFilter.SelectedIndex = -1;
            PopulateSpelen();
        }
    }
}
