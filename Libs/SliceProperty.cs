using System;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MicroscopeDataManager.Libs
{
    public class SliceProperty
    {
        internal Slice slice = new Slice();

        [Category("BasicAtribute")]
        public string SliceName { get => slice.Name; set => slice.Name = value; }

        [Category("BasicAtribute")]
        public string SliceDescription { get => slice.Description; set => slice.Description = value; }

        [Category("BasicAtribute")]
        public string Author { get => slice.Author; }

        [Category("BasicAtribute")]
        public string Version { get => slice.Version; }

        [Category("MediaAtribute")]
        public int SliceHeight { get; internal set; }

        [Category("MediaAtribute")]
        public int SliceWidth { get; internal set; }

        [Category("MediaAtribute")]
        public string FilePath { get; internal set; } = "";

        [Category("MediaAtribute")]
        public string FileSize { get; internal set; } = "0 KB";

        [Category("MediaAtribute")]
        public bool Avalid { get; internal set; }

        internal void LoadFile(BitmapImage image, int size)
        {
            FilePath = slice.FilePath;
            SliceWidth = image.PixelWidth;
            SliceHeight = image.PixelHeight;
            FileSize = String.Format($"{size} KB");
            Avalid = SliceWidth > 500 && SliceHeight > 500;
        }

        public SliceProperty()
        {
            slice.GenerateVersion();
        }
    }
}
