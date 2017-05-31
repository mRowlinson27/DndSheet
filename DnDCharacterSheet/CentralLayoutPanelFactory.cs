using System.Drawing;
using System.Windows.Forms;

namespace DnDCharacterSheet
{
    public class CentralLayoutPanelFactory : ICentralLayoutPanelFactory
    {
        public TableLayoutPanel Create()
        {
            var middleLayoutPanel = new TableLayoutPanel();
            middleLayoutPanel.BackColor = Color.Beige;
            middleLayoutPanel.Dock = DockStyle.Fill;
            middleLayoutPanel.HorizontalScroll.Maximum = 0;
            middleLayoutPanel.AutoScroll = false;
            middleLayoutPanel.VerticalScroll.Visible = false;
            middleLayoutPanel.AutoScroll = true;
            middleLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            middleLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            middleLayoutPanel.ColumnCount = middleLayoutPanel.ColumnStyles.Count;
            middleLayoutPanel.Margin = new Padding(20);
            return middleLayoutPanel;
        }
    }
}