
namespace BeamModTextureOptimiser
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.duplicateTexturesListbox = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.duplicateTexturesLabel = new System.Windows.Forms.Label();
            this.excessStorageStatisticLabel = new System.Windows.Forms.Label();
            this.deleteBakFiles = new System.Windows.Forms.Button();
            this.loadModBtn = new System.Windows.Forms.Button();
            this.remapDuplicatesBtn = new System.Windows.Forms.Button();
            this.checkDuplicatesBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.browseModFolderBtn = new System.Windows.Forms.Button();
            this.modPathTextBox = new System.Windows.Forms.TextBox();
            this.openModFolderDialogue = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // duplicateTexturesListbox
            // 
            this.duplicateTexturesListbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.duplicateTexturesListbox.FormattingEnabled = true;
            this.duplicateTexturesListbox.ItemHeight = 15;
            this.duplicateTexturesListbox.Location = new System.Drawing.Point(3, 27);
            this.duplicateTexturesListbox.Name = "duplicateTexturesListbox";
            this.duplicateTexturesListbox.Size = new System.Drawing.Size(212, 469);
            this.duplicateTexturesListbox.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.duplicateTexturesLabel);
            this.splitContainer1.Panel1.Controls.Add(this.duplicateTexturesListbox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.excessStorageStatisticLabel);
            this.splitContainer1.Panel2.Controls.Add(this.deleteBakFiles);
            this.splitContainer1.Panel2.Controls.Add(this.loadModBtn);
            this.splitContainer1.Panel2.Controls.Add(this.remapDuplicatesBtn);
            this.splitContainer1.Panel2.Controls.Add(this.checkDuplicatesBtn);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.browseModFolderBtn);
            this.splitContainer1.Panel2.Controls.Add(this.modPathTextBox);
            this.splitContainer1.Size = new System.Drawing.Size(654, 497);
            this.splitContainer1.SplitterDistance = 218;
            this.splitContainer1.TabIndex = 1;
            // 
            // duplicateTexturesLabel
            // 
            this.duplicateTexturesLabel.AutoSize = true;
            this.duplicateTexturesLabel.Location = new System.Drawing.Point(3, 8);
            this.duplicateTexturesLabel.Name = "duplicateTexturesLabel";
            this.duplicateTexturesLabel.Size = new System.Drawing.Size(106, 15);
            this.duplicateTexturesLabel.TabIndex = 1;
            this.duplicateTexturesLabel.Text = "Duplicate Textures:";
            // 
            // excessStorageStatisticLabel
            // 
            this.excessStorageStatisticLabel.AutoSize = true;
            this.excessStorageStatisticLabel.Location = new System.Drawing.Point(13, 73);
            this.excessStorageStatisticLabel.Name = "excessStorageStatisticLabel";
            this.excessStorageStatisticLabel.Size = new System.Drawing.Size(170, 15);
            this.excessStorageStatisticLabel.TabIndex = 7;
            this.excessStorageStatisticLabel.Text = "Excess (uncompresed) storage:";
            // 
            // deleteBakFiles
            // 
            this.deleteBakFiles.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.deleteBakFiles.Location = new System.Drawing.Point(13, 389);
            this.deleteBakFiles.Name = "deleteBakFiles";
            this.deleteBakFiles.Size = new System.Drawing.Size(114, 47);
            this.deleteBakFiles.TabIndex = 6;
            this.deleteBakFiles.Text = "Delete .bak files";
            this.deleteBakFiles.UseVisualStyleBackColor = true;
            this.deleteBakFiles.Click += new System.EventHandler(this.deleteBakFiles_Click);
            // 
            // loadModBtn
            // 
            this.loadModBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.loadModBtn.Location = new System.Drawing.Point(13, 442);
            this.loadModBtn.Name = "loadModBtn";
            this.loadModBtn.Size = new System.Drawing.Size(114, 47);
            this.loadModBtn.TabIndex = 5;
            this.loadModBtn.Text = "Load Mod";
            this.loadModBtn.UseVisualStyleBackColor = true;
            this.loadModBtn.Click += new System.EventHandler(this.loadModBtn_Click);
            // 
            // remapDuplicatesBtn
            // 
            this.remapDuplicatesBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.remapDuplicatesBtn.Location = new System.Drawing.Point(306, 442);
            this.remapDuplicatesBtn.Name = "remapDuplicatesBtn";
            this.remapDuplicatesBtn.Size = new System.Drawing.Size(114, 47);
            this.remapDuplicatesBtn.TabIndex = 4;
            this.remapDuplicatesBtn.Text = "Remap Duplicates";
            this.remapDuplicatesBtn.UseVisualStyleBackColor = true;
            this.remapDuplicatesBtn.Click += new System.EventHandler(this.remapDuplicatesBtn_Click);
            // 
            // checkDuplicatesBtn
            // 
            this.checkDuplicatesBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkDuplicatesBtn.Location = new System.Drawing.Point(160, 442);
            this.checkDuplicatesBtn.Name = "checkDuplicatesBtn";
            this.checkDuplicatesBtn.Size = new System.Drawing.Size(114, 47);
            this.checkDuplicatesBtn.TabIndex = 3;
            this.checkDuplicatesBtn.Text = "Find Duplicates";
            this.checkDuplicatesBtn.UseVisualStyleBackColor = true;
            this.checkDuplicatesBtn.Click += new System.EventHandler(this.checkDuplicatesBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mod folder (Root)";
            // 
            // browseModFolderBtn
            // 
            this.browseModFolderBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseModFolderBtn.Location = new System.Drawing.Point(345, 27);
            this.browseModFolderBtn.Name = "browseModFolderBtn";
            this.browseModFolderBtn.Size = new System.Drawing.Size(75, 23);
            this.browseModFolderBtn.TabIndex = 1;
            this.browseModFolderBtn.Text = "Browse";
            this.browseModFolderBtn.UseVisualStyleBackColor = true;
            this.browseModFolderBtn.Click += new System.EventHandler(this.browseModFolderBtn_Click);
            // 
            // modPathTextBox
            // 
            this.modPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.modPathTextBox.Location = new System.Drawing.Point(13, 27);
            this.modPathTextBox.Name = "modPathTextBox";
            this.modPathTextBox.Size = new System.Drawing.Size(326, 23);
            this.modPathTextBox.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 497);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "BeamModTextureOptimiser";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox duplicateTexturesListbox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label duplicateTexturesLabel;
        private System.Windows.Forms.Button checkDuplicatesBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button browseModFolderBtn;
        private System.Windows.Forms.TextBox modPathTextBox;
        private System.Windows.Forms.FolderBrowserDialog openModFolderDialogue;
        private System.Windows.Forms.Button remapDuplicatesBtn;
        private System.Windows.Forms.Button loadModBtn;
        private System.Windows.Forms.Button deleteBakFiles;
        private System.Windows.Forms.Label excessStorageStatisticLabel;
    }
}

