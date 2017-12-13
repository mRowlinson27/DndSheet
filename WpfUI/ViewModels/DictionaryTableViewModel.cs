namespace WpfUI.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using Controls;
    using Dtos;
    using Helpers;

    public class Hack
    {
        public List<bool> Bools { get; set; }
        public List<string> Strings { get; set; } 
    }

    public class DictionaryTableViewModel : ViewModelBase
    {
        private readonly IDictionaryTableViewModelHelper _dictionaryTableViewModelHelper;

        public DictionaryTableView DictionaryTableView { get; set; }

        private DataTemplate _dataGridTemplate;
        public DataTemplate DataGridTemplateBinding
        {
            get
            {
                if (_dataGridTemplate == null)
                {
                    _dataGridTemplate = CreateDataGridTemplate();
                }
                return _dataGridTemplate;
            }
        }

        private DataTemplate CreateDataGridTemplate()
        {
            var dataGridTemplate = new DataTemplate();
            dataGridTemplate.DataType = typeof (DataTable);

            //set up the stack panel
            var spFactory = new FrameworkElementFactory(typeof (StackPanel));
            spFactory.Name = "myComboFactory";
            spFactory.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);

            var cardHolder = new FrameworkElementFactory(typeof (TextBlock));
            cardHolder.SetBinding(TextBlock.TextProperty, new Binding("DataGridBinding.Rows[0]"));
            //cardHolder.SetValue(TextBlock.ToolTipProperty, "Card Holder Name");
            spFactory.AppendChild(cardHolder);
            var cardHolder2 = new FrameworkElementFactory(typeof (TextBlock));
            cardHolder2.SetBinding(TextBlock.TextProperty, new Binding("DataGridBinding.Rows[1]"));
            spFactory.AppendChild(cardHolder2);

            dataGridTemplate.VisualTree = spFactory;

            return dataGridTemplate;
        }

        private DataTable _dataGridBinding;
        public DataTable DataGridBinding
        {
            get
            {
                if (_dataGridBinding == null)
                {
                    _dataGridBinding = _dictionaryTableViewModelHelper.GetSource();
                }

                return _dataGridBinding;
                var dataTable = new DataTable();
                dataTable.Columns.Add("abc");
                dataTable.Columns.Add("qrt");
                dataTable.Columns.Add("xyz");
                dataTable.Rows.Add(true, 6, "");
                dataTable.Rows.Add(2, 7, 12);
                dataTable.Rows.Add(3, 8, 13);
                dataTable.Rows.Add(4, 9, "wfieuhwiefuh");
                dataTable.Rows.Add(5, true, 15);
                return dataTable;
                
            }
        }

        private ObservableCollection<Hack> _dataGridBinding1;

        public ObservableCollection<Hack> DataGridBinding1
        {
            get
            {
                if (_dataGridBinding1 == null)
                {
                    _dataGridBinding1 = new ObservableCollection<Hack> { new Hack() { Bools = new List<bool> { true, false }, Strings = new List<string> { "hi", "bi" } } };
                }
                return _dataGridBinding1;
            }
        }

        public DictionaryTableViewModel(IDictionaryTableViewModelHelper dictionaryTableViewModelHelper)
        {
            _dictionaryTableViewModelHelper = dictionaryTableViewModelHelper;
        }

        public void ApplyBindings()
        {return;
            var textCol = new DataGridCheckBoxColumn();
            textCol.Binding = new Binding("Bools[0]");
            textCol.Header = "DataGridBinding1";
            DictionaryTableView.DataGrid.Columns.Add(textCol);
        }
    }
}
