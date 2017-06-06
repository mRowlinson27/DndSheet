using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CustomForms.API;

namespace CustomForms
{
    public class NativeMethods : INativeMethods
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool LockWindowUpdate(IntPtr hWnd);

        public bool CallLockWindowUpdate(IntPtr hWnd)
        {
            return LockWindowUpdate(hWnd);
        }
    }
}
