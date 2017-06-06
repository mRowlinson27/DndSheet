using System;
using System.Windows.Forms;
using CustomForms.API;
using CustomForms.API.TableLayoutWrapper;

namespace CustomForms
{
    public class VerticalScrollStrategy : IVerticalScrollStrategy
    {
        private IControl _control = null;
        private IWin32Adapter _win32Adapter;
        public VerticalScrollStrategy(IWin32Adapter win32Adapter)
        {
            _win32Adapter = win32Adapter;
        }

        public ITableLayoutWrapper ExecuteOn(ITableLayoutWrapper input)
        {
            return ApplyChanges(input);
        }

        private ITableLayoutWrapper ApplyChanges(ITableLayoutWrapper input)
        {
            if (_control == null)
            {
                input.AutoScroll = false;
                input.AccessHorizontalScroll.Maximum = 0;
                input.AccessVerticalScroll.Visible = false;
                input.AccessHorizontalScroll.Visible = false;
                input.AutoScroll = true;
                input.Scroll += Input_Scroll;
                input.MouseEnter += delegate(object sender, EventArgs args) { input.Focus(); };
                _control = input;
            }
            return input;
        }

        private void Input_Scroll(object sender, ScrollEventArgs e)
        {
            //This needs to be elevated methinks
            var send = sender as ITableLayoutWrapper;
            if (e.Type == ScrollEventType.First)
            {
                _win32Adapter.LockWindowUpdate(send.Handle);
            }
            else
            {
                _win32Adapter.LockWindowUpdate(IntPtr.Zero);
                send.Update();
                if (e.Type != ScrollEventType.Last) _win32Adapter.LockWindowUpdate(send.Handle);
            }
        }
    }
}
