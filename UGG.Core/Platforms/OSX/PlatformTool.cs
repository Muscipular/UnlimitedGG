using System;
using UGG.Core.Utilities.Platform;

#if WINDOWS
namespace UGG.Core.Platforms
{
    class PlatformTool : IPlatformTool
    {
        public RendererType RendererType => RendererType.DX;

        public PlatformType PlatformType => PlatformType.Window;
    }
}
#endif