namespace Crunchy
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            grpFolders = new GroupBox();
            cboInputFolder = new ComboBox();
            chkRecursive = new CheckBox();
            butInputFolder = new Button();
            txtInputFolder = new TextBox();
            grpTextureOptions = new GroupBox();
            chkAutoSizeTexture = new CheckBox();
            lblColorDistance = new Label();
            cboColorDistance = new ComboBox();
            lblBitDepth = new Label();
            cboBitDepth = new ComboBox();
            chkFillSpacing = new CheckBox();
            chkMultiTexture = new CheckBox();
            lblSpacing = new Label();
            txtSpacing = new TextBox();
            lblTextureHeight = new Label();
            txtTextureHeight = new TextBox();
            lblTextureWidth = new Label();
            txtTextureWidth = new TextBox();
            butColor = new Button();
            rdoColorBackground = new RadioButton();
            rdoAlphaBackground = new RadioButton();
            butGo = new Button();
            grpImageOptions = new GroupBox();
            chkRemapPalette = new CheckBox();
            chkPaletteSlotAddIndex = new CheckBox();
            cboColorCount = new ComboBox();
            lblColors = new Label();
            nudPaletteSlot = new NumericUpDown();
            chkAutoPaletteSlot = new CheckBox();
            chkQuantize = new CheckBox();
            lblPaletteSlot = new Label();
            chkTrimBackground = new CheckBox();
            menuStrip1 = new MenuStrip();
            mnuFile = new ToolStripMenuItem();
            mnuOpen = new ToolStripMenuItem();
            mnuSave = new ToolStripMenuItem();
            mnuSaveAs = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            mnuExit = new ToolStripMenuItem();
            mnuTools = new ToolStripMenuItem();
            mnuSpriteSheetSlicer = new ToolStripMenuItem();
            mnuSpriteSheetStripper = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            tspbProgress = new ToolStripProgressBar();
            grpOutputOptions = new GroupBox();
            cboFileFormat = new ComboBox();
            lblOutputFolder = new Label();
            butOutputFolder = new Button();
            txtOutputFolder = new TextBox();
            lblFileFormat = new Label();
            txtName = new TextBox();
            lblName = new Label();
            grpInputPalette = new GroupBox();
            butInputPalette = new Button();
            txtInputPalette = new TextBox();
            grpBackgroundOptions = new GroupBox();
            chkReplaceBackgroundColor = new CheckBox();
            rdoIndexBackground = new RadioButton();
            txtBackgroundIndex = new TextBox();
            lblbaker76 = new Label();
            grpFolders.SuspendLayout();
            grpTextureOptions.SuspendLayout();
            grpImageOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPaletteSlot).BeginInit();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            grpOutputOptions.SuspendLayout();
            grpInputPalette.SuspendLayout();
            grpBackgroundOptions.SuspendLayout();
            SuspendLayout();
            // 
            // grpFolders
            // 
            grpFolders.Controls.Add(cboInputFolder);
            grpFolders.Controls.Add(chkRecursive);
            grpFolders.Controls.Add(butInputFolder);
            grpFolders.Controls.Add(txtInputFolder);
            grpFolders.Location = new Point(14, 31);
            grpFolders.Margin = new Padding(4, 3, 4, 3);
            grpFolders.Name = "grpFolders";
            grpFolders.Padding = new Padding(4, 3, 4, 3);
            grpFolders.Size = new Size(593, 97);
            grpFolders.TabIndex = 1;
            grpFolders.TabStop = false;
            grpFolders.Text = "Input Folder(s)";
            // 
            // cboInputFolder
            // 
            cboInputFolder.DropDownStyle = ComboBoxStyle.DropDownList;
            cboInputFolder.FormattingEnabled = true;
            cboInputFolder.Location = new Point(20, 25);
            cboInputFolder.Margin = new Padding(4, 3, 4, 3);
            cboInputFolder.Name = "cboInputFolder";
            cboInputFolder.Size = new Size(86, 23);
            cboInputFolder.TabIndex = 0;
            cboInputFolder.SelectedIndexChanged += cboInputFolder_SelectedIndexChanged;
            // 
            // chkRecursive
            // 
            chkRecursive.AutoSize = true;
            chkRecursive.Location = new Point(20, 62);
            chkRecursive.Margin = new Padding(4, 3, 4, 3);
            chkRecursive.Name = "chkRecursive";
            chkRecursive.Size = new Size(165, 19);
            chkRecursive.TabIndex = 3;
            chkRecursive.Text = "Recursive Directory Search";
            chkRecursive.UseVisualStyleBackColor = true;
            chkRecursive.CheckedChanged += chkRecursive_CheckedChanged;
            // 
            // butInputFolder
            // 
            butInputFolder.Location = new Point(524, 27);
            butInputFolder.Margin = new Padding(4, 3, 4, 3);
            butInputFolder.Name = "butInputFolder";
            butInputFolder.Size = new Size(46, 23);
            butInputFolder.TabIndex = 2;
            butInputFolder.Text = "...";
            butInputFolder.UseVisualStyleBackColor = true;
            butInputFolder.Click += butInputFolder_Click;
            // 
            // txtInputFolder
            // 
            txtInputFolder.Location = new Point(113, 27);
            txtInputFolder.Margin = new Padding(4, 3, 4, 3);
            txtInputFolder.Name = "txtInputFolder";
            txtInputFolder.Size = new Size(398, 23);
            txtInputFolder.TabIndex = 1;
            txtInputFolder.TextAlign = HorizontalAlignment.Right;
            txtInputFolder.TextChanged += txtInputFolder_TextChanged;
            // 
            // grpTextureOptions
            // 
            grpTextureOptions.Controls.Add(chkAutoSizeTexture);
            grpTextureOptions.Controls.Add(lblColorDistance);
            grpTextureOptions.Controls.Add(cboColorDistance);
            grpTextureOptions.Controls.Add(lblBitDepth);
            grpTextureOptions.Controls.Add(cboBitDepth);
            grpTextureOptions.Controls.Add(chkFillSpacing);
            grpTextureOptions.Controls.Add(chkMultiTexture);
            grpTextureOptions.Controls.Add(lblSpacing);
            grpTextureOptions.Controls.Add(txtSpacing);
            grpTextureOptions.Controls.Add(lblTextureHeight);
            grpTextureOptions.Controls.Add(txtTextureHeight);
            grpTextureOptions.Controls.Add(lblTextureWidth);
            grpTextureOptions.Controls.Add(txtTextureWidth);
            grpTextureOptions.Location = new Point(15, 322);
            grpTextureOptions.Margin = new Padding(4, 3, 4, 3);
            grpTextureOptions.Name = "grpTextureOptions";
            grpTextureOptions.Padding = new Padding(4, 3, 4, 3);
            grpTextureOptions.Size = new Size(593, 96);
            grpTextureOptions.TabIndex = 4;
            grpTextureOptions.TabStop = false;
            grpTextureOptions.Text = "Texture Options";
            // 
            // chkAutoSizeTexture
            // 
            chkAutoSizeTexture.AutoSize = true;
            chkAutoSizeTexture.Location = new Point(261, 24);
            chkAutoSizeTexture.Margin = new Padding(4, 3, 4, 3);
            chkAutoSizeTexture.Name = "chkAutoSizeTexture";
            chkAutoSizeTexture.Size = new Size(75, 19);
            chkAutoSizeTexture.TabIndex = 12;
            chkAutoSizeTexture.Text = "Auto Size";
            chkAutoSizeTexture.UseVisualStyleBackColor = true;
            chkAutoSizeTexture.CheckedChanged += chkAutoSizeTexture_CheckedChanged;
            // 
            // lblColorDistance
            // 
            lblColorDistance.AutoSize = true;
            lblColorDistance.Location = new Point(92, 57);
            lblColorDistance.Margin = new Padding(4, 0, 4, 0);
            lblColorDistance.Name = "lblColorDistance";
            lblColorDistance.Size = new Size(87, 15);
            lblColorDistance.TabIndex = 7;
            lblColorDistance.Text = "Color Distance:";
            // 
            // cboColorDistance
            // 
            cboColorDistance.DropDownStyle = ComboBoxStyle.DropDownList;
            cboColorDistance.FormattingEnabled = true;
            cboColorDistance.Location = new Point(191, 52);
            cboColorDistance.Margin = new Padding(4, 3, 4, 3);
            cboColorDistance.Name = "cboColorDistance";
            cboColorDistance.Size = new Size(115, 23);
            cboColorDistance.TabIndex = 8;
            cboColorDistance.SelectedIndexChanged += cboColorDistance_SelectedIndexChanged;
            // 
            // lblBitDepth
            // 
            lblBitDepth.AutoSize = true;
            lblBitDepth.Location = new Point(124, 27);
            lblBitDepth.Margin = new Padding(4, 0, 4, 0);
            lblBitDepth.Name = "lblBitDepth";
            lblBitDepth.Size = new Size(59, 15);
            lblBitDepth.TabIndex = 1;
            lblBitDepth.Text = "Bit Depth:";
            // 
            // cboBitDepth
            // 
            cboBitDepth.DropDownStyle = ComboBoxStyle.DropDownList;
            cboBitDepth.FormattingEnabled = true;
            cboBitDepth.Location = new Point(191, 20);
            cboBitDepth.Margin = new Padding(4, 3, 4, 3);
            cboBitDepth.Name = "cboBitDepth";
            cboBitDepth.Size = new Size(51, 23);
            cboBitDepth.TabIndex = 2;
            cboBitDepth.SelectedIndexChanged += cboBitDepth_SelectedIndexChanged;
            // 
            // chkFillSpacing
            // 
            chkFillSpacing.AutoSize = true;
            chkFillSpacing.Location = new Point(475, 57);
            chkFillSpacing.Margin = new Padding(4, 3, 4, 3);
            chkFillSpacing.Name = "chkFillSpacing";
            chkFillSpacing.Size = new Size(86, 19);
            chkFillSpacing.TabIndex = 11;
            chkFillSpacing.Text = "Fill Spacing";
            chkFillSpacing.UseVisualStyleBackColor = true;
            chkFillSpacing.CheckedChanged += chkFillSpacing_CheckedChanged;
            // 
            // chkMultiTexture
            // 
            chkMultiTexture.AutoSize = true;
            chkMultiTexture.Location = new Point(15, 25);
            chkMultiTexture.Margin = new Padding(4, 3, 4, 3);
            chkMultiTexture.Name = "chkMultiTexture";
            chkMultiTexture.Size = new Size(95, 19);
            chkMultiTexture.TabIndex = 0;
            chkMultiTexture.Text = "Multi Texture";
            chkMultiTexture.UseVisualStyleBackColor = true;
            chkMultiTexture.CheckedChanged += chkMultiTexture_CheckedChanged;
            // 
            // lblSpacing
            // 
            lblSpacing.AutoSize = true;
            lblSpacing.Location = new Point(338, 57);
            lblSpacing.Margin = new Padding(4, 0, 4, 0);
            lblSpacing.Name = "lblSpacing";
            lblSpacing.Size = new Size(52, 15);
            lblSpacing.TabIndex = 9;
            lblSpacing.Text = "Spacing:";
            // 
            // txtSpacing
            // 
            txtSpacing.Location = new Point(402, 53);
            txtSpacing.Margin = new Padding(4, 3, 4, 3);
            txtSpacing.Name = "txtSpacing";
            txtSpacing.Size = new Size(56, 23);
            txtSpacing.TabIndex = 10;
            txtSpacing.TextChanged += txtSpacing_TextChanged;
            txtSpacing.KeyPress += txtInteger_KeyPress;
            // 
            // lblTextureHeight
            // 
            lblTextureHeight.AutoSize = true;
            lblTextureHeight.Location = new Point(463, 25);
            lblTextureHeight.Margin = new Padding(4, 0, 4, 0);
            lblTextureHeight.Name = "lblTextureHeight";
            lblTextureHeight.Size = new Size(46, 15);
            lblTextureHeight.TabIndex = 5;
            lblTextureHeight.Text = "Height:";
            // 
            // txtTextureHeight
            // 
            txtTextureHeight.Location = new Point(402, 22);
            txtTextureHeight.Margin = new Padding(4, 3, 4, 3);
            txtTextureHeight.Name = "txtTextureHeight";
            txtTextureHeight.Size = new Size(56, 23);
            txtTextureHeight.TabIndex = 6;
            txtTextureHeight.TextChanged += txtTextureHeight_TextChanged;
            txtTextureHeight.KeyPress += txtInteger_KeyPress;
            // 
            // lblTextureWidth
            // 
            lblTextureWidth.AutoSize = true;
            lblTextureWidth.Location = new Point(351, 25);
            lblTextureWidth.Margin = new Padding(4, 0, 4, 0);
            lblTextureWidth.Name = "lblTextureWidth";
            lblTextureWidth.Size = new Size(42, 15);
            lblTextureWidth.TabIndex = 3;
            lblTextureWidth.Text = "Width:";
            // 
            // txtTextureWidth
            // 
            txtTextureWidth.Location = new Point(514, 22);
            txtTextureWidth.Margin = new Padding(4, 3, 4, 3);
            txtTextureWidth.Name = "txtTextureWidth";
            txtTextureWidth.Size = new Size(56, 23);
            txtTextureWidth.TabIndex = 4;
            txtTextureWidth.TextChanged += txtTextureWidth_TextChanged;
            txtTextureWidth.KeyPress += txtInteger_KeyPress;
            // 
            // butColor
            // 
            butColor.BackColor = Color.Magenta;
            butColor.Location = new Point(178, 25);
            butColor.Margin = new Padding(4, 3, 4, 3);
            butColor.Name = "butColor";
            butColor.Size = new Size(40, 24);
            butColor.TabIndex = 2;
            butColor.UseVisualStyleBackColor = false;
            butColor.Click += butColorBackground_Click;
            // 
            // rdoColorBackground
            // 
            rdoColorBackground.AutoSize = true;
            rdoColorBackground.Location = new Point(114, 28);
            rdoColorBackground.Margin = new Padding(4, 3, 4, 3);
            rdoColorBackground.Name = "rdoColorBackground";
            rdoColorBackground.Size = new Size(54, 19);
            rdoColorBackground.TabIndex = 1;
            rdoColorBackground.Text = "Color";
            rdoColorBackground.UseVisualStyleBackColor = true;
            rdoColorBackground.CheckedChanged += rdoColorBackground_CheckedChanged;
            // 
            // rdoAlphaBackground
            // 
            rdoAlphaBackground.AutoSize = true;
            rdoAlphaBackground.Checked = true;
            rdoAlphaBackground.Location = new Point(47, 28);
            rdoAlphaBackground.Margin = new Padding(4, 3, 4, 3);
            rdoAlphaBackground.Name = "rdoAlphaBackground";
            rdoAlphaBackground.Size = new Size(56, 19);
            rdoAlphaBackground.TabIndex = 0;
            rdoAlphaBackground.TabStop = true;
            rdoAlphaBackground.Text = "Alpha";
            rdoAlphaBackground.UseVisualStyleBackColor = true;
            rdoAlphaBackground.CheckedChanged += rdoAlphaBackground_CheckedChanged;
            // 
            // butGo
            // 
            butGo.Location = new Point(223, 606);
            butGo.Margin = new Padding(4, 3, 4, 3);
            butGo.Name = "butGo";
            butGo.Size = new Size(180, 37);
            butGo.TabIndex = 7;
            butGo.Text = "GO!";
            butGo.UseVisualStyleBackColor = true;
            butGo.Click += butGo_Click;
            // 
            // grpImageOptions
            // 
            grpImageOptions.Controls.Add(chkRemapPalette);
            grpImageOptions.Controls.Add(chkPaletteSlotAddIndex);
            grpImageOptions.Controls.Add(cboColorCount);
            grpImageOptions.Controls.Add(lblColors);
            grpImageOptions.Controls.Add(nudPaletteSlot);
            grpImageOptions.Controls.Add(chkAutoPaletteSlot);
            grpImageOptions.Controls.Add(chkQuantize);
            grpImageOptions.Controls.Add(lblPaletteSlot);
            grpImageOptions.Controls.Add(chkTrimBackground);
            grpImageOptions.Location = new Point(15, 497);
            grpImageOptions.Margin = new Padding(4, 3, 4, 3);
            grpImageOptions.Name = "grpImageOptions";
            grpImageOptions.Padding = new Padding(4, 3, 4, 3);
            grpImageOptions.Size = new Size(593, 92);
            grpImageOptions.TabIndex = 6;
            grpImageOptions.TabStop = false;
            grpImageOptions.Text = "Image Options";
            // 
            // chkRemapPalette
            // 
            chkRemapPalette.AutoSize = true;
            chkRemapPalette.Location = new Point(20, 51);
            chkRemapPalette.Margin = new Padding(4, 3, 4, 3);
            chkRemapPalette.Name = "chkRemapPalette";
            chkRemapPalette.Size = new Size(102, 19);
            chkRemapPalette.TabIndex = 2;
            chkRemapPalette.Text = "Remap Palette";
            chkRemapPalette.UseVisualStyleBackColor = true;
            chkRemapPalette.CheckedChanged += chkRemapPalette_CheckedChanged;
            // 
            // chkPaletteSlotAddIndex
            // 
            chkPaletteSlotAddIndex.AutoSize = true;
            chkPaletteSlotAddIndex.Location = new Point(498, 54);
            chkPaletteSlotAddIndex.Margin = new Padding(4, 3, 4, 3);
            chkPaletteSlotAddIndex.Name = "chkPaletteSlotAddIndex";
            chkPaletteSlotAddIndex.Size = new Size(79, 19);
            chkPaletteSlotAddIndex.TabIndex = 7;
            chkPaletteSlotAddIndex.Text = "Add Index";
            chkPaletteSlotAddIndex.UseVisualStyleBackColor = true;
            chkPaletteSlotAddIndex.CheckedChanged += chkPaletteSlotAddIndex_CheckedChanged;
            // 
            // cboColorCount
            // 
            cboColorCount.DropDownStyle = ComboBoxStyle.DropDownList;
            cboColorCount.FormattingEnabled = true;
            cboColorCount.Location = new Point(217, 48);
            cboColorCount.Margin = new Padding(4, 3, 4, 3);
            cboColorCount.Name = "cboColorCount";
            cboColorCount.Size = new Size(65, 23);
            cboColorCount.TabIndex = 2;
            cboColorCount.SelectedIndexChanged += cboColorCount_SelectedIndexChanged;
            // 
            // lblColors
            // 
            lblColors.AutoSize = true;
            lblColors.Location = new Point(289, 54);
            lblColors.Margin = new Padding(4, 0, 4, 0);
            lblColors.Name = "lblColors";
            lblColors.Size = new Size(41, 15);
            lblColors.TabIndex = 3;
            lblColors.Text = "Colors";
            // 
            // nudPaletteSlot
            // 
            nudPaletteSlot.Location = new Point(404, 50);
            nudPaletteSlot.Margin = new Padding(4, 3, 4, 3);
            nudPaletteSlot.Maximum = new decimal(new int[] { 15, 0, 0, 0 });
            nudPaletteSlot.Name = "nudPaletteSlot";
            nudPaletteSlot.Size = new Size(74, 23);
            nudPaletteSlot.TabIndex = 5;
            nudPaletteSlot.ValueChanged += nudPaletteSlot_ValueChanged;
            // 
            // chkAutoPaletteSlot
            // 
            chkAutoPaletteSlot.AutoSize = true;
            chkAutoPaletteSlot.Location = new Point(498, 25);
            chkAutoPaletteSlot.Margin = new Padding(4, 3, 4, 3);
            chkAutoPaletteSlot.Name = "chkAutoPaletteSlot";
            chkAutoPaletteSlot.Size = new Size(52, 19);
            chkAutoPaletteSlot.TabIndex = 6;
            chkAutoPaletteSlot.Text = "Auto";
            chkAutoPaletteSlot.UseVisualStyleBackColor = true;
            chkAutoPaletteSlot.CheckedChanged += chkAutoPaletteSlot_CheckedChanged;
            // 
            // chkQuantize
            // 
            chkQuantize.AutoSize = true;
            chkQuantize.Location = new Point(217, 25);
            chkQuantize.Margin = new Padding(4, 3, 4, 3);
            chkQuantize.Name = "chkQuantize";
            chkQuantize.Size = new Size(73, 19);
            chkQuantize.TabIndex = 1;
            chkQuantize.Text = "Quantize";
            chkQuantize.UseVisualStyleBackColor = true;
            chkQuantize.CheckedChanged += chkQuantize_CheckedChanged;
            // 
            // lblPaletteSlot
            // 
            lblPaletteSlot.AutoSize = true;
            lblPaletteSlot.Location = new Point(402, 27);
            lblPaletteSlot.Margin = new Padding(4, 0, 4, 0);
            lblPaletteSlot.Name = "lblPaletteSlot";
            lblPaletteSlot.Size = new Size(69, 15);
            lblPaletteSlot.TabIndex = 4;
            lblPaletteSlot.Text = "Palette Slot:";
            // 
            // chkTrimBackground
            // 
            chkTrimBackground.AutoSize = true;
            chkTrimBackground.Location = new Point(20, 25);
            chkTrimBackground.Margin = new Padding(4, 3, 4, 3);
            chkTrimBackground.Name = "chkTrimBackground";
            chkTrimBackground.Size = new Size(117, 19);
            chkTrimBackground.TabIndex = 0;
            chkTrimBackground.Text = "Trim Background";
            chkTrimBackground.UseVisualStyleBackColor = true;
            chkTrimBackground.CheckedChanged += chkTrimBackground_CheckedChanged;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuFile, mnuTools });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(622, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            mnuFile.DropDownItems.AddRange(new ToolStripItem[] { mnuOpen, mnuSave, mnuSaveAs, toolStripMenuItem1, mnuExit });
            mnuFile.Name = "mnuFile";
            mnuFile.Size = new Size(37, 20);
            mnuFile.Text = "File";
            // 
            // mnuOpen
            // 
            mnuOpen.Name = "mnuOpen";
            mnuOpen.Size = new Size(123, 22);
            mnuOpen.Text = "Open";
            mnuOpen.Click += mnuOpen_Click;
            // 
            // mnuSave
            // 
            mnuSave.Name = "mnuSave";
            mnuSave.Size = new Size(123, 22);
            mnuSave.Text = "Save";
            mnuSave.Click += mnuSave_Click;
            // 
            // mnuSaveAs
            // 
            mnuSaveAs.Name = "mnuSaveAs";
            mnuSaveAs.Size = new Size(123, 22);
            mnuSaveAs.Text = "Save As...";
            mnuSaveAs.Click += mnuSaveAs_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(120, 6);
            // 
            // mnuExit
            // 
            mnuExit.Name = "mnuExit";
            mnuExit.Size = new Size(123, 22);
            mnuExit.Text = "Exit";
            mnuExit.Click += mnuExit_Click;
            // 
            // mnuTools
            // 
            mnuTools.DropDownItems.AddRange(new ToolStripItem[] { mnuSpriteSheetSlicer, mnuSpriteSheetStripper });
            mnuTools.Name = "mnuTools";
            mnuTools.Size = new Size(47, 20);
            mnuTools.Text = "Tools";
            // 
            // mnuSpriteSheetSlicer
            // 
            mnuSpriteSheetSlicer.Name = "mnuSpriteSheetSlicer";
            mnuSpriteSheetSlicer.Size = new Size(180, 22);
            mnuSpriteSheetSlicer.Text = "Sprite Sheet Slicer";
            mnuSpriteSheetSlicer.Click += mnuSpriteSheetSlicer_Click;
            // 
            // mnuSpriteSheetStripper
            // 
            mnuSpriteSheetStripper.Name = "mnuSpriteSheetStripper";
            mnuSpriteSheetStripper.Size = new Size(180, 22);
            mnuSpriteSheetStripper.Text = "Sprite Sheet Stripper";
            mnuSpriteSheetStripper.Click += mnuSpriteSheetStripper_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, tspbProgress });
            statusStrip1.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            statusStrip1.Location = new Point(0, 660);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 16, 0);
            statusStrip1.Size = new Size(622, 24);
            statusStrip1.SizingGrip = false;
            statusStrip1.TabIndex = 9;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(0, 19);
            // 
            // tspbProgress
            // 
            tspbProgress.Alignment = ToolStripItemAlignment.Right;
            tspbProgress.Name = "tspbProgress";
            tspbProgress.Size = new Size(117, 18);
            // 
            // grpOutputOptions
            // 
            grpOutputOptions.Controls.Add(cboFileFormat);
            grpOutputOptions.Controls.Add(lblOutputFolder);
            grpOutputOptions.Controls.Add(butOutputFolder);
            grpOutputOptions.Controls.Add(txtOutputFolder);
            grpOutputOptions.Controls.Add(lblFileFormat);
            grpOutputOptions.Controls.Add(txtName);
            grpOutputOptions.Controls.Add(lblName);
            grpOutputOptions.Location = new Point(15, 210);
            grpOutputOptions.Margin = new Padding(4, 3, 4, 3);
            grpOutputOptions.Name = "grpOutputOptions";
            grpOutputOptions.Padding = new Padding(4, 3, 4, 3);
            grpOutputOptions.Size = new Size(593, 105);
            grpOutputOptions.TabIndex = 3;
            grpOutputOptions.TabStop = false;
            grpOutputOptions.Text = "Output Options";
            // 
            // cboFileFormat
            // 
            cboFileFormat.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFileFormat.FormattingEnabled = true;
            cboFileFormat.Location = new Point(386, 22);
            cboFileFormat.Margin = new Padding(4, 3, 4, 3);
            cboFileFormat.Name = "cboFileFormat";
            cboFileFormat.Size = new Size(124, 23);
            cboFileFormat.TabIndex = 3;
            cboFileFormat.SelectedIndexChanged += cboFileFormat_SelectedIndexChanged;
            // 
            // lblOutputFolder
            // 
            lblOutputFolder.AutoSize = true;
            lblOutputFolder.Location = new Point(12, 62);
            lblOutputFolder.Margin = new Padding(4, 0, 4, 0);
            lblOutputFolder.Name = "lblOutputFolder";
            lblOutputFolder.Size = new Size(43, 15);
            lblOutputFolder.TabIndex = 4;
            lblOutputFolder.Text = "Folder:";
            // 
            // butOutputFolder
            // 
            butOutputFolder.Location = new Point(526, 59);
            butOutputFolder.Margin = new Padding(4, 3, 4, 3);
            butOutputFolder.Name = "butOutputFolder";
            butOutputFolder.Size = new Size(46, 23);
            butOutputFolder.TabIndex = 6;
            butOutputFolder.Text = "...";
            butOutputFolder.UseVisualStyleBackColor = true;
            butOutputFolder.Click += butOutputFolder_Click;
            // 
            // txtOutputFolder
            // 
            txtOutputFolder.Location = new Point(64, 59);
            txtOutputFolder.Margin = new Padding(4, 3, 4, 3);
            txtOutputFolder.Name = "txtOutputFolder";
            txtOutputFolder.Size = new Size(450, 23);
            txtOutputFolder.TabIndex = 5;
            txtOutputFolder.TextAlign = HorizontalAlignment.Right;
            txtOutputFolder.TextChanged += txtOutputFolder_TextChanged;
            // 
            // lblFileFormat
            // 
            lblFileFormat.AutoSize = true;
            lblFileFormat.Location = new Point(304, 28);
            lblFileFormat.Margin = new Padding(4, 0, 4, 0);
            lblFileFormat.Name = "lblFileFormat";
            lblFileFormat.Size = new Size(69, 15);
            lblFileFormat.TabIndex = 2;
            lblFileFormat.Text = "File Format:";
            // 
            // txtName
            // 
            txtName.Location = new Point(64, 24);
            txtName.Margin = new Padding(4, 3, 4, 3);
            txtName.Name = "txtName";
            txtName.Size = new Size(231, 23);
            txtName.TabIndex = 1;
            txtName.TextChanged += txtName_TextChanged;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(13, 28);
            lblName.Margin = new Padding(4, 0, 4, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(42, 15);
            lblName.TabIndex = 0;
            lblName.Text = "Name:";
            // 
            // grpInputPalette
            // 
            grpInputPalette.Controls.Add(butInputPalette);
            grpInputPalette.Controls.Add(txtInputPalette);
            grpInputPalette.Location = new Point(14, 135);
            grpInputPalette.Margin = new Padding(4, 3, 4, 3);
            grpInputPalette.Name = "grpInputPalette";
            grpInputPalette.Padding = new Padding(4, 3, 4, 3);
            grpInputPalette.Size = new Size(593, 68);
            grpInputPalette.TabIndex = 2;
            grpInputPalette.TabStop = false;
            grpInputPalette.Text = "Input Palette";
            // 
            // butInputPalette
            // 
            butInputPalette.Location = new Point(524, 27);
            butInputPalette.Margin = new Padding(4, 3, 4, 3);
            butInputPalette.Name = "butInputPalette";
            butInputPalette.Size = new Size(46, 23);
            butInputPalette.TabIndex = 1;
            butInputPalette.Text = "...";
            butInputPalette.UseVisualStyleBackColor = true;
            butInputPalette.Click += butInputPalette_Click;
            // 
            // txtInputPalette
            // 
            txtInputPalette.Location = new Point(20, 27);
            txtInputPalette.Margin = new Padding(4, 3, 4, 3);
            txtInputPalette.Name = "txtInputPalette";
            txtInputPalette.Size = new Size(492, 23);
            txtInputPalette.TabIndex = 0;
            txtInputPalette.TextAlign = HorizontalAlignment.Right;
            txtInputPalette.TextChanged += txtInputPalette_TextChanged;
            // 
            // grpBackgroundOptions
            // 
            grpBackgroundOptions.Controls.Add(chkReplaceBackgroundColor);
            grpBackgroundOptions.Controls.Add(rdoIndexBackground);
            grpBackgroundOptions.Controls.Add(butColor);
            grpBackgroundOptions.Controls.Add(txtBackgroundIndex);
            grpBackgroundOptions.Controls.Add(rdoAlphaBackground);
            grpBackgroundOptions.Controls.Add(rdoColorBackground);
            grpBackgroundOptions.Location = new Point(15, 425);
            grpBackgroundOptions.Margin = new Padding(4, 3, 4, 3);
            grpBackgroundOptions.Name = "grpBackgroundOptions";
            grpBackgroundOptions.Padding = new Padding(4, 3, 4, 3);
            grpBackgroundOptions.Size = new Size(593, 66);
            grpBackgroundOptions.TabIndex = 5;
            grpBackgroundOptions.TabStop = false;
            grpBackgroundOptions.Text = "Background Options";
            // 
            // chkReplaceBackgroundColor
            // 
            chkReplaceBackgroundColor.AutoSize = true;
            chkReplaceBackgroundColor.Location = new Point(384, 29);
            chkReplaceBackgroundColor.Margin = new Padding(4, 3, 4, 3);
            chkReplaceBackgroundColor.Name = "chkReplaceBackgroundColor";
            chkReplaceBackgroundColor.Size = new Size(166, 19);
            chkReplaceBackgroundColor.TabIndex = 8;
            chkReplaceBackgroundColor.Text = "Replace Background Color";
            chkReplaceBackgroundColor.UseVisualStyleBackColor = true;
            chkReplaceBackgroundColor.CheckedChanged += chkReplaceBackgroundColor_CheckedChanged;
            // 
            // rdoIndexBackground
            // 
            rdoIndexBackground.AutoSize = true;
            rdoIndexBackground.Location = new Point(233, 28);
            rdoIndexBackground.Margin = new Padding(4, 3, 4, 3);
            rdoIndexBackground.Name = "rdoIndexBackground";
            rdoIndexBackground.Size = new Size(53, 19);
            rdoIndexBackground.TabIndex = 3;
            rdoIndexBackground.Text = "Index";
            rdoIndexBackground.UseVisualStyleBackColor = true;
            rdoIndexBackground.CheckedChanged += rdoIndexBackground_CheckedChanged;
            // 
            // txtBackgroundIndex
            // 
            txtBackgroundIndex.Location = new Point(300, 27);
            txtBackgroundIndex.Margin = new Padding(4, 3, 4, 3);
            txtBackgroundIndex.Name = "txtBackgroundIndex";
            txtBackgroundIndex.Size = new Size(73, 23);
            txtBackgroundIndex.TabIndex = 4;
            txtBackgroundIndex.TextChanged += txtBackgroundIndex_TextChanged;
            // 
            // lblbaker76
            // 
            lblbaker76.AutoSize = true;
            lblbaker76.Cursor = Cursors.Hand;
            lblbaker76.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Underline, GraphicsUnit.Point, 0);
            lblbaker76.ForeColor = SystemColors.Highlight;
            lblbaker76.Location = new Point(526, 628);
            lblbaker76.Margin = new Padding(4, 0, 4, 0);
            lblbaker76.Name = "lblbaker76";
            lblbaker76.Size = new Size(69, 13);
            lblbaker76.TabIndex = 8;
            lblbaker76.Text = "baker76.com";
            lblbaker76.Click += lblbaker76_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(622, 684);
            Controls.Add(lblbaker76);
            Controls.Add(grpBackgroundOptions);
            Controls.Add(grpInputPalette);
            Controls.Add(grpFolders);
            Controls.Add(grpTextureOptions);
            Controls.Add(grpOutputOptions);
            Controls.Add(statusStrip1);
            Controls.Add(grpImageOptions);
            Controls.Add(butGo);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Crunchy v[VERSION]";
            FormClosing += frmMain_FormClosing;
            Load += frmMain_Load;
            grpFolders.ResumeLayout(false);
            grpFolders.PerformLayout();
            grpTextureOptions.ResumeLayout(false);
            grpTextureOptions.PerformLayout();
            grpImageOptions.ResumeLayout(false);
            grpImageOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPaletteSlot).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            grpOutputOptions.ResumeLayout(false);
            grpOutputOptions.PerformLayout();
            grpInputPalette.ResumeLayout(false);
            grpInputPalette.PerformLayout();
            grpBackgroundOptions.ResumeLayout(false);
            grpBackgroundOptions.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpFolders;
        private System.Windows.Forms.Button butInputFolder;
        private System.Windows.Forms.TextBox txtInputFolder;
        private System.Windows.Forms.GroupBox grpTextureOptions;
        private System.Windows.Forms.Button butGo;
        private System.Windows.Forms.Label lblTextureWidth;
        private System.Windows.Forms.TextBox txtTextureWidth;
        private System.Windows.Forms.Label lblTextureHeight;
        private System.Windows.Forms.TextBox txtTextureHeight;
        private System.Windows.Forms.Label lblSpacing;
        private System.Windows.Forms.TextBox txtSpacing;
        private System.Windows.Forms.GroupBox grpImageOptions;
        private System.Windows.Forms.CheckBox chkRecursive;
        private System.Windows.Forms.Button butColor;
        private System.Windows.Forms.RadioButton rdoColorBackground;
        private System.Windows.Forms.RadioButton rdoAlphaBackground;
        private System.Windows.Forms.CheckBox chkMultiTexture;
        private System.Windows.Forms.CheckBox chkFillSpacing;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem mnuTools;
        private System.Windows.Forms.ToolStripMenuItem mnuSpriteSheetSlicer;
        private System.Windows.Forms.GroupBox grpOutputOptions;
        private System.Windows.Forms.Label lblFileFormat;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ComboBox cboInputFolder;
        private System.Windows.Forms.CheckBox chkTrimBackground;
        private System.Windows.Forms.ComboBox cboBitDepth;
        private System.Windows.Forms.Label lblBitDepth;
        private System.Windows.Forms.GroupBox grpInputPalette;
        private System.Windows.Forms.Button butInputPalette;
        private System.Windows.Forms.TextBox txtInputPalette;
        private System.Windows.Forms.GroupBox grpBackgroundOptions;
        private System.Windows.Forms.RadioButton rdoIndexBackground;
        private System.Windows.Forms.TextBox txtBackgroundIndex;
        private System.Windows.Forms.Label lblColorDistance;
        private System.Windows.Forms.ComboBox cboColorDistance;
        private System.Windows.Forms.Label lblOutputFolder;
        private System.Windows.Forms.Button butOutputFolder;
        private System.Windows.Forms.TextBox txtOutputFolder;
        private System.Windows.Forms.Label lblbaker76;
        private System.Windows.Forms.ComboBox cboFileFormat;
        private System.Windows.Forms.Label lblPaletteSlot;
        private System.Windows.Forms.CheckBox chkQuantize;
        private System.Windows.Forms.Label lblColors;
        private System.Windows.Forms.NumericUpDown nudPaletteSlot;
        private System.Windows.Forms.CheckBox chkAutoPaletteSlot;
        private System.Windows.Forms.ComboBox cboColorCount;
        private System.Windows.Forms.CheckBox chkPaletteSlotAddIndex;
        private System.Windows.Forms.ToolStripProgressBar tspbProgress;
        private System.Windows.Forms.CheckBox chkAutoSizeTexture;
        private System.Windows.Forms.CheckBox chkReplaceBackgroundColor;
        private System.Windows.Forms.CheckBox chkRemapPalette;
        private ToolStripMenuItem mnuSpriteSheetStripper;
    }
}

