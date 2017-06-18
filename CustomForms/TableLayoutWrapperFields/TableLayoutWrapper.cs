using System.Windows.Forms;
using CustomForms.API;
using CustomForms.API.DTOs;
using CustomForms.API.TableLayoutWrapper;

namespace CustomForms.TableLayoutWrapperFields
{
    public class TableLayoutWrapper : TableLayoutPanel, ITableLayoutWrapper
    {
        private TableLayoutControlCollectionWrapper _layoutControlCollectionWrapper;
        private TableLayoutRowStyleCollectionWrapper _layoutRowStyleCollectionWrapper;
        private TableLayoutColumnStyleCollectionWrapper _layoutColumnStyleCollectionWrapper;
        private HScrollPropertiesWrapper _hScrollPropertiesWrapper;
        private VScrollPropertiesWrapper _vScrollPropertiesWrapper;
        public TableLayoutWrapper()
        {
            _layoutControlCollectionWrapper = new TableLayoutControlCollectionWrapper(Controls);
            _layoutRowStyleCollectionWrapper = new TableLayoutRowStyleCollectionWrapper(RowStyles);
            _layoutColumnStyleCollectionWrapper = new TableLayoutColumnStyleCollectionWrapper(ColumnStyles);
            _hScrollPropertiesWrapper = new HScrollPropertiesWrapper(HorizontalScroll);
            _vScrollPropertiesWrapper = new VScrollPropertiesWrapper(VerticalScroll);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_EX_COMPOSITED = 0x02000000;
                var cp = base.CreateParams;
                cp.ExStyle |= WS_EX_COMPOSITED;
                return cp;
            }
        }

        public ITableLayoutControlCollectionWrapper AccessControls => _layoutControlCollectionWrapper;
        public ITableLayoutRowStyleCollectionWrapper AccessRowStyles => _layoutRowStyleCollectionWrapper;
        public ITableLayoutColumnStyleCollectionWrapper AccessColumnStyles => _layoutColumnStyleCollectionWrapper;
        public IHScrollPropertiesWrapper AccessHorizontalScroll => _hScrollPropertiesWrapper;
        public IVScrollPropertiesWrapper AccessVerticalScroll => _vScrollPropertiesWrapper;

        public Control TrueControl => this;
        public IControl RemoveAllEvents()
        {
            throw new System.NotImplementedException();
        }
    }
}
