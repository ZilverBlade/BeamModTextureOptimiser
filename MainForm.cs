using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeamModTextureOptimiser
{
    public partial class MainForm : Form
    {
        ModContext context = null;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void loadModBtn_Click(object sender, EventArgs e)
        {
            context = new ModContext();
            try
            {
                context.LoadPath(modPathTextBox.Text);
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Caught", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkDuplicatesBtn_Click(object sender, EventArgs e)
        {
            try
            {
                context.FindDuplicates();
                duplicateTexturesListbox.Items.Clear();
                long totalExtraSize = 0;
                foreach (var info in context.GetDuplicateInfos()) 
                {
                    duplicateTexturesListbox.Items.Add($"{info.name} : {info.size / 1024} kB ({info.numDuplicates} dupes!)");
                    totalExtraSize += (info.numDuplicates - 1) * info.size;
                }
                excessStorageStatisticLabel.Text = $"Excess (uncompresed) storage: {totalExtraSize / (1<<20)} MB";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Caught", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void remapDuplicatesBtn_Click(object sender, EventArgs e)
        {
            try
            {
                context.RemapDuplicates();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Caught", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteBakFiles_Click(object sender, EventArgs e)
        {

        }

        private void browseModFolderBtn_Click(object sender, EventArgs e)
        {
            if (openModFolderDialogue.ShowDialog() == DialogResult.OK)
            {
                modPathTextBox.Text = openModFolderDialogue.SelectedPath;
            }  
        }

    }
}
