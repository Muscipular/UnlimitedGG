using System;
using System.Collections.Generic;
using System.Text;

namespace UGG.Core.Utilities.Platform
{
    internal enum RendererType
    {
        GL,

        DX
    }

    internal enum PlatformType
    {
        Window,

        OSX
    }

    internal interface IPlatformTool
    {
        RendererType RendererType { get; }

        PlatformType PlatformType { get; }
    }
}