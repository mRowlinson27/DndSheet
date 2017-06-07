using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomForms.API
{
    public interface INativeMethods
    {
        bool CallLockWindowUpdate(IntPtr hWnd);
        IntPtr CallSendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
    }
}
