using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;

namespace NotepadPlus
{
    public partial class ParentForm : Form
    {
        ChildForm child = new ChildForm();
        StringReader myReader;
        Font DocFont;
        Color BackgroundColor = new Color();
        Color ForegroundColor = new Color();
        int m_nFilePointerPosition = 0;


        internal int openDoc;
        public static int i;
        private int childFormNumber = 0;

        private Brush[] m_brushes = new Brush[] { Brushes.White, Brushes.Black, Brushes.Blue, Brushes.Green,
													Brushes.Red, Brushes.Yellow };

        private Color[] m_colors = new Color[] { Color.White, Color.Black, Color.Blue, Color.Green,
												   Color.Red, Color.Yellow };

        private string[] m_colornames = new string[] { "White", "Black", "Blue", "Green",
														 "Red", "Yellow" };

        public ParentForm()
        {
            InitializeComponent();
            foreach (System.Drawing.FontFamily ff in System.Drawing.FontFamily.Families)
            {
                if (ff.Name.Equals("Verdana"))

                    fontTypeToolStripComboBox.SelectedIndex = fontTypeToolStripComboBox.Items.Add(ff.Name);
                else
                    fontTypeToolStripComboBox.Items.Add(ff.Name);
            }

            fontSizeToolStripComboBox.SelectedIndex = 3;

            foregroundColorToolStripComboBox.Items.AddRange(m_colornames);
            backgroundColorToolStripComboBox.Items.AddRange(m_colornames);

            foregroundColorToolStripComboBox.SelectedIndex = 1;
            backgroundColorToolStripComboBox.SelectedIndex = 0;
        }
        public void FindNext(string str)
        {
            try
            {
                Form activeChildForm = this.ActiveMdiChild;

                if (activeChildForm != null)
                {

                    RichTextBox activeTextBox = (RichTextBox)activeChildForm.ActiveControl;
                    if (activeTextBox != null)
                    {
                        int nStart = activeTextBox.Text.IndexOf(str, m_nFilePointerPosition);
                        int nLength = str.Length;

                        activeTextBox.Select(nStart, nLength);
                        activeTextBox.Focus();
                        m_nFilePointerPosition = nStart + nLength;
                    }
                }

            }
            catch (Exception e)
            {
                e.ToString();
                MessageBox.Show("Reached End of Document.");
                m_nFilePointerPosition = 0;
            }
        }
        public void ReplaceNext(string str, string strReplace)
        {
            try
            {
                Form activeChildForm = this.ActiveMdiChild;

                if (activeChildForm != null)
                {

                    RichTextBox activeTextBox = (RichTextBox)activeChildForm.ActiveControl;
                    if (activeTextBox != null)
                    {
                        int nStart = activeTextBox.Text.IndexOf(str, 0);
                        int nLength = str.Length;

                        activeTextBox.Text = activeTextBox.Text.Remove(nStart, nLength);
                        activeTextBox.Text = activeTextBox.Text.Insert(nStart, strReplace);
                        activeTextBox.Focus();

                    }
                }
            }
            catch (Exception e)
            {
                e.ToString();
                MessageBox.Show("Reached End of Document.");
                m_nFilePointerPosition = 0;
            }
        }

        public void ReplaceAll(string str, string strReplace)
        {
            try
            {
                Form activeChildForm = this.ActiveMdiChild;

                if (activeChildForm != null)
                {

                    RichTextBox activeTextBox = (RichTextBox)activeChildForm.ActiveControl;
                    if (activeTextBox != null)
                    {
                        int nStart = activeTextBox.Text.IndexOf(str, m_nFilePointerPosition);
                        int nLength = str.Length;

                        activeTextBox.Select(nStart, nLength);
                        activeTextBox.Text = activeTextBox.Text.Replace(str, strReplace);
                        activeTextBox.Focus();
                        m_nFilePointerPosition = nStart + nLength;

                    }
                }
            }
            catch (Exception e)
            {
                e.ToString();
                MessageBox.Show("Reached End of Document.");
                m_nFilePointerPosition = 0;
            }
        }

