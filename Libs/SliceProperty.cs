using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MicroscopeDataManager.Libs
{
    public class SliceProperty
    {
        public string Name { get; set; } = "name";
        public string Author { get; set; } = "author";
        public string Description { get; set; } = "description";
        public string Version { get; set; } = "version";
        public string FilePath { get; set; } = "filepath";
        public string Thumbnail { get; set; } = "thumbnail";

        public bool Pack(string outputPath)
        {
            try
            {
                // pack xml file
                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(SliceProperty));
                    xmlSerializer.Serialize(writer, this);
                }

                // pack image
                
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            return true;
        }
    }
}
