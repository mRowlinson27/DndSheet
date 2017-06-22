using System;

namespace CustomFormStructures.API
{
    public interface INativeMethods
    {
        bool CallLockWindowUpdate(IntPtr hWnd);
        IntPtr CallSendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
    }
}
