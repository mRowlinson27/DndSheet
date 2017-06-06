using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomForms.API
{
    public interface IWin32Adapter
    {
        bool LockWindowUpdate(IntPtr hWnd);
    }
}
