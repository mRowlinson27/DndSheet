using System;
using System.Runtime.InteropServices;
using CustomFormManipulation.API;
using CustomForms.API;

namespace CustomFormManipulation
{
    public class NativeMethods : INativeMethods
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool LockWindowUpdate(IntPtr hWnd);

        public bool CallLockWindowUpdate(IntPtr hWnd)
        {
            return LockWindowUpdate(hWnd);
        }

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        public IntPtr CallSendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp)
        {
            return SendMessage(hWnd, msg, wp, lp);
        }
    }
}
