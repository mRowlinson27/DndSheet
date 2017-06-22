using System;

namespace CustomFormStructures.API
{
    public interface IWin32Adapter
    {
        bool LockWindowUpdate(IntPtr hWnd);
        IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
    }
}
