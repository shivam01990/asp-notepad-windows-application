using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace NotepadPlus
{
    public partial class ChildForm : Form
    {
        public ChildForm()
        {
            InitializeComponent();
        }
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox1.Undo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox1.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (RichTextBox1.SelectionLength == 0)
                RichTextBox1.SelectionLength = 1;
            RichTextBox1.SelectedText = "";
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox1.SelectAll();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            DialogResult dr;
            dr = fd.ShowDialog();
            if (dr == DialogResult.Cancel)
                return;
            try
            {
                RichTextBox1.Font = fd.Font;
                Font DocFont = fd.Font;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bulletsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RichTextBox1.SelectionBullet = !(RichTextBox1.SelectionBullet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChildForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (RichTextBox1.Text != "")
            {


                DialogResult reply = MessageBox.Show("Do you want to save changes ?",
                 "Save File", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (reply == DialogResult.Yes)
                {

                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Title = "Save a Text File";
                    sfd.Filter = "Text File (*.txt)|*.txt|All Files (*.*)|*.*";
                    string fn;
                    StreamWriter sw;
                    DialogResult dr;
                    sfd.FileName = this.Text;
                    dr = sfd.ShowDialog();
                    fn = sfd.FileName.Trim();
                    if ((dr == DialogResult.Cancel))
                    {
                        e.Cancel = true;
                    }
                    this.Tag = fn;
                    this.Text = fn;
                    sw = new StreamWriter(fn);
                    sw.Write(RichTextBox1.Text);
                    sw.Close();
                    Program.pf.openDoc = Program.pf.openDoc - 1;
                }
                if (reply == DialogResult.No)
                {
                    Program.pf.openDoc = Program.pf.openDoc - 1;
                }
                if (reply == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
            else
            {
                Program.pf.openDoc = Program.pf.openDoc - 1;
            }




        }
    }
}
