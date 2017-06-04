using System.Windows.Forms;
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

        public ITableLayoutControlCollectionWrapper AccessControls => _layoutControlCollectionWrapper;
        public ITableLayoutRowStyleCollectionWrapper AccessRowStyles => _layoutRowStyleCollectionWrapper;
        public ITableLayoutColumnStyleCollectionWrapper AccessColumnStyles => _layoutColumnStyleCollectionWrapper;
        public IHScrollPropertiesWrapper AccessHorizontalScroll => _hScrollPropertiesWrapper;
        public IVScrollPropertiesWrapper AccessVerticalScroll => _vScrollPropertiesWrapper;

        public Control TrueControl => this;
    }
}
