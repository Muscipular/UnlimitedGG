using System;
using UGG.Core.Utilities.Platform;

#if WINDOWS
namespace UGG.Core.Platforms.Win
{
    class PlatformTool : IPlatformTool
    {
        public RendererType RendererType => RendererType.DX;

        public PlatformType PlatformType => PlatformType.Window;
    }
}
#endif