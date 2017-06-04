using System;
using System.Windows.Forms;
using CustomForms.TableLayoutWrapperFields;
using DnDCharacterSheet;

namespace FormApp
{
    public partial class MainForm : Form
    {
        public MainFormProcessor MainFormProcessor { get; set; }

        public TableLayoutWrapper MainLayoutPanel { get { return mainLayout; } }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void mainLayout_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DoTheThing_Click(object sender, EventArgs e)
        {
            MainFormProcessor.DoTheThing_Click();
        }
    }
}
