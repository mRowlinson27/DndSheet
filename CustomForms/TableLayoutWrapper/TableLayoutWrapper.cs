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
            _layoutControlCollectionWrapper = new TableLayoutControlCollectionWrapper(this);
        }

        public new ITableLayoutControlCollectionWrapper Controls => _layoutControlCollectionWrapper;
    }
}
