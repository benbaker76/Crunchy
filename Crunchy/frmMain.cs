using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using JeremyAnsel.ColorQuant;
using Baker76.Imaging;

namespace Crunchy
{
    public partial class frmMain : Form
    {
        private BackgroundWorker _backgroundWorker;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text = this.Text.Replace("[VERSION]", Globals.Version);

            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.WorkerReportsProgress = true;
            _backgroundWorker.DoWork += BackgroundWorker_DoWork;
            _backgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
            _backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;

            for (int i = 0; i < Globals.MAX_FOLDERS; i++)
            {
                Settings.File.InputFolderList.Add(String.Empty);
                cboInputFolder.Items.Add(String.Format("{0}", i + 1));
            }

            cboInputFolder.SelectedIndex = 0;

            cboBitDepth.Items.AddRange(Globals.BitDepthStrings);

            cboColorDistance.Items.AddRange(new string[] { "Sqrt", "CIEDE2000" });

            cboFileFormat.Items.AddRange(new string[] { "Bin", "Text", "Json", "Xml", "Meta" });

            cboColorCount.Items.AddRange(new string[] { "16", "256" });

            ReadConfig(Path.Combine(Application.StartupPath, Settings.File.DefaultFileName));
            ReadConfig(Path.Combine(Application.StartupPath, Settings.File.FileName));
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            DoWorkAsync(worker).Wait();
        }

