using MicroscopeDataManager.Libs;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace MicroscopeDataManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal SliceProperty property = new SliceProperty();

        public MainWindow()
        {
            InitializeComponent();
            Editor.SelectedObject = property;
        }

        private void Menu_File_Open_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Menu_File_New_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Menu_File_Export_Package_Click(object sender, RoutedEventArgs e)
        {
            var x = new SaveFileDialog();
            if (x.ShowDialog() != false)
            {
                FileInfo info = new FileInfo(x.FileName);
                property.slice.Pack(info.DirectoryName);
            }
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

        private void Menu_Edit_Modify_Click(object sender, RoutedEventArgs e)
        {
            var x = new OpenFileDialog();
            x.Filter = "切片|*.png;*.jpg";
            if (x.ShowDialog() == true)
            {
                FileInfo info = new FileInfo(x.FileName);
                property.slice.FilePath = info.FullName;
                Uri uri = new Uri(info.FullName);
                BitmapImage bitmap = new BitmapImage(uri);
                Slice.Source = bitmap;
                property.LoadFile(bitmap, (int)System.Math.Ceiling(info.Length / 1024.0));

                Editor.SelectedObject = null;
                Editor.SelectedObject = property;
            } else
            {
                
            }
        }

        private void Editor_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            MessageBox.Show("Changed");
        }
    }
}
