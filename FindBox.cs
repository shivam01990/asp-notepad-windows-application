using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NotepadPlus
{
    public partial class FindBox : Form
    {
        private System.Windows.Forms.Form formPad;
        public FindBox()
        {
            InitializeComponent();
        }
        public FindBox(ParentForm pad)
        {
            formPad = pad;
            InitializeComponent();
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void findNextButton_Click(object sender, EventArgs e)
        {
            ParentForm f1 = (ParentForm)(formPad);
            f1.FindNext(findWhatTextBox1.Text);
        }

        private void findWhatTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (findWhatTextBox1.Text == "")
                findNextButton.Enabled = false;
            else
                findNextButton.Enabled = true;
        }

        private void replaceButton_Click(object sender, EventArgs e)
        {
            ParentForm f2 = (ParentForm)(formPad);
            f2.FindNext(findWhatTextBox2.Text);
            f2.ReplaceNext(findWhatTextBox2.Text, replaceWithTextBox.Text);
        }

        private void replaceAllButton_Click(object sender, EventArgs e)
        {
            ParentForm f2 = (ParentForm)(formPad);
            f2.ReplaceAll(findWhatTextBox2.Text, replaceWithTextBox.Text);
        }

        private void findWhatTextBox2_TextChanged(object sender, EventArgs e)
        {
            bool bEnable = (findWhatTextBox2.Text == "") ? false : true;
            findNextButton2.Enabled = bEnable;
            replaceButton.Enabled = bEnable;
            replaceAllButton.Enabled = bEnable;
        }

        private void gotoButton_Click(object sender, EventArgs e)
        {
            try
            {
                int nLine = Int32.Parse(gotoTextBox.Text);
                ParentForm f2 = (ParentForm)(formPad);
                f2.Goto(nLine);
                f2.Activate();

            }
            catch (Exception er)
            {
                er.ToString();
            }
        }

       

       
    }
}
