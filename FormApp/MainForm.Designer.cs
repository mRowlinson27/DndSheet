﻿using CustomForms.TableLayoutWrapperFields;

namespace FormApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dndIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.iconContextStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.doTheThing = new System.Windows.Forms.ToolStripMenuItem();
            this.mainLayout = new CustomForms.TableLayoutWrapperFields.TableLayoutWrapper();
            this.iconContextStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dndIcon
            // 
            this.dndIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.dndIcon.BalloonTipText = "grdft";
            this.dndIcon.BalloonTipTitle = "fsgr";
            this.dndIcon.ContextMenuStrip = this.iconContextStrip;
            this.dndIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("dndIcon.Icon")));
            this.dndIcon.Text = "DnD";
            this.dndIcon.Visible = true;
            // 
            // iconContextStrip
            // 
            this.iconContextStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.doTheThing});
            this.iconContextStrip.Name = "iconContextStrip";
            this.iconContextStrip.Size = new System.Drawing.Size(144, 26);
            // 
            // doTheThing
            // 
            this.doTheThing.Name = "doTheThing";
            this.doTheThing.Size = new System.Drawing.Size(143, 22);
            this.doTheThing.Text = "Do the Thing";
            this.doTheThing.Click += new System.EventHandler(this.DoTheThing_Click);
            // 
            // mainLayout
            // 
            this.mainLayout.AutoScroll = true;
            this.mainLayout.BackColor = System.Drawing.SystemColors.ControlDark;
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 2;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.mainLayout.Size = new System.Drawing.Size(704, 372);
            this.mainLayout.TabIndex = 0;
            this.mainLayout.Paint += new System.Windows.Forms.PaintEventHandler(this.mainLayout_Paint);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(704, 372);
            this.Controls.Add(this.mainLayout);
            this.MinimumSize = new System.Drawing.Size(720, 410);
            this.Name = "MainForm";
            this.Text = "DnD CharacterSheet";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.iconContextStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon dndIcon;
        private System.Windows.Forms.ContextMenuStrip iconContextStrip;
        private System.Windows.Forms.ToolStripMenuItem doTheThing;
        private TableLayoutWrapper mainLayout;
    }
}

