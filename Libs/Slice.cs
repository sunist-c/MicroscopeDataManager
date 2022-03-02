﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MicroscopeDataManager.Libs
{
    public class Slice
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string Author { get; set; } = "TestAuthor";
        public string Version { get; set; } = "";
        public string FilePath { get; set; } = "";
        public string Thumbnail { get; set; } = "";

        public void GenerateVersion()
        {
            string date = DateTime.Now.ToString("yyyyMMdd");
            string time = Convert.ToInt32(DateTime.Now.ToString("hhmmss")).ToString("X4");
            Version = string.Format($"{date}.{time}");
        }

        public void Pack(string outputPath)
        {
            PackXml(outputPath);
            PackImage(outputPath);
        }

        public void PackXml(string outputPath)
        {
            using (StreamWriter writer = new StreamWriter(Path.Combine(outputPath, "info.xml")))
            {
                System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Slice));
                xmlSerializer.Serialize(writer, this);
            }
        }

        public void PackImage(string outputPath)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = "compress.exe";
            process.StartInfo.Arguments = String.Format($"-i {FilePath} -o {outputPath} -s 256 --srcname slice --outname thumbnail");
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            process.WaitForExit();
            MessageBox.Show("Exported!");
        }
    }
}
