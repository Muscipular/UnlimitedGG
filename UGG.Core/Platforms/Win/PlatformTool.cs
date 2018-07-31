using System;
using UGG.Core.Utilities.Platform;

#if __MACOS__
namespace UGG.Core.Platforms
{
    class PlatformTool : IPlatformTool
    {
        public RendererType RendererType => RendererType.GL;

        public PlatformType PlatformType => PlatformType.OSX;
    }
}
#endif