using System;
using System.Drawing;
using System.Windows.Forms;
using CustomForms.API;

namespace CustomForms.TableLayoutWrapper
{
    public class TableLayoutWrapper : TableLayoutPanel, ITableLayoutWrapper
    {
        private TableLayoutControlCollectionWrapper _layoutControlCollectionWrapper;
        public TableLayoutWrapper()
        {
            _layoutControlCollectionWrapper = new TableLayoutControlCollectionWrapper(Controls);
        }

        public ITableLayoutControlCollectionWrapper Controller => _layoutControlCollectionWrapper;

        public Control TrueControl => this;
    }
}
