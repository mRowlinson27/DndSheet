using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DnDCharacterSheet
{
    public partial class MainForm : Form
    {
        private MainFormProcessor _mainFormProcessor;
        public MainForm()
        {
            InitializeComponent();
            _mainFormProcessor = new MainFormProcessor();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void mainLayout_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DoTheThing_Click(object sender, EventArgs e)
        {
            _mainFormProcessor.DoTheThing_Click(middleLayoutPanel);
        }

        private void middleLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
