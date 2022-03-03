using ImageMagick;
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
        internal ProgramProperty ProgramProp = new ProgramProperty();
        internal EffectProperty EffectProp = new EffectProperty();
        internal SliceProperty SliceProp = new SliceProperty();

        private void UpdateEditor()
        {
            Editor.SelectedObject = null;
            Editor.SelectedObject = SliceProp;
        }

        private void LoadProperty()
        {
            Editor.SelectedObject = SliceProp;
            SliceProp.LinkEffectProp(ref EffectProp);
        }

        public MainWindow()
        {
            InitializeComponent();
            LoadProperty();
        }

        private void Menu_File_Open_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Menu_File_New_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Menu_File_Export_Package_Click(object sender, RoutedEventArgs e)
        {
            if (SliceProp.FilePath == "")
            {
                MessageBox.Show("您暂未选择切片文件，导出无法进行", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            StatusBar_Status.Text = "在导出期间，程序会在导出位置创建临时文件，请勿在导出期间打开、移动、删除或修改创建的临时文件和文件夹";
            if (SliceProp.Avalid != true)
            {
                if (MessageBox.Show("您给定的切片文件不满足数字切片的导出要求\n您可以点击确定继续导出\n但我们不能保证导出的文件能正常使用", "注意", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.Cancel)
                {
                    return;
                }
            }

            MessageBox.Show("导出即将开始，程序会执行耗时任务，卡死是正常现象\n点击确认键后将开始导出步骤", "提示", MessageBoxButton.OK, MessageBoxImage.Information);

            var x = new SaveFileDialog();
            x.Filter = "数字切片|*.*";
            x.FileName = SliceProp.SliceName;
            if (x.ShowDialog() != false)
            {
                FileInfo info = new FileInfo(x.FileName);
                Directory.CreateDirectory(info.FullName);
                SliceProp.slice.Pack(info.FullName);
                DirectoryInfo dir = new DirectoryInfo(info.FullName);
                FileSystemInfo[] files = dir.GetFileSystemInfos();
                foreach (FileSystemInfo file in files)
                {
                    file.Delete();
                }
                Directory.Delete(info.FullName);
                File.Move(String.Format($"{info.FullName}.zip"), String.Format($"{info.FullName}.slice"));
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
            SliceProp = new SliceProperty();
            ProgramProp = new ProgramProperty();
            EffectProp = new EffectProperty();
            Slice.Source = null;
            UpdateEditor();
            StatusBar_Status.Text = "已重置编辑器";
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
            ProgramProp.EnableLight = !ProgramProp.EnableLight;
            UpdateEditor();
            StatusBar_Status.Text = "请注意，此处预览使用的算法与实际模拟程序不同，预览仅供参考，请以实际模拟程序为准。";
        }

        private BitmapImage FromByte (byte[] bytes)
        {
            BitmapImage image = null;

            try
            {
                image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = new System.IO.MemoryStream(bytes);
                image.EndInit();
            }
            catch
            {
                image = null;
            }

            return image;
        }

        private void Toolbox_HalfDown_Click(object sender, RoutedEventArgs e)
        {
            if (ProgramProp.EnableLight)
            {
                if (SliceProp.FilePath != "")
                {
                    using (MagickImage image = new MagickImage(SliceProp.FilePath))
                    {
                        EffectProp.Brightness -= EffectProp.Brightness > 0 ? 10 : 0;
                        image.Modulate(new Percentage(EffectProp.Brightness));
                        Slice.Source = FromByte(image.ToByteArray());
                    }
                }
                else
                {
                    StatusBar_Status.Text = "You have not import slice source yet";
                }

                UpdateEditor();
            }
        }

        private void Toolbox_HalfUp_Click(object sender, RoutedEventArgs e)
        {
            if (ProgramProp.EnableLight)
            {
                if (SliceProp.FilePath != "")
                {
                    using (MagickImage image = new MagickImage(SliceProp.FilePath))
                    {
                        EffectProp.Brightness += EffectProp.Brightness < 200 ? 10 : 0;
                        image.Modulate(new Percentage(EffectProp.Brightness));
                        Slice.Source = FromByte(image.ToByteArray());
                    }
                }
                else
                {
                    StatusBar_Status.Text = "You have not import slice source yet";
                }

                UpdateEditor();
            }
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
            if (ProgramProp.EnableBlur)
            {
                EffectProp.BlurRadius -= 1;
                SliceBlur.Radius = EffectProp.BlurRadius >= 0 ? EffectProp.BlurRadius : -EffectProp.BlurRadius;

                UpdateEditor();
            }
        }

        private void Toolbox_LargeDown_Click(object sender, RoutedEventArgs e)
        {
            if (ProgramProp.EnableBlur)
            {
                EffectProp.BlurRadius -= 3;
                SliceBlur.Radius = EffectProp.BlurRadius >= 0 ? EffectProp.BlurRadius : -EffectProp.BlurRadius;

                UpdateEditor();
            }
        }

        private void Toolbox_LargeUp_Click(object sender, RoutedEventArgs e)
        {
            if (ProgramProp.EnableBlur)
            {
                EffectProp.BlurRadius += 3;
                SliceBlur.Radius = EffectProp.BlurRadius >= 0 ? EffectProp.BlurRadius : -EffectProp.BlurRadius;

                UpdateEditor();
            }
        }

        private void Toolbox_SmallUp_Click(object sender, RoutedEventArgs e)
        {
            if (ProgramProp.EnableBlur)
            {
                EffectProp.BlurRadius += 1;
                SliceBlur.Radius = EffectProp.BlurRadius >= 0 ? EffectProp.BlurRadius : -EffectProp.BlurRadius;

                UpdateEditor();
            }
        }

        private void Menu_Edit_Modify_Click(object sender, RoutedEventArgs e)
        {
            var x = new OpenFileDialog();
            x.Filter = "切片|*.png;*.jpg";
            if (x.ShowDialog() == true)
            {
                FileInfo info = new FileInfo(x.FileName);
                SliceProp.slice.FilePath = info.FullName;
                Uri uri = new Uri(info.FullName);
                BitmapImage bitmap = new BitmapImage(uri);
                Slice.Source = bitmap;
                SliceProp.LoadFile(bitmap, (int)System.Math.Ceiling(info.Length / 1024.0));

                UpdateEditor();
            } else
            {
                
            }
        }
    }
}