        public void Goto(int nLine)
        {
            m_nFilePointerPosition = 0;
            for (int i = 1; i <= nLine; i++)
                FindNext("\n");
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            // Create a new instance of the child form.
            ChildForm childForm = new ChildForm();
            // Make it a child of this MDI form before showing it.
            childFormNumber++;
            childForm.MdiParent = this;
            childForm.Text = "Untitled " + childFormNumber;
            childForm.RichTextBox1.Multiline = true;
            childForm.RichTextBox1.Dock = DockStyle.Fill;
            childForm.Show();
            openDoc++;
            windowsCountStatusLabel.Text = ("Windows Count: " + this.MdiChildren.Length);

            newToolStripMenuItem.Enabled = true;
            openToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
            SaveAllToolStripMenuItem.Enabled = true;
            pageSetupToolStripMenuItem.Enabled = true;
            printPreviewToolStripMenuItem.Enabled = true;
            printToolStripMenuItem.Enabled = true;
            exitToolStripMenuItem.Enabled = true;
            editMenu.Enabled = true;
            viewMenu.Enabled = true;
            formatMenu.Enabled = true;
            windowsMenu.Enabled = true;
            standardToolStrip.Enabled = true;
            formatToolStrip.Enabled = true;

        }

        private void OpenFile(object sender, EventArgs e)
        {
            string fn;
            ChildForm doc = new ChildForm();
            StreamReader sr;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            ofd.Title = "Open a Text File";
            ofd.Filter = "Text File (*.txt)|*.txt|All Files (*.*)|*.*";

            DialogResult dr = ofd.ShowDialog();
            fn = ofd.FileName.Trim();
            if ((dr == DialogResult.Cancel))
            {
                return;
            }
            if (ofd.CheckFileExists)
            {
                sr = File.OpenText(fn);
                doc.RichTextBox1.Text = sr.ReadToEnd();
                sr.Close();
                doc.MdiParent = this;
                doc.Text = ofd.FileName;
                doc.RichTextBox1.Multiline = true;
                doc.RichTextBox1.Dock = DockStyle.Fill;
                doc.Show();
                openDoc++;
                windowsCountStatusLabel.Text = ("Windows Count: " + this.MdiChildren.Length);
                i = 1;
                fileMenu.Enabled = true;


                newToolStripMenuItem.Enabled = true;
                openToolStripMenuItem.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;
                saveToolStripMenuItem.Enabled = true;
                SaveAllToolStripMenuItem.Enabled = true;
                pageSetupToolStripMenuItem.Enabled = true;
                printPreviewToolStripMenuItem.Enabled = true;
                printToolStripMenuItem.Enabled = true;
                exitToolStripMenuItem.Enabled = true;
                editMenu.Enabled = true;
                viewMenu.Enabled = true;
                formatMenu.Enabled = true;
                windowsMenu.Enabled = true;
                standardToolStrip.Enabled = true;
                formatToolStrip.Enabled = true;

            }
            else
            {
                MessageBox.Show("File not found!");
            }

        }
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            sfd.Title = "Save a Text File";
            sfd.Filter = "Text File (*.txt)|*.txt|All Files (*.*)|*.*";
            if (!(ActiveMdiChild == null))
            {
                ChildForm doc = (ChildForm)this.ActiveMdiChild;
                sfd.FileName = doc.Text;
                DialogResult dr = sfd.ShowDialog();
                string fn = sfd.FileName.Trim();
                if ((dr == DialogResult.Cancel))
                {
                    return;
                }
                doc.Tag = fn;
                doc.Text = fn;
                StreamWriter sw = new StreamWriter(fn);
                sw.Write(doc.RichTextBox1.Text);
                i = 1;
                sw.Close();

            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Use System.Windows.Forms.Clipboard to insert the selected text or images into the clipboard
            Form activeChildForm = this.ActiveMdiChild;

            if (activeChildForm != null)
            {
                RichTextBox activeTextBox = (RichTextBox)activeChildForm.ActiveControl;
                if (activeTextBox != null)
                    activeTextBox.Cut();
            }
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Use System.Windows.Forms.Clipboard to insert the selected text or images into the clipboard
            Form activeChildForm = this.ActiveMdiChild;

            if (activeChildForm != null)
            {
                RichTextBox activeTextBox = (RichTextBox)activeChildForm.ActiveControl;
                if (activeTextBox != null)
                    activeTextBox.Copy();
            }
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Use System.Windows.Forms.Clipboard.GetText() or System.Windows.Forms.GetData to retrieve information from the clipboard.
            Form activeChildForm = this.ActiveMdiChild;

            if (activeChildForm != null)
            {

                RichTextBox activeTextBox = (RichTextBox)activeChildForm.ActiveControl;
                if (activeTextBox != null)
                    activeTextBox.Paste();
            }
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            standardToolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip1.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }



        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
                windowsCountStatusLabel.Text = ("Windows Count: " + this.MdiChildren.Length);

            }
            openDoc = 0;
        }

        private void ParentForm_Load(object sender, EventArgs e)
        {
            child.MdiParent = this;
            childFormNumber++;
            child.Text = "Untitled " + childFormNumber;
            child.RichTextBox1.Multiline = true;
            child.RichTextBox1.Dock = DockStyle.Fill;
            child.Show();
            openDoc++;
            timer1.Enabled = true;
            windowsCountStatusLabel.Text = ("Windows Count: " + this.MdiChildren.Length);

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(this.ActiveMdiChild == null))
            {
                ChildForm Doc = (ChildForm)this.ActiveMdiChild;
                string fn = Doc.Text.Trim();
                if ((fn != ""))
                {
                    if (i == 1)
                    {
                        FileStream fs = new
                   FileStream(fn,
                   FileMode.Create, FileAccess.Write);
                        StreamWriter sw = new StreamWriter(fs);
                        sw.BaseStream.Seek(0, SeekOrigin.Current);
                        writer(Doc.RichTextBox1.Text.ToString(), sw);
                        sw.Close();
                        fs.Close();
                    }
                    else
                    {
                        SaveAsToolStripMenuItem_Click(saveAsToolStripMenuItem, new EventArgs());
                    }

                }

            }
        }
        public void writer(String str, StreamWriter sw)
        {
            sw.WriteLine(str);
            sw.Flush();

        }

        private void SaveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ChildForm Doc in this.MdiChildren)
            {
                Doc.Activate();
                this.saveToolStripMenuItem_Click(this.saveToolStripMenuItem, new EventArgs());
            }
        }
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activeChildForm = this.ActiveMdiChild;

            if (activeChildForm != null)
            {
                RichTextBox activeTextBox = (RichTextBox)activeChildForm.ActiveControl;
                if (activeTextBox != null)
                {
                    printDialog1.Document = printDocument1;
                    string strText = activeTextBox.Text;
                    myReader = new StringReader(strText);
                    if (printDialog1.ShowDialog() == DialogResult.OK)
                    {
                        this.printDocument1.Print();
                    }
                }
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Form activeChildForm = this.ActiveMdiChild;
            if (activeChildForm != null)
            {
                RichTextBox activeTextBox = (RichTextBox)activeChildForm.ActiveControl;
                if (activeTextBox != null)
                {
                    float linesPerPage = 0;
                    float yPosition = 0;
                    int count = 0;
                    float leftMargin = e.MarginBounds.Left;
                    float topMargin = e.MarginBounds.Top;
                    string line = null;
                    Font printFont = activeTextBox.Font;
                    SolidBrush myBrush = new SolidBrush(Color.Black);

                    // Work out the number of lines per page, using the MarginBounds.
                    linesPerPage = e.MarginBounds.Height / printFont.GetHeight(e.Graphics);
                    // Iterate over the string using the StringReader, printing each line.
                    while (count < linesPerPage && ((line = myReader.ReadLine()) != null))
                    {
                        // calculate the next line position based on 
                        // the height of the font according to the printing device
                        yPosition = topMargin + (count * printFont.GetHeight(e.Graphics));
                        // draw the next line in the rich edit control
                        e.Graphics.DrawString(line, printFont, myBrush, leftMargin, yPosition, new StringFormat());
                        count++;
                    }
                    // If there are more lines, print another page.
                    if (line != null)
                        e.HasMorePages = true;
                    else
                        e.HasMorePages = false;

                    myBrush.Dispose();
                }
            }
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form activeChildForm = this.ActiveMdiChild;
                if (activeChildForm != null)
                {
                    RichTextBox activeTextBox = (RichTextBox)activeChildForm.ActiveControl;
                    if (activeTextBox != null)
                    {
                        string strText = activeTextBox.Text;
                        myReader = new StringReader(strText);
                        PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
                        printPreviewDialog1.Document = this.printDocument1;
                        printPreviewDialog1.FormBorderStyle = FormBorderStyle.Fixed3D;
                        printPreviewDialog1.ShowDialog();
                    }
                }
            }
            catch (Exception exp)
            {
                System.Console.WriteLine(exp.Message.ToString());
            }
        }

        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PageSettings pgs = new PageSettings();
            PageSetupDialog psdg = new PageSetupDialog();
            psdg.PageSettings = pgs;
            psdg.ShowDialog();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(this.ActiveMdiChild == null))
            {
                ChildForm Doc = (ChildForm)this.ActiveMdiChild;
                Doc.RichTextBox1.Undo();
                redoToolStripMenuItem.Enabled = true;
                undoToolStripMenuItem.Enabled = false;
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(this.ActiveMdiChild == null))
            {
                ChildForm Doc = (ChildForm)this.ActiveMdiChild;
                Doc.RichTextBox1.Redo();
                redoToolStripMenuItem.Enabled = false;
                undoToolStripMenuItem.Enabled = true;
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(this.ActiveMdiChild == null))
            {
                ChildForm Doc = (ChildForm)this.ActiveMdiChild;
                if (Doc.RichTextBox1.SelectionLength == 0)
                    Doc.RichTextBox1.SelectionLength = 1;
                Doc.RichTextBox1.SelectedText = "";
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(this.ActiveMdiChild == null))
            {
                ChildForm Doc = (ChildForm)this.ActiveMdiChild;
                Doc.RichTextBox1.SelectAll();
            }
        }

        private void DTtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(this.ActiveMdiChild == null))
            {
                ChildForm Doc = (ChildForm)this.ActiveMdiChild;
                string time = DateTime.Now.ToString();
                Doc.RichTextBox1.AppendText(time);
            }
        }



        public void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(this.ActiveMdiChild == null))
            {


                this.ActiveMdiChild.Close();
                openDoc = openDoc - 1;
                if (this.ActiveMdiChild == null)
                {
                    openDoc = 0;

                }
                windowsCountStatusLabel.Text = ("Windows Count: " + this.MdiChildren.Length);
            }

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string appVersion = "3.0";
            string str;
            str = ("NotepadPlus v."
                        + (appVersion + ("\nThis program is written by" + ("\nCharu Verma" + ("\nKogent Solutions Inc." + "\n08/8/2007")))));
            MessageBox.Show(str, "NotepadPlus");
        }

        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            DialogResult dr = fd.ShowDialog();
            if (dr == DialogResult.Cancel)
                return;
            ChildForm Doc = (ChildForm)this.ActiveMdiChild;
            Doc.RichTextBox1.SelectionFont = fd.Font;
            DocFont = fd.Font;
        }

        private void bulletedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form activeChildForm = this.ActiveMdiChild;
                if (activeChildForm != null)
                {
                    RichTextBox activeTextBox = (RichTextBox)activeChildForm.ActiveControl;
                    activeTextBox.SelectionBullet = !(activeTextBox.SelectionBullet);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            DialogResult dr = cd.ShowDialog();
            if (dr == DialogResult.Cancel)
                return;
            BackgroundColor = cd.Color;

            if (!(ActiveMdiChild == null))
            {
                ChildForm Doc = (ChildForm)this.ActiveMdiChild;
                Doc.RichTextBox1.BackColor = BackgroundColor;
            }
        }

        private void foregroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ColorDialog cd = new ColorDialog();
            DialogResult dr = cd.ShowDialog();
            if (dr == DialogResult.Cancel)
                return;
            ForegroundColor = cd.Color;
            ChildForm Doc = (ChildForm)this.ActiveMdiChild;
            Doc.RichTextBox1.SelectionColor = ForegroundColor;
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((this.MdiChildren.Length > 0))
            {
                if ((wordWrapToolStripMenuItem.Checked == true))
                {
                    wordWrapToolStripMenuItem.Checked = false;
                    ((ChildForm)(ActiveMdiChild)).RichTextBox1.WordWrap = false;
                }
                else
                {
                    wordWrapToolStripMenuItem.Checked = true;
                    ((ChildForm)(ActiveMdiChild)).RichTextBox1.WordWrap = true;
                }
            }
        }



        private void leftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activeChildForm = this.ActiveMdiChild;

            if (activeChildForm != null)
            {

                RichTextBox activeTextBox = (RichTextBox)activeChildForm.ActiveControl;

                activeTextBox.SelectionAlignment = HorizontalAlignment.Left;

            }
        }

        private void centerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activeChildForm = this.ActiveMdiChild;

            if (activeChildForm != null)
            {

                RichTextBox activeTextBox = (RichTextBox)activeChildForm.ActiveControl;

                activeTextBox.SelectionAlignment = HorizontalAlignment.Center;

            }
        }

        private void rightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activeChildForm = this.ActiveMdiChild;

            if (activeChildForm != null)
            {

                RichTextBox activeTextBox = (RichTextBox)activeChildForm.ActiveControl;

                activeTextBox.SelectionAlignment = HorizontalAlignment.Right;

            }
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindBox tab = new FindBox(this);
            tab.Show();
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindBox tab = new FindBox(this);
            tab.FindTabControl.SelectedTab = tab.replaceTabPage;
            tab.Show();
        }

        private void gotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindBox tab = new FindBox(this);
            tab.FindTabControl.SelectedTab = tab.gotoTabPage;
            tab.Show();
        }

        private void boldToolStripButton_Click(object sender, EventArgs e)
        {
            Form activeChildForm = this.ActiveMdiChild;
            if (activeChildForm != null)
            {
                RichTextBox activeTextBox = (RichTextBox)activeChildForm.ActiveControl;
                if (activeTextBox.SelectionFont == null)
                {
                    return;
                }
                FontStyle style = activeTextBox.SelectionFont.Style;

                if (activeTextBox.SelectionFont.Bold)
                {
                    style &= ~FontStyle.Bold;
                }
                else
                {
                    style |= FontStyle.Bold;
                }
                activeTextBox.SelectionFont = new Font(activeTextBox.SelectionFont, style);
            }
        }

        private void italicToolStripButton_Click(object sender, EventArgs e)
        {
            Form activeChildForm = this.ActiveMdiChild;
            if (activeChildForm != null)
            {
                RichTextBox activeTextBox = (RichTextBox)activeChildForm.ActiveControl;
                if (activeTextBox.SelectionFont == null)
                {
                    return;
                }
                FontStyle style = activeTextBox.SelectionFont.Style;
                if (activeTextBox.SelectionFont.Italic)
                {
                    style &= ~FontStyle.Italic;
                }
                else
                {
                    style |= FontStyle.Italic;
                }
                activeTextBox.SelectionFont = new Font(activeTextBox.SelectionFont, style);
            }
        }

        private void underlineToolStripButton_Click(object sender, EventArgs e)
        {
            Form activeChildForm = this.ActiveMdiChild;
            if (activeChildForm != null)
            {
                RichTextBox activeTextBox = (RichTextBox)activeChildForm.ActiveControl;
                if (activeTextBox.SelectionFont == null)
                {
                    return;
                }
                FontStyle style = activeTextBox.SelectionFont.Style;
                if (activeTextBox.SelectionFont.Underline)
                {
                    style &= ~FontStyle.Underline;
                }
                else
                {
                    style |= FontStyle.Underline;
                }
                activeTextBox.SelectionFont = new Font(activeTextBox.SelectionFont, style);
            }
        }

        private void leftAlignToolStripButton_Click(object sender, EventArgs e)
        {
            Form activeChildForm = this.ActiveMdiChild;
            if (activeChildForm != null)
            {
                RichTextBox activeTextBox = (RichTextBox)activeChildForm.ActiveControl;
                activeTextBox.SelectionAlignment = HorizontalAlignment.Left;
            }
        }

        private void centerAlignToolStripButton_Click(object sender, EventArgs e)
        {
            Form activeChildForm = this.ActiveMdiChild;
            if (activeChildForm != null)
            {
                RichTextBox activeTextBox = (RichTextBox)activeChildForm.ActiveControl;
                activeTextBox.SelectionAlignment = HorizontalAlignment.Center;
            }
        }

        private void rightAlignToolStripButton_Click(object sender, EventArgs e)
        {
            Form activeChildForm = this.ActiveMdiChild;
            if (activeChildForm != null)
            {
                RichTextBox activeTextBox = (RichTextBox)activeChildForm.ActiveControl;
                activeTextBox.SelectionAlignment = HorizontalAlignment.Right;
            }
        }

        private void bulletsToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                Form activeChildForm = this.ActiveMdiChild;
                if (activeChildForm != null)
                {
                    RichTextBox activeTextBox = (RichTextBox)activeChildForm.ActiveControl;
                    activeTextBox.SelectionBullet = !(activeTextBox.SelectionBullet);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void standardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((standardToolStripMenuItem.Checked == true))
            {
                standardToolStripMenuItem.Checked = false;
                standardToolStrip.Hide();
            }
            else
            {
                standardToolStripMenuItem.Checked = true;
                standardToolStrip.Show();
            }
        }

        private void formattingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((formattingToolStripMenuItem.Checked == true))
            {
                formattingToolStripMenuItem.Checked = false;
                formatToolStrip.Hide();
            }
            else
            {
                formattingToolStripMenuItem.Checked = true;
                formatToolStrip.Show();
            }
        }

        private void fontTypeToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form activeChildForm = this.ActiveMdiChild;
            if (activeChildForm != null)
            {
                RichTextBox activeTextBox = (RichTextBox)activeChildForm.ActiveControl;
                if (fontSizeToolStripComboBox.SelectedIndex == -1 || fontTypeToolStripComboBox.SelectedIndex == -1)
                    return;

                FontStyle style = activeTextBox.SelectionFont.Style;
                float size = activeTextBox.SelectionFont.Size;
                activeTextBox.SelectionFont = new Font(
                     fontTypeToolStripComboBox.Items[fontTypeToolStripComboBox.SelectedIndex].ToString(),
                     size,
                     style);
                activeTextBox.Focus();
            }
        }

        private void fontSizeToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form activeChildForm = this.ActiveMdiChild;
            if (activeChildForm != null)
            {
                RichTextBox activeTextBox = (RichTextBox)activeChildForm.ActiveControl;
                if (fontSizeToolStripComboBox.SelectedIndex == -1 || fontTypeToolStripComboBox.SelectedIndex == -1)
                    return;
                FontStyle style = activeTextBox.SelectionFont.Style;
                string name = activeTextBox.SelectionFont.FontFamily.Name;

                activeTextBox.SelectionFont = new Font(
                    name,
                    float.Parse(fontSizeToolStripComboBox.Items[fontSizeToolStripComboBox.SelectedIndex].ToString()),
                    style);
                activeTextBox.Focus();
            }
        }

        private void foregroundColorToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form activeChildForm = this.ActiveMdiChild;
            if (activeChildForm != null)
            {
                RichTextBox activeTextBox = (RichTextBox)activeChildForm.ActiveControl;
                activeTextBox.SelectionColor = m_colors[foregroundColorToolStripComboBox.SelectedIndex];
                activeTextBox.Focus();
            }
        }

        private void backgroundColorToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form activeChildForm = this.ActiveMdiChild;
            if (activeChildForm != null)
            {
                RichTextBox activeTextBox = (RichTextBox)activeChildForm.ActiveControl;
                activeTextBox.BackColor = m_colors[backgroundColorToolStripComboBox.SelectedIndex];
                activeTextBox.Focus();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (openDoc == 0)
            {
                Program.pf.newToolStripMenuItem.Enabled = true;
                Program.pf.openToolStripMenuItem.Enabled = true;
                Program.pf.saveAsToolStripMenuItem.Enabled = false;
                Program.pf.saveToolStripMenuItem.Enabled = false;
                Program.pf.SaveAllToolStripMenuItem.Enabled = false;
                Program.pf.pageSetupToolStripMenuItem.Enabled = false;
                Program.pf.printPreviewToolStripMenuItem.Enabled = false;
                Program.pf.printToolStripMenuItem.Enabled = false;
                Program.pf.exitToolStripMenuItem.Enabled = true;
                Program.pf.editMenu.Enabled = false;
                Program.pf.viewMenu.Enabled = false;
                Program.pf.formatMenu.Enabled = false;
                Program.pf.windowsMenu.Enabled = false;
                Program.pf.standardToolStrip.Enabled = false;
                Program.pf.formatToolStrip.Enabled = false;
            }
            windowsCountStatusLabel.Text = ("Windows Count: " + this.MdiChildren.Length);

        }

        

      


    }
}