        private async Task DoWorkAsync(BackgroundWorker worker)
        {
            (bool success, string output, string error) = await TextureAtlas.ProcessAtlasFiles(worker);

            if (!success)
                MessageBox.Show(this, error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            tspbProgress.Value = e.ProgressPercentage;
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            butGo.Enabled = true;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            WriteConfig(Path.Combine(Application.StartupPath, Settings.File.DefaultFileName));
            WriteConfig(Path.Combine(Application.StartupPath, Settings.File.FileName));
        }

        private void txtInteger_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !(e.KeyChar == '\b'))
                e.Handled = true;
        }

        private void butInputFolder_Click(object sender, EventArgs e)
        {
            string inputFolder = null;

            if (FileIO.TryOpenFolder(this, txtInputFolder.Text, out inputFolder))
                txtInputFolder.Text = inputFolder;
        }

        private void butOutputFolder_Click(object sender, EventArgs e)
        {
            string outputFolder = null;

            if (FileIO.TryOpenFolder(this, txtOutputFolder.Text, out outputFolder))
                txtOutputFolder.Text = outputFolder;
        }

        private void butInputPalette_Click(object sender, EventArgs e)
        {
            string fileName = null;
            string[] extensions = { ".act", ".pal", ".pal", ".gpl", ".txt" };

            if (FileIO.TryOpenFile(this, Application.StartupPath, txtInputPalette.Text, "Palette Files", extensions, out fileName))
                txtInputPalette.Text = fileName;
        }

        private void butGo_Click(object sender, EventArgs e)
        {
            butGo.Enabled = false;

            _backgroundWorker.RunWorkerAsync();
        }

        private void butColorBackground_Click(object sender, EventArgs e)
        {
            rdoColorBackground.Checked = true;

            ColorDialog cd = new ColorDialog();
            cd.AllowFullOpen = true;
            cd.FullOpen = true;
            cd.Color = butColor.BackColor;

            if (cd.ShowDialog() == DialogResult.OK)
            {
                butColor.BackColor = cd.Color;
                Settings.General.BackColor = Baker76.Imaging.Color.FromArgb(cd.Color.ToArgb());
            }
        }

        void ReadConfig(string fileName)
        {
            TextureAtlas.ReadConfig(fileName);

            txtOutputFolder.Text = Settings.File.OutputFolder;
            txtInputPalette.Text = Settings.File.PaletteFileName;
            chkRecursive.Checked = Settings.General.Recursive;
            txtName.Text = Settings.General.Name;
            cboFileFormat.SelectedIndex = (int)Settings.General.FileFormat;
            cboBitDepth.SelectedItem = Settings.General.BitDepth.ToString();
            chkMultiTexture.Checked = Settings.General.MultiTexture;
            chkAutoSizeTexture.Checked = Settings.General.AutoSizeTexture;
            txtTextureWidth.Text = Settings.General.TextureSize.Width.ToString();
            txtTextureHeight.Text = Settings.General.TextureSize.Height.ToString();
            rdoAlphaBackground.Checked = Settings.General.AlphaBackground;
            rdoColorBackground.Checked = Settings.General.ColorBackground;
            rdoIndexBackground.Checked = Settings.General.IndexBackground;
            butColor.BackColor = System.Drawing.Color.FromArgb(Settings.General.BackColor.ToArgb());
            txtBackgroundIndex.Text = Settings.General.BackgroundIndex.ToString();
            chkReplaceBackgroundColor.Checked = Settings.General.ReplaceBackgroundColor;
            cboColorDistance.SelectedIndex = (int)Settings.General.ColorDistance;
            txtSpacing.Text = Settings.General.Spacing.ToString();
            chkFillSpacing.Checked = Settings.General.FillSpacing;
            chkTrimBackground.Checked = Settings.General.TrimBackground;
            chkQuantize.Checked = Settings.General.Quantize;
            cboColorCount.SelectedItem = Settings.General.ColorCount.ToString();
            chkAutoPaletteSlot.Checked = Settings.General.AutoPaletteSlot;
            chkRemapPalette.Checked = Settings.General.RemapPalette;
            nudPaletteSlot.Value = Settings.General.PaletteSlot;
            chkPaletteSlotAddIndex.Checked = Settings.General.PaletteSlotAddIndex;

            toolStripStatusLabel1.Text = Path.GetFileName(Settings.File.FileName);

            cboInputFolder_SelectedIndexChanged(this, new EventArgs());
        }

        void WriteConfig(string fileName)
        {
            TextureAtlas.WriteConfig(fileName);

            toolStripStatusLabel1.Text = Path.GetFileName(Settings.File.FileName);
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            string fileName = null;

            if (FileIO.TryOpenFile(this, Application.StartupPath, Settings.File.FileName, "Ini Files", new string[] { ".ini" }, out fileName))
            {
                Settings.File.FileName = fileName;

                ReadConfig(Settings.File.FileName);
            }
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            WriteConfig(Settings.File.FileName);
        }

        private void mnuSaveAs_Click(object sender, EventArgs e)
        {
            string fileName = null;

            if (FileIO.TrySaveFile(this, Application.StartupPath, Settings.File.FileName, "Ini Files", new string[] { ".ini" }, out fileName))
            {
                Settings.File.FileName = fileName;

                WriteConfig(Settings.File.FileName);
            }
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuSpriteSheetSlicer_Click(object sender, EventArgs e)
        {
            using (frmSpriteSlicer frmSpriteSlicer = new frmSpriteSlicer())
                frmSpriteSlicer.ShowDialog(this);
        }

        private void cboInputFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtInputFolder.Text = Settings.File.InputFolderList[cboInputFolder.SelectedIndex];
        }

        private void txtInputFolder_TextChanged(object sender, EventArgs e)
        {
            Settings.File.InputFolderList[cboInputFolder.SelectedIndex] = txtInputFolder.Text;
        }

        private void txtOutputFolder_TextChanged(object sender, EventArgs e)
        {
            Settings.File.OutputFolder = txtOutputFolder.Text;
        }

        private void txtInputPalette_TextChanged(object sender, EventArgs e)
        {
            Settings.File.PaletteFileName = txtInputPalette.Text;
        }

        private void chkRecursive_CheckedChanged(object sender, EventArgs e)
        {
            Settings.General.Recursive = chkRecursive.Checked;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            Settings.General.Name = txtName.Text;
        }

        private void cboFileFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.General.FileFormat = (FileFormat)cboFileFormat.SelectedIndex;
        }

        private void chkMultiTexture_CheckedChanged(object sender, EventArgs e)
        {
            Settings.General.MultiTexture = chkMultiTexture.Checked;
        }

        private void chkAutoSizeTexture_CheckedChanged(object sender, EventArgs e)
        {
            Settings.General.AutoSizeTexture = chkAutoSizeTexture.Checked;
        }

        private void rdoAlphaBackground_CheckedChanged(object sender, EventArgs e)
        {
            Settings.General.AlphaBackground = rdoAlphaBackground.Checked;
        }

        private void rdoColorBackground_CheckedChanged(object sender, EventArgs e)
        {
            Settings.General.ColorBackground = rdoColorBackground.Checked;
        }

        private void rdoIndexBackground_CheckedChanged(object sender, EventArgs e)
        {
            Settings.General.IndexBackground = rdoIndexBackground.Checked;
        }

        private void chkReplaceBackgroundColor_CheckedChanged(object sender, EventArgs e)
        {
            Settings.General.ReplaceBackgroundColor = chkReplaceBackgroundColor.Checked;
        }

        private void cboBitDepth_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.General.BitDepth = int.Parse(cboBitDepth.SelectedItem.ToString());
        }

        private void txtTextureWidth_TextChanged(object sender, EventArgs e)
        {
            int textureWidth;

            if (int.TryParse(txtTextureWidth.Text, out textureWidth))
                Settings.General.TextureSize.Width = textureWidth;
        }

        private void txtTextureHeight_TextChanged(object sender, EventArgs e)
        {
            int textureHeight;

            if (int.TryParse(txtTextureHeight.Text, out textureHeight))
                Settings.General.TextureSize.Height = textureHeight;
        }

        private void cboColorDistance_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.General.ColorDistance = (DistanceType)cboColorDistance.SelectedIndex;
        }

        private void txtSpacing_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(txtSpacing.Text, out Settings.General.Spacing);
        }

        private void chkFillSpacing_CheckedChanged(object sender, EventArgs e)
        {
            Settings.General.FillSpacing = chkFillSpacing.Checked;
        }

        private void chkTrimBackground_CheckedChanged(object sender, EventArgs e)
        {
            Settings.General.TrimBackground = chkTrimBackground.Checked;
        }

        private void chkQuantize_CheckedChanged(object sender, EventArgs e)
        {
            Settings.General.Quantize = chkQuantize.Checked;
        }

        private void cboColorCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.General.ColorCount = int.Parse(cboColorCount.SelectedItem.ToString());
        }

        private void chkAutoPaletteSlot_CheckedChanged(object sender, EventArgs e)
        {
            Settings.General.AutoPaletteSlot = chkAutoPaletteSlot.Checked;
        }

        private void chkRemapPalette_CheckedChanged(object sender, EventArgs e)
        {
            Settings.General.RemapPalette = chkRemapPalette.Checked;
        }

        private void nudPaletteSlot_ValueChanged(object sender, EventArgs e)
        {
            Settings.General.PaletteSlot = (int)nudPaletteSlot.Value;
        }

        private void chkPaletteSlotAddIndex_CheckedChanged(object sender, EventArgs e)
        {
            Settings.General.PaletteSlotAddIndex = chkPaletteSlotAddIndex.Checked;
        }

        private void txtBackgroundIndex_TextChanged(object sender, EventArgs e)
        {
            rdoIndexBackground.Checked = true;

            Settings.General.BackgroundIndex = int.Parse(txtBackgroundIndex.Text);
        }

        private void lblbaker76_Click(object sender, EventArgs e)
        {
            Process.Start("https://baker76.com");
        }
    }
}
