using System;
using System.ComponentModel;
using System.Windows.Media.Imaging;

namespace MicroscopeDataManager.Libs
{
    public class SliceProperty
    {
        internal Slice slice = new Slice();
        internal EffectProperty effect = new EffectProperty();

        [Category("切片基础信息")]
        public string SliceName { get => slice.Name; set => slice.Name = value; }

        [Category("切片基础信息")]
        public string SliceDescription { get => slice.Description; set => slice.Description = value; }

        [Category("切片基础信息")]
        public string Author { get => slice.Author; }

        [Category("切片基础信息")]
        public string Version { get => slice.Version; }

        [Category("切片媒体信息")]
        public int SliceHeight { get; internal set; }

        [Category("切片媒体信息")]
        public int SliceWidth { get; internal set; }

        [Category("切片媒体信息")]
        public string FilePath { get; internal set; } = "";

        [Category("切片媒体信息")]
        public string FileSize { get; internal set; } = "0 KB";

        [Category("切片媒体信息")]
        public bool Avalid { get; internal set; }

        [Category("切片效果参数")]
        public double BlurFactor { get => ((20 - ((effect.BlurRadius < 0) ? -effect.BlurRadius : effect.BlurRadius)) * 5); }

        [Category("切片效果参数")]
        public int BrightnessFactor { get => effect.Brightness; }

        internal void LoadFile(BitmapImage image, int size)
        {
            FilePath = slice.FilePath;
            SliceWidth = image.PixelWidth;
            SliceHeight = image.PixelHeight;
            FileSize = String.Format($"{size} KB");
            Avalid = SliceWidth > 500 && SliceHeight > 500;
        }

        internal void LinkEffectProp(ref EffectProperty effect)
        {
            this.effect = effect;
        }

        internal SliceProperty()
        {
            slice.GenerateVersion();
        }
    }
}
