using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroscopeDataManager.Libs
{
    internal class ProgramProperty
    {
        internal bool EnablePreview { get; set; } = true;
        internal bool EnableBlur { get; set; } = true;
        internal bool EnableLight { get; set; } = false;
        internal int DefaultScaleFactor { get; set; } = 4;
        internal int DefaultThumbnailSize { get; set; } = 256;
        
    }
}
