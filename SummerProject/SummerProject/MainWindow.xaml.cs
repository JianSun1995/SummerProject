using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using SummerProject.DependencyProperties;
using SummerProject.Models;
using SummerProject.ViewModels;
using SummerProject.VIews;

namespace SummerProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Overview _overview = new Overview();
        private readonly Random _random;
        private StackPanel _lastPickedPanel;

        private readonly SolidColorBrush _menuBrush =
            (SolidColorBrush) new BrushConverter().ConvertFromString("#FF29837E");

        public MainWindow()
        {
            _random = new Random();
            InitializeComponent();
            ButtonCloseMenu.Visibility = Visibility.Collapsed;

            DataContext = this;


            FunctionFrame.Content = _overview;
        }


        private void ButtonPopUpLogOut_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        #region Menu Open and Close Fuction
        /// <summary>
        /// Once the Menu is opened the function grid should be extended
        /// the open Button should be invisible
        /// and the close Button should come out.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOpenMenu_OnClick(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
            FunctionGrid.Width = FunctionGrid.Width - 110;
            _overview.Color = Brushes.Blue.ToString();
        }


        /// <summary>
        /// Once the Menu is hidden the function grid should be narrowed
        /// the Close Button should be invisible
        /// and the open Button should come out.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCloseMenu_OnClick(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            FunctionGrid.Width = FunctionGrid.Width + 110;
            _overview.Color = _random.NextDouble().ToString(CultureInfo.InvariantCulture);
        }
        #endregion



        #region Function Interface Jumping
        private void FunctionBranchSelector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedIndex = ((ListBox)sender).SelectedIndex;
            switch (selectedIndex)
            {
                case 0/*Overview*/:
                    if (Equals(FunctionFrame.Content, _overview))
                        break;
                    FunctionFrame.Content = null;
                    FunctionFrame.Content = _overview;
                    break;
                case 1/*Main Interface*/:
                    FunctionFrame.Content = null;
                    break;
                case 2/*Machining*/:
                    FunctionFrame.Content = null;
                    break;
                case 3/*Spraying*/:
                    FunctionFrame.Content = null;
                    FunctionFrame.Content = new Spraying();
                    break;
                case 4/*Producting Schedule*/:
                    FunctionFrame.Content = null;
                    break;
                default:
                    MessageBox.Show("wrong action");
                    break;
            }
        }

        private void LogSelector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedIndex = ((ListBox)sender).SelectedIndex;
            switch (selectedIndex)
            {
                case 0/*Dispatch Statistic*/:
                    FunctionFrame.Content = null;
                    break;
                case 1/*Vision Diary*/:
                    FunctionFrame.Content = null;
                    break;
                case 2/*Dispatch Diary*/:
                    FunctionFrame.Content = null;
                    break;
                case 3/*Alarm*/:
                    FunctionFrame.Content = null;
                    break;
                default:
                    MessageBox.Show("wrong action");
                    break;
            }
        }

        private void QueryMaintenanceNetworkSelector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedIndex = ((ListBox)sender).SelectedIndex;
            switch (selectedIndex)
            {
                case 0/*Queue Summary*/:
                    FunctionFrame.Content = null;
                    break;
                case 1/*Wheel Hub Maintenance*/:
                    FunctionFrame.Content = null;
                    break;
                case 2/*Network Structure*/:
                    FunctionFrame.Content = null;
                    break;
                default:
                    MessageBox.Show("wrong action");
                    break;
            }
        }
        #endregion


        #region Custom methods
        private void ChangebackLastPickedPanelBackground(StackPanel stackPanel)
        {
            if (_lastPickedPanel != null)
                _lastPickedPanel.Background = _menuBrush;
            _lastPickedPanel = stackPanel;
        }
        #endregion


    }
}