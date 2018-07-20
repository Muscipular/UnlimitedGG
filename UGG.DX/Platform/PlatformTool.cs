using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGG.Core.Utilities.Platform;

namespace UGG.DX.Platform
{
    class PlatformTool : IPlatformTool
    {
        public RendererType RendererType => RendererType.DX;

        public PlatformType PlatformType => PlatformType.Window;
    }
}