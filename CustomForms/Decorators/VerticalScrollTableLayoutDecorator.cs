using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CustomForms.API;
using CustomForms.API.Decorators;
using CustomForms.API.DTOs;
using CustomForms.API.TableLayoutWrapper;

namespace CustomForms.Decorators
{
    public class VerticalScrollTableLayoutDecorator : ITableLayoutDecorator
    {
        public ITableLayoutWrapper Create(ITableLayoutDecoratorArguments args)
        {
            var input = new TableLayoutWrapperFields.TableLayoutWrapper();
            return ApplyChanges(input);
        }

        public ITableLayoutWrapper Apply(ITableLayoutWrapper input, ITableLayoutDecoratorArguments args)
        {
            return ApplyChanges(input);
        }

        private ITableLayoutWrapper ApplyChanges(ITableLayoutWrapper input)
        {
            input.AutoScroll = false;
            input.AccessHorizontalScroll.Maximum = 0;
            input.AccessVerticalScroll.Visible = false;
            input.AccessHorizontalScroll.Visible = false;
            input.AutoScroll = true;
            input.Scroll += panel1_Scroll;
            return input;
        }

        private void panel1_Scroll(object sender, ScrollEventArgs e)
        {
            var send = sender as ITableLayoutWrapper;
            if (e.Type == ScrollEventType.First)
            {
                LockWindowUpdate(send.TrueControl.Handle);
            }
            else
            {
                LockWindowUpdate(IntPtr.Zero);
                send.TrueControl.Update();
                if (e.Type != ScrollEventType.Last) LockWindowUpdate(send.TrueControl.Handle);
            }
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool LockWindowUpdate(IntPtr hWnd);
    }
}
