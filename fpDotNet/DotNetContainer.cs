using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;
using Westwind.WebConnection;

namespace fpDotNet
{
    [ClassInterface(ClassInterfaceType.None)]
    [ComVisible(true)]
    [Guid("AD735B97-BA14-49A3-B326-34D8F1058B73")]
    public partial class DotNetContainer : UserControl, IDotNetContainer
    {
        public DotNetContainer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This container hosts any WinForm control.
        /// </summary>
        /// <param name="control">Reference to the WinForm control</param>
        public void SetControl(Object control)
        {
            var uiControl = (Control) control;
            Controls.Clear();
            Controls.Add(uiControl);
            uiControl.Dock = DockStyle.Fill;
            uiControl.Visible = true;        
        }

        /// <summary>
        /// Returns a reference to an wwDotNetBridge instance. This instance is used
        /// instead of one create in ClrHost.dll, because COM InterOp runs in its own
        /// AppDomain in VFP. We make sure we create all controls in the AppDomain
        /// that contains the WinForm container.
        /// </summary>
        /// <returns>Store the wwDotNetBridge instance in the oDotNetBridge property</returns>
        public Object CreateBridge()
        {
            var bridge = new wwDotNetBridge();
            return bridge;
        }

        /// <summary>
        /// VFP won't add a COM object to a form unless it has a Control key. 
        /// </summary>
        /// <param name="keyName"></param>
        [ComRegisterFunction]
        public static void RegisterClass(string keyName)
        {
            using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(keyName.Replace(@"HKEY_CLASSES_ROOT\", ""), true))
                key?.CreateSubKey("Control")?.Close();
        }

        [ComUnregisterFunction]
        public static void UnregisterClass(string keyName)
        {
            using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(keyName.Replace(@"HKEY_CLASSES_ROOT\", ""), true))
                key?.DeleteSubKey("Control", false);
        }
    }
}
