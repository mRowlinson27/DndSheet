using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomForms.API;

namespace CustomForms
{
    public class Win32Adapter : IWin32Adapter
    {
        private INativeMethods _nativeMethods;
        public Win32Adapter(INativeMethods nativeMethods)
        {
            _nativeMethods = nativeMethods;
        }

        public bool LockWindowUpdate(IntPtr hWnd)
        {
            return _nativeMethods.CallLockWindowUpdate(hWnd);
        }

        public IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp)
        {
            return _nativeMethods.CallSendMessage(hWnd, msg, wp, lp);
        }
    }
}
