using System;
using CefSharp;

namespace fpDotNet.fpCefSharp
{
    public class fpCallback
    {
        /// <summary>
        /// Instance of a cefSharpBroweser class from cefSharpBroweser.prg.
        /// Each instance is bound to once IBrowser instance.
        /// </summary>
        readonly dynamic VfpHandler;

        public fpCallback(Object callback)
        {
            if (callback == null) 
                throw new ArgumentNullException(nameof(callback));

            VfpHandler = callback;
        }

        public void OnProcessRequest(ResourceHandler resourceHandler, IRequest request)
        {
            VfpHandler.OnProcessRequest(resourceHandler, request);
        }
    }
}