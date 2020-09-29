using System;
using System.Runtime.InteropServices;

namespace fpDotNet
{
    /// <summary>
    /// interface to host a single .NET control
    /// </summary>
    ///<remarks>
    /// This is the interface that want to make visible to Visual FoxPro
    /// applications. COM requires an extra interface definition for every type
    /// that is used in a COM interface definition. VFP can be a bit
    /// picky about what types it works with.
    ///
    /// Therefore we define everything as type Object here. This helps Visual FoxPro
    /// to deal with the interface and minimizes the amount of class libraries we
    /// have to generate. VFP doesn't care, because it's not strongly typed anyway.
    ///
    /// The actual objects used will all be .NET objects that are packaged in
    /// a COM Callable Wrapper.
    /// </remarks>
    [ComVisible(true)]
    public interface IDotNetContainer
    {
        void SetControl(Object control);
        Object CreateBridge();
    }
}                                                       