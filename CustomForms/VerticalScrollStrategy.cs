using System;
using System.Drawing;
using System.Windows.Forms;
using CustomForms.API;
using CustomForms.API.TableLayoutWrapper;

namespace CustomForms
{
    public class VerticalScrollStrategy : IVerticalScrollStrategy
    {
        private ITableLayoutWrapper _control = null;
        private IWin32Adapter _win32Adapter;
        public VerticalScrollStrategy(IWin32Adapter win32Adapter)
        {
            _win32Adapter = win32Adapter;
            Application.AddMessageFilter(this);
        }

        public ITableLayoutWrapper ExecuteOn(ITableLayoutWrapper input)
        {
            return ApplyChanges(input);
        }

        private ITableLayoutWrapper ApplyChanges(ITableLayoutWrapper input)
        {
            if (_control == null)
            {
                _control = input;
                input.AutoScroll = false;
                input.AccessHorizontalScroll.Maximum = 0;
                input.AccessVerticalScroll.Visible = false;
                input.AccessHorizontalScroll.Visible = false;
                input.AutoScroll = true;
                input.Scroll += Input_Scroll;
            }
            return input;
        }

        private void Input_Scroll(object sender, ScrollEventArgs e)
        {
            //This needs to be elevated methinks
            if (e.Type == ScrollEventType.First)
            {
                _win32Adapter.LockWindowUpdate(_control.Handle);
            }
            else
            {
                _win32Adapter.LockWindowUpdate(IntPtr.Zero);
                _control.Update();
                if (e.Type != ScrollEventType.Last) _win32Adapter.LockWindowUpdate(_control.Handle);
            }
        }

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == 0x20a && _control != null)
            {
                IntPtr hWnd = _control.Handle;
                if (hWnd != IntPtr.Zero && hWnd != m.HWnd && Control.FromHandle(hWnd) != null)
                {
                    _win32Adapter.SendMessage(hWnd, m.Msg, m.WParam, m.LParam);
                    return true;
                }
            }
            return false;
        }
    }
}
