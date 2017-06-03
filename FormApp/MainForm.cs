using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomForms.TableLayoutWrapper;

namespace DnDCharacterSheet
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
