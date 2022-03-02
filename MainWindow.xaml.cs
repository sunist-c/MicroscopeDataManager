using MicroscopeDataManager.Libs;
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

namespace MicroscopeDataManager
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

        private void Menu_File_Open_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Menu_File_New_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Menu_File_Export_Package_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Menu_File_Export_Xml_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Menu_File_Export_Slice_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Menu_File_Import_Xml_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Menu_File_Import_Slice_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Menu_Edit_Undo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Menu_Edit_Reset_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Menu_Edit_Copy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Menu_Edit_Paste_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Menu_Setting_About_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Menu_Setting_Update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Menu_Setting_License_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Menu_Setting_Prefrence_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Menu_Setting_Exit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Menu_Setting_Register_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Toolbox_Light_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Toolbox_HalfDown_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Toolbox_HalfUp_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Toolbox_PreviewOn_Click(object sender, RoutedEventArgs e)
        {
            Slice.Visibility = Visibility.Visible;
        }

        private void Toolbox_PreviewOff_Click(object sender, RoutedEventArgs e)
        {
            Slice.Visibility = Visibility.Hidden;
        }

        private void Toolbox_ZoomIn_Click(object sender, RoutedEventArgs e)
        {
            if (Slice_Magnifier.Scale < 10)
            {
                Slice_Magnifier.Scale = 10;
            } else if (Slice_Magnifier.Scale < 40)
            {
                Slice_Magnifier.Scale = 40;
            }
        }

        private void Toolbox_ZoomOut_Click(object sender, RoutedEventArgs e)
        {
            if (Slice_Magnifier.Scale > 10)
            {
                Slice_Magnifier.Scale = 10;
            } else if (Slice_Magnifier.Scale > 4)
            {
                Slice_Magnifier.Scale = 4;
            }
        }

        private void Toolbox_SmallDown_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Toolbox_LargeDown_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Toolbox_LargeUp_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Toolbox_SmallUp_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
