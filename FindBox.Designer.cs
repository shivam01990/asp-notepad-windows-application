namespace NotepadPlus
{
    partial class FindBox
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
            this.FindTabControl = new System.Windows.Forms.TabControl();
            this.findTabPage = new System.Windows.Forms.TabPage();
            this.cancelButton = new System.Windows.Forms.Button();
            this.findNextButton = new System.Windows.Forms.Button();
            this.findWhatTextBox1 = new System.Windows.Forms.TextBox();
            this.findWhatLabel1 = new System.Windows.Forms.Label();
            this.replaceTabPage = new System.Windows.Forms.TabPage();
            this.cancelButton2 = new System.Windows.Forms.Button();
            this.replaceAllButton = new System.Windows.Forms.Button();
            this.replaceButton = new System.Windows.Forms.Button();
            this.findNextButton2 = new System.Windows.Forms.Button();
            this.replaceWithTextBox = new System.Windows.Forms.TextBox();
            this.findWhatTextBox2 = new System.Windows.Forms.TextBox();
            this.replaceWithLabel = new System.Windows.Forms.Label();
            this.findWhatLabel2 = new System.Windows.Forms.Label();
            this.gotoTabPage = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.gotoButton = new System.Windows.Forms.Button();
            this.gotoTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FindTabControl.SuspendLayout();
            this.findTabPage.SuspendLayout();
            this.replaceTabPage.SuspendLayout();
            this.gotoTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // FindTabControl
            // 
            this.FindTabControl.Controls.Add(this.findTabPage);
            this.FindTabControl.Controls.Add(this.replaceTabPage);
            this.FindTabControl.Controls.Add(this.gotoTabPage);
            this.FindTabControl.Location = new System.Drawing.Point(0, 0);
            this.FindTabControl.Name = "FindTabControl";
            this.FindTabControl.SelectedIndex = 0;
            this.FindTabControl.Size = new System.Drawing.Size(399, 199);
            this.FindTabControl.TabIndex = 1;
            // 
            // findTabPage
            // 
            this.findTabPage.Controls.Add(this.cancelButton);
            this.findTabPage.Controls.Add(this.findNextButton);
            this.findTabPage.Controls.Add(this.findWhatTextBox1);
            this.findTabPage.Controls.Add(this.findWhatLabel1);
            this.findTabPage.Location = new System.Drawing.Point(4, 22);
            this.findTabPage.Name = "findTabPage";
            this.findTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.findTabPage.Size = new System.Drawing.Size(391, 173);
            this.findTabPage.TabIndex = 0;
            this.findTabPage.Text = "Find";
            this.findTabPage.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(220, 98);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(111, 33);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // findNextButton
            // 
            this.findNextButton.Location = new System.Drawing.Point(58, 98);
            this.findNextButton.Name = "findNextButton";
            this.findNextButton.Size = new System.Drawing.Size(111, 33);
            this.findNextButton.TabIndex = 4;
            this.findNextButton.Text = "Find Next";
            this.findNextButton.UseVisualStyleBackColor = true;
            this.findNextButton.Click += new System.EventHandler(this.findNextButton_Click);
            // 
            // findWhatTextBox1
            // 
            this.findWhatTextBox1.Location = new System.Drawing.Point(94, 19);
            this.findWhatTextBox1.Name = "findWhatTextBox1";
            this.findWhatTextBox1.Size = new System.Drawing.Size(261, 20);
            this.findWhatTextBox1.TabIndex = 1;
            this.findWhatTextBox1.TextChanged += new System.EventHandler(this.findWhatTextBox1_TextChanged);
            // 
            // findWhatLabel1
            // 
            this.findWhatLabel1.AutoSize = true;
            this.findWhatLabel1.Location = new System.Drawing.Point(15, 23);
            this.findWhatLabel1.Name = "findWhatLabel1";
            this.findWhatLabel1.Size = new System.Drawing.Size(59, 13);
            this.findWhatLabel1.TabIndex = 0;
            this.findWhatLabel1.Text = "Find What:";
            // 
            // replaceTabPage
            // 
            this.replaceTabPage.Controls.Add(this.cancelButton2);
            this.replaceTabPage.Controls.Add(this.replaceAllButton);
            this.replaceTabPage.Controls.Add(this.replaceButton);
            this.replaceTabPage.Controls.Add(this.findNextButton2);
            this.replaceTabPage.Controls.Add(this.replaceWithTextBox);
            this.replaceTabPage.Controls.Add(this.findWhatTextBox2);
            this.replaceTabPage.Controls.Add(this.replaceWithLabel);
            this.replaceTabPage.Controls.Add(this.findWhatLabel2);
            this.replaceTabPage.Location = new System.Drawing.Point(4, 22);
            this.replaceTabPage.Name = "replaceTabPage";
            this.replaceTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.replaceTabPage.Size = new System.Drawing.Size(391, 173);
            this.replaceTabPage.TabIndex = 1;
            this.replaceTabPage.Text = "Replace";
            this.replaceTabPage.UseVisualStyleBackColor = true;
            // 
            // cancelButton2
            // 
            this.cancelButton2.Location = new System.Drawing.Point(287, 130);
            this.cancelButton2.Name = "cancelButton2";
            this.cancelButton2.Size = new System.Drawing.Size(74, 26);
            this.cancelButton2.TabIndex = 8;
            this.cancelButton2.Text = "Cancel";
            this.cancelButton2.UseVisualStyleBackColor = true;
            this.cancelButton2.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // replaceAllButton
            // 
            this.replaceAllButton.Location = new System.Drawing.Point(197, 130);
            this.replaceAllButton.Name = "replaceAllButton";
            this.replaceAllButton.Size = new System.Drawing.Size(74, 26);
            this.replaceAllButton.TabIndex = 7;
            this.replaceAllButton.Text = "Replace All";
            this.replaceAllButton.UseVisualStyleBackColor = true;
            this.replaceAllButton.Click += new System.EventHandler(this.replaceAllButton_Click);
            // 
            // replaceButton
            // 
            this.replaceButton.Location = new System.Drawing.Point(107, 130);
            this.replaceButton.Name = "replaceButton";
            this.replaceButton.Size = new System.Drawing.Size(74, 26);
            this.replaceButton.TabIndex = 6;
            this.replaceButton.Text = "Replace";
            this.replaceButton.UseVisualStyleBackColor = true;
            this.replaceButton.Click += new System.EventHandler(this.replaceButton_Click);
            // 
            // findNextButton2
            // 
            this.findNextButton2.Location = new System.Drawing.Point(13, 130);
            this.findNextButton2.Name = "findNextButton2";
            this.findNextButton2.Size = new System.Drawing.Size(74, 26);
            this.findNextButton2.TabIndex = 5;
            this.findNextButton2.Text = "Find Next";
            this.findNextButton2.UseVisualStyleBackColor = true;
            this.findNextButton2.Click += new System.EventHandler(this.findNextButton_Click);
            // 
            // replaceWithTextBox
            // 
            this.replaceWithTextBox.Location = new System.Drawing.Point(92, 66);
            this.replaceWithTextBox.Name = "replaceWithTextBox";
            this.replaceWithTextBox.Size = new System.Drawing.Size(269, 20);
            this.replaceWithTextBox.TabIndex = 3;
            // 
            // findWhatTextBox2
            // 
            this.findWhatTextBox2.Location = new System.Drawing.Point(92, 19);
            this.findWhatTextBox2.Name = "findWhatTextBox2";
            this.findWhatTextBox2.Size = new System.Drawing.Size(269, 20);
            this.findWhatTextBox2.TabIndex = 2;
            this.findWhatTextBox2.TextChanged += new System.EventHandler(this.findWhatTextBox2_TextChanged);
            // 
            // replaceWithLabel
            // 
            this.replaceWithLabel.AutoSize = true;
            this.replaceWithLabel.Location = new System.Drawing.Point(10, 66);
            this.replaceWithLabel.Name = "replaceWithLabel";
            this.replaceWithLabel.Size = new System.Drawing.Size(75, 13);
            this.replaceWithLabel.TabIndex = 1;
            this.replaceWithLabel.Text = "Replace With:";
            // 
            // findWhatLabel2
            // 
            this.findWhatLabel2.AutoSize = true;
            this.findWhatLabel2.Location = new System.Drawing.Point(10, 20);
            this.findWhatLabel2.Name = "findWhatLabel2";
            this.findWhatLabel2.Size = new System.Drawing.Size(59, 13);
            this.findWhatLabel2.TabIndex = 0;
            this.findWhatLabel2.Text = "Find What:";
            // 
            // gotoTabPage
            // 
            this.gotoTabPage.Controls.Add(this.button2);
            this.gotoTabPage.Controls.Add(this.gotoButton);
            this.gotoTabPage.Controls.Add(this.gotoTextBox);
            this.gotoTabPage.Controls.Add(this.label1);
            this.gotoTabPage.Location = new System.Drawing.Point(4, 22);
            this.gotoTabPage.Name = "gotoTabPage";
            this.gotoTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.gotoTabPage.Size = new System.Drawing.Size(391, 173);
            this.gotoTabPage.TabIndex = 2;
            this.gotoTabPage.Text = "Go To";
            this.gotoTabPage.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(229, 108);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 33);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // gotoButton
            // 
            this.gotoButton.Location = new System.Drawing.Point(48, 108);
            this.gotoButton.Name = "gotoButton";
            this.gotoButton.Size = new System.Drawing.Size(113, 33);
            this.gotoButton.TabIndex = 2;
            this.gotoButton.Text = "Go To";
            this.gotoButton.UseVisualStyleBackColor = true;
            this.gotoButton.Click += new System.EventHandler(this.gotoButton_Click);
            // 
            // gotoTextBox
            // 
            this.gotoTextBox.Location = new System.Drawing.Point(130, 45);
            this.gotoTextBox.Name = "gotoTextBox";
            this.gotoTextBox.Size = new System.Drawing.Size(238, 20);
            this.gotoTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Line Number:";
            // 
            // FindBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 195);
            this.Controls.Add(this.FindTabControl);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(404, 229);
            this.MinimumSize = new System.Drawing.Size(404, 229);
            this.Name = "FindBox";
            this.Text = "FindBox";
            this.FindTabControl.ResumeLayout(false);
            this.findTabPage.ResumeLayout(false);
            this.findTabPage.PerformLayout();
            this.replaceTabPage.ResumeLayout(false);
            this.replaceTabPage.PerformLayout();
            this.gotoTabPage.ResumeLayout(false);
            this.gotoTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TabControl FindTabControl;
        internal System.Windows.Forms.TabPage findTabPage;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button findNextButton;
        private System.Windows.Forms.TextBox findWhatTextBox1;
        private System.Windows.Forms.Label findWhatLabel1;
        internal System.Windows.Forms.TabPage replaceTabPage;
        private System.Windows.Forms.Button cancelButton2;
        private System.Windows.Forms.Button replaceAllButton;
        private System.Windows.Forms.Button replaceButton;
        private System.Windows.Forms.Button findNextButton2;
        private System.Windows.Forms.TextBox replaceWithTextBox;
        private System.Windows.Forms.TextBox findWhatTextBox2;
        private System.Windows.Forms.Label replaceWithLabel;
        private System.Windows.Forms.Label findWhatLabel2;
        internal System.Windows.Forms.TabPage gotoTabPage;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button gotoButton;
        private System.Windows.Forms.TextBox gotoTextBox;
        private System.Windows.Forms.Label label1;
    }
}