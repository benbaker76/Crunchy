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
            this.grpFolders = new System.Windows.Forms.GroupBox();
            this.cboInputFolder = new System.Windows.Forms.ComboBox();
            this.chkRecursive = new System.Windows.Forms.CheckBox();
            this.butInputFolder = new System.Windows.Forms.Button();
            this.txtInputFolder = new System.Windows.Forms.TextBox();
            this.grpTextureOptions = new System.Windows.Forms.GroupBox();
            this.chkAutoSizeTexture = new System.Windows.Forms.CheckBox();
            this.lblColorDistance = new System.Windows.Forms.Label();
            this.cboColorDistance = new System.Windows.Forms.ComboBox();
            this.lblBitDepth = new System.Windows.Forms.Label();
            this.cboBitDepth = new System.Windows.Forms.ComboBox();
            this.chkFillSpacing = new System.Windows.Forms.CheckBox();
            this.chkMultiTexture = new System.Windows.Forms.CheckBox();
            this.lblSpacing = new System.Windows.Forms.Label();
            this.txtSpacing = new System.Windows.Forms.TextBox();
            this.lblTextureHeight = new System.Windows.Forms.Label();
            this.txtTextureHeight = new System.Windows.Forms.TextBox();
            this.lblTextureWidth = new System.Windows.Forms.Label();
            this.txtTextureWidth = new System.Windows.Forms.TextBox();
            this.butColor = new System.Windows.Forms.Button();
            this.rdoColorBackground = new System.Windows.Forms.RadioButton();
            this.rdoAlphaBackground = new System.Windows.Forms.RadioButton();
            this.butGo = new System.Windows.Forms.Button();
            this.grpImageOptions = new System.Windows.Forms.GroupBox();
            this.chkPaletteSlotAddIndex = new System.Windows.Forms.CheckBox();
            this.cboColorCount = new System.Windows.Forms.ComboBox();
            this.lblColors = new System.Windows.Forms.Label();
            this.nudPaletteSlot = new System.Windows.Forms.NumericUpDown();
            this.chkAutoPaletteSlot = new System.Windows.Forms.CheckBox();
            this.chkQuantize = new System.Windows.Forms.CheckBox();
            this.lblPaletteSlot = new System.Windows.Forms.Label();
            this.chkTrimBackground = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSpriteSheetSlicer = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspbProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.grpOutputOptions = new System.Windows.Forms.GroupBox();
            this.cboFileFormat = new System.Windows.Forms.ComboBox();
            this.lblOutputFolder = new System.Windows.Forms.Label();
            this.butOutputFolder = new System.Windows.Forms.Button();
            this.txtOutputFolder = new System.Windows.Forms.TextBox();
            this.lblFileFormat = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.grpInputPalette = new System.Windows.Forms.GroupBox();
            this.butInputPalette = new System.Windows.Forms.Button();
            this.txtInputPalette = new System.Windows.Forms.TextBox();
            this.grpBackgroundOptions = new System.Windows.Forms.GroupBox();
            this.chkReplaceBackgroundColor = new System.Windows.Forms.CheckBox();
            this.rdoIndexBackground = new System.Windows.Forms.RadioButton();
            this.txtBackgroundIndex = new System.Windows.Forms.TextBox();
            this.lblbaker76 = new System.Windows.Forms.Label();
            this.chkRemapPalette = new System.Windows.Forms.CheckBox();
            this.grpFolders.SuspendLayout();
            this.grpTextureOptions.SuspendLayout();
            this.grpImageOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPaletteSlot)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.grpOutputOptions.SuspendLayout();
            this.grpInputPalette.SuspendLayout();
            this.grpBackgroundOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpFolders
            // 
            this.grpFolders.Controls.Add(this.cboInputFolder);
            this.grpFolders.Controls.Add(this.chkRecursive);
            this.grpFolders.Controls.Add(this.butInputFolder);
            this.grpFolders.Controls.Add(this.txtInputFolder);
            this.grpFolders.Location = new System.Drawing.Point(12, 27);
            this.grpFolders.Name = "grpFolders";
            this.grpFolders.Size = new System.Drawing.Size(508, 84);
            this.grpFolders.TabIndex = 1;
            this.grpFolders.TabStop = false;
            this.grpFolders.Text = "Input Folder(s)";
            // 
            // cboInputFolder
            // 
            this.cboInputFolder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInputFolder.FormattingEnabled = true;
            this.cboInputFolder.Location = new System.Drawing.Point(17, 22);
            this.cboInputFolder.Name = "cboInputFolder";
            this.cboInputFolder.Size = new System.Drawing.Size(74, 21);
            this.cboInputFolder.TabIndex = 0;
            this.cboInputFolder.SelectedIndexChanged += new System.EventHandler(this.cboInputFolder_SelectedIndexChanged);
            // 
            // chkRecursive
            // 
            this.chkRecursive.AutoSize = true;
            this.chkRecursive.Location = new System.Drawing.Point(17, 54);
            this.chkRecursive.Name = "chkRecursive";
            this.chkRecursive.Size = new System.Drawing.Size(156, 17);
            this.chkRecursive.TabIndex = 3;
            this.chkRecursive.Text = "Recursive Directory Search";
            this.chkRecursive.UseVisualStyleBackColor = true;
            this.chkRecursive.CheckedChanged += new System.EventHandler(this.chkRecursive_CheckedChanged);
            // 
            // butInputFolder
            // 
            this.butInputFolder.Location = new System.Drawing.Point(449, 23);
            this.butInputFolder.Name = "butInputFolder";
            this.butInputFolder.Size = new System.Drawing.Size(39, 20);
            this.butInputFolder.TabIndex = 2;
            this.butInputFolder.Text = "...";
            this.butInputFolder.UseVisualStyleBackColor = true;
            this.butInputFolder.Click += new System.EventHandler(this.butInputFolder_Click);
            // 
            // txtInputFolder
            // 
            this.txtInputFolder.Location = new System.Drawing.Point(97, 23);
            this.txtInputFolder.Name = "txtInputFolder";
            this.txtInputFolder.Size = new System.Drawing.Size(342, 20);
            this.txtInputFolder.TabIndex = 1;
            this.txtInputFolder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInputFolder.TextChanged += new System.EventHandler(this.txtInputFolder_TextChanged);
            // 
            // grpTextureOptions
            // 
            this.grpTextureOptions.Controls.Add(this.chkAutoSizeTexture);
            this.grpTextureOptions.Controls.Add(this.lblColorDistance);
            this.grpTextureOptions.Controls.Add(this.cboColorDistance);
            this.grpTextureOptions.Controls.Add(this.lblBitDepth);
            this.grpTextureOptions.Controls.Add(this.cboBitDepth);
            this.grpTextureOptions.Controls.Add(this.chkFillSpacing);
            this.grpTextureOptions.Controls.Add(this.chkMultiTexture);
            this.grpTextureOptions.Controls.Add(this.lblSpacing);
            this.grpTextureOptions.Controls.Add(this.txtSpacing);
            this.grpTextureOptions.Controls.Add(this.lblTextureHeight);
            this.grpTextureOptions.Controls.Add(this.txtTextureHeight);
            this.grpTextureOptions.Controls.Add(this.lblTextureWidth);
            this.grpTextureOptions.Controls.Add(this.txtTextureWidth);
            this.grpTextureOptions.Location = new System.Drawing.Point(13, 279);
            this.grpTextureOptions.Name = "grpTextureOptions";
            this.grpTextureOptions.Size = new System.Drawing.Size(508, 83);
            this.grpTextureOptions.TabIndex = 4;
            this.grpTextureOptions.TabStop = false;
            this.grpTextureOptions.Text = "Texture Options";
            // 
            // chkAutoSizeTexture
            // 
            this.chkAutoSizeTexture.AutoSize = true;
            this.chkAutoSizeTexture.Location = new System.Drawing.Point(224, 21);
            this.chkAutoSizeTexture.Name = "chkAutoSizeTexture";
            this.chkAutoSizeTexture.Size = new System.Drawing.Size(71, 17);
            this.chkAutoSizeTexture.TabIndex = 12;
            this.chkAutoSizeTexture.Text = "Auto Size";
            this.chkAutoSizeTexture.UseVisualStyleBackColor = true;
            this.chkAutoSizeTexture.CheckedChanged += new System.EventHandler(this.chkAutoSizeTexture_CheckedChanged);
            // 
            // lblColorDistance
            // 
            this.lblColorDistance.AutoSize = true;
            this.lblColorDistance.Location = new System.Drawing.Point(79, 49);
            this.lblColorDistance.Name = "lblColorDistance";
            this.lblColorDistance.Size = new System.Drawing.Size(79, 13);
            this.lblColorDistance.TabIndex = 7;
            this.lblColorDistance.Text = "Color Distance:";
            // 
            // cboColorDistance
            // 
            this.cboColorDistance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboColorDistance.FormattingEnabled = true;
            this.cboColorDistance.Location = new System.Drawing.Point(164, 45);
            this.cboColorDistance.Name = "cboColorDistance";
            this.cboColorDistance.Size = new System.Drawing.Size(99, 21);
            this.cboColorDistance.TabIndex = 8;
            this.cboColorDistance.SelectedIndexChanged += new System.EventHandler(this.cboColorDistance_SelectedIndexChanged);
            // 
            // lblBitDepth
            // 
            this.lblBitDepth.AutoSize = true;
            this.lblBitDepth.Location = new System.Drawing.Point(106, 23);
            this.lblBitDepth.Name = "lblBitDepth";
            this.lblBitDepth.Size = new System.Drawing.Size(54, 13);
            this.lblBitDepth.TabIndex = 1;
            this.lblBitDepth.Text = "Bit Depth:";
            // 
            // cboBitDepth
            // 
            this.cboBitDepth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBitDepth.FormattingEnabled = true;
            this.cboBitDepth.Location = new System.Drawing.Point(164, 17);
            this.cboBitDepth.Name = "cboBitDepth";
            this.cboBitDepth.Size = new System.Drawing.Size(44, 21);
            this.cboBitDepth.TabIndex = 2;
            this.cboBitDepth.SelectedIndexChanged += new System.EventHandler(this.cboBitDepth_SelectedIndexChanged);
            // 
            // chkFillSpacing
            // 
            this.chkFillSpacing.AutoSize = true;
            this.chkFillSpacing.Location = new System.Drawing.Point(407, 49);
            this.chkFillSpacing.Name = "chkFillSpacing";
            this.chkFillSpacing.Size = new System.Drawing.Size(80, 17);
            this.chkFillSpacing.TabIndex = 11;
            this.chkFillSpacing.Text = "Fill Spacing";
            this.chkFillSpacing.UseVisualStyleBackColor = true;
            this.chkFillSpacing.CheckedChanged += new System.EventHandler(this.chkFillSpacing_CheckedChanged);
            // 
            // chkMultiTexture
            // 
            this.chkMultiTexture.AutoSize = true;
            this.chkMultiTexture.Location = new System.Drawing.Point(13, 22);
            this.chkMultiTexture.Name = "chkMultiTexture";
            this.chkMultiTexture.Size = new System.Drawing.Size(87, 17);
            this.chkMultiTexture.TabIndex = 0;
            this.chkMultiTexture.Text = "Multi Texture";
            this.chkMultiTexture.UseVisualStyleBackColor = true;
            this.chkMultiTexture.CheckedChanged += new System.EventHandler(this.chkMultiTexture_CheckedChanged);
            // 
            // lblSpacing
            // 
            this.lblSpacing.AutoSize = true;
            this.lblSpacing.Location = new System.Drawing.Point(290, 49);
            this.lblSpacing.Name = "lblSpacing";
            this.lblSpacing.Size = new System.Drawing.Size(49, 13);
            this.lblSpacing.TabIndex = 9;
            this.lblSpacing.Text = "Spacing:";
            // 
            // txtSpacing
            // 
            this.txtSpacing.Location = new System.Drawing.Point(345, 46);
            this.txtSpacing.Name = "txtSpacing";
            this.txtSpacing.Size = new System.Drawing.Size(49, 20);
            this.txtSpacing.TabIndex = 10;
            this.txtSpacing.TextChanged += new System.EventHandler(this.txtSpacing_TextChanged);
            this.txtSpacing.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInteger_KeyPress);
            // 
            // lblTextureHeight
            // 
            this.lblTextureHeight.AutoSize = true;
            this.lblTextureHeight.Location = new System.Drawing.Point(397, 22);
            this.lblTextureHeight.Name = "lblTextureHeight";
            this.lblTextureHeight.Size = new System.Drawing.Size(41, 13);
            this.lblTextureHeight.TabIndex = 5;
            this.lblTextureHeight.Text = "Height:";
            // 
            // txtTextureHeight
            // 
            this.txtTextureHeight.Location = new System.Drawing.Point(345, 19);
            this.txtTextureHeight.Name = "txtTextureHeight";
            this.txtTextureHeight.Size = new System.Drawing.Size(49, 20);
            this.txtTextureHeight.TabIndex = 6;
            this.txtTextureHeight.TextChanged += new System.EventHandler(this.txtTextureHeight_TextChanged);
            this.txtTextureHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInteger_KeyPress);
            // 
            // lblTextureWidth
            // 
            this.lblTextureWidth.AutoSize = true;
            this.lblTextureWidth.Location = new System.Drawing.Point(301, 22);
            this.lblTextureWidth.Name = "lblTextureWidth";
            this.lblTextureWidth.Size = new System.Drawing.Size(38, 13);
            this.lblTextureWidth.TabIndex = 3;
            this.lblTextureWidth.Text = "Width:";
            // 
            // txtTextureWidth
            // 
            this.txtTextureWidth.Location = new System.Drawing.Point(441, 19);
            this.txtTextureWidth.Name = "txtTextureWidth";
            this.txtTextureWidth.Size = new System.Drawing.Size(49, 20);
            this.txtTextureWidth.TabIndex = 4;
            this.txtTextureWidth.TextChanged += new System.EventHandler(this.txtTextureWidth_TextChanged);
            this.txtTextureWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInteger_KeyPress);
            // 
            // butColor
            // 
            this.butColor.BackColor = System.Drawing.Color.Magenta;
            this.butColor.Location = new System.Drawing.Point(153, 22);
            this.butColor.Name = "butColor";
            this.butColor.Size = new System.Drawing.Size(34, 21);
            this.butColor.TabIndex = 2;
            this.butColor.UseVisualStyleBackColor = false;
            this.butColor.Click += new System.EventHandler(this.butColorBackground_Click);
            // 
            // rdoColorBackground
            // 
            this.rdoColorBackground.AutoSize = true;
            this.rdoColorBackground.Location = new System.Drawing.Point(98, 24);
            this.rdoColorBackground.Name = "rdoColorBackground";
            this.rdoColorBackground.Size = new System.Drawing.Size(49, 17);
            this.rdoColorBackground.TabIndex = 1;
            this.rdoColorBackground.Text = "Color";
            this.rdoColorBackground.UseVisualStyleBackColor = true;
            this.rdoColorBackground.CheckedChanged += new System.EventHandler(this.rdoColorBackground_CheckedChanged);
            // 
            // rdoAlphaBackground
            // 
            this.rdoAlphaBackground.AutoSize = true;
            this.rdoAlphaBackground.Checked = true;
            this.rdoAlphaBackground.Location = new System.Drawing.Point(40, 24);
            this.rdoAlphaBackground.Name = "rdoAlphaBackground";
            this.rdoAlphaBackground.Size = new System.Drawing.Size(52, 17);
            this.rdoAlphaBackground.TabIndex = 0;
            this.rdoAlphaBackground.TabStop = true;
            this.rdoAlphaBackground.Text = "Alpha";
            this.rdoAlphaBackground.UseVisualStyleBackColor = true;
            this.rdoAlphaBackground.CheckedChanged += new System.EventHandler(this.rdoAlphaBackground_CheckedChanged);
            // 
            // butGo
            // 
            this.butGo.Location = new System.Drawing.Point(191, 525);
            this.butGo.Name = "butGo";
            this.butGo.Size = new System.Drawing.Size(154, 32);
            this.butGo.TabIndex = 7;
            this.butGo.Text = "GO!";
            this.butGo.UseVisualStyleBackColor = true;
            this.butGo.Click += new System.EventHandler(this.butGo_Click);
            // 
            // grpImageOptions
            // 
            this.grpImageOptions.Controls.Add(this.chkRemapPalette);
            this.grpImageOptions.Controls.Add(this.chkPaletteSlotAddIndex);
            this.grpImageOptions.Controls.Add(this.cboColorCount);
            this.grpImageOptions.Controls.Add(this.lblColors);
            this.grpImageOptions.Controls.Add(this.nudPaletteSlot);
            this.grpImageOptions.Controls.Add(this.chkAutoPaletteSlot);
            this.grpImageOptions.Controls.Add(this.chkQuantize);
            this.grpImageOptions.Controls.Add(this.lblPaletteSlot);
            this.grpImageOptions.Controls.Add(this.chkTrimBackground);
            this.grpImageOptions.Location = new System.Drawing.Point(13, 431);
            this.grpImageOptions.Name = "grpImageOptions";
            this.grpImageOptions.Size = new System.Drawing.Size(508, 80);
            this.grpImageOptions.TabIndex = 6;
            this.grpImageOptions.TabStop = false;
            this.grpImageOptions.Text = "Image Options";
            // 
            // chkPaletteSlotAddIndex
            // 
            this.chkPaletteSlotAddIndex.AutoSize = true;
            this.chkPaletteSlotAddIndex.Location = new System.Drawing.Point(427, 47);
            this.chkPaletteSlotAddIndex.Name = "chkPaletteSlotAddIndex";
            this.chkPaletteSlotAddIndex.Size = new System.Drawing.Size(74, 17);
            this.chkPaletteSlotAddIndex.TabIndex = 7;
            this.chkPaletteSlotAddIndex.Text = "Add Index";
            this.chkPaletteSlotAddIndex.UseVisualStyleBackColor = true;
            this.chkPaletteSlotAddIndex.CheckedChanged += new System.EventHandler(this.chkPaletteSlotAddIndex_CheckedChanged);
            // 
            // cboColorCount
            // 
            this.cboColorCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboColorCount.FormattingEnabled = true;
            this.cboColorCount.Location = new System.Drawing.Point(186, 42);
            this.cboColorCount.Name = "cboColorCount";
            this.cboColorCount.Size = new System.Drawing.Size(56, 21);
            this.cboColorCount.TabIndex = 2;
            this.cboColorCount.SelectedIndexChanged += new System.EventHandler(this.cboColorCount_SelectedIndexChanged);
            // 
            // lblColors
            // 
            this.lblColors.AutoSize = true;
            this.lblColors.Location = new System.Drawing.Point(248, 47);
            this.lblColors.Name = "lblColors";
            this.lblColors.Size = new System.Drawing.Size(36, 13);
            this.lblColors.TabIndex = 3;
            this.lblColors.Text = "Colors";
            // 
            // nudPaletteSlot
            // 
            this.nudPaletteSlot.Location = new System.Drawing.Point(346, 43);
            this.nudPaletteSlot.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nudPaletteSlot.Name = "nudPaletteSlot";
            this.nudPaletteSlot.Size = new System.Drawing.Size(63, 20);
            this.nudPaletteSlot.TabIndex = 5;
            this.nudPaletteSlot.ValueChanged += new System.EventHandler(this.nudPaletteSlot_ValueChanged);
            // 
            // chkAutoPaletteSlot
            // 
            this.chkAutoPaletteSlot.AutoSize = true;
            this.chkAutoPaletteSlot.Location = new System.Drawing.Point(427, 22);
            this.chkAutoPaletteSlot.Name = "chkAutoPaletteSlot";
            this.chkAutoPaletteSlot.Size = new System.Drawing.Size(48, 17);
            this.chkAutoPaletteSlot.TabIndex = 6;
            this.chkAutoPaletteSlot.Text = "Auto";
            this.chkAutoPaletteSlot.UseVisualStyleBackColor = true;
            this.chkAutoPaletteSlot.CheckedChanged += new System.EventHandler(this.chkAutoPaletteSlot_CheckedChanged);
            // 
            // chkQuantize
            // 
            this.chkQuantize.AutoSize = true;
            this.chkQuantize.Location = new System.Drawing.Point(186, 22);
            this.chkQuantize.Name = "chkQuantize";
            this.chkQuantize.Size = new System.Drawing.Size(68, 17);
            this.chkQuantize.TabIndex = 1;
            this.chkQuantize.Text = "Quantize";
            this.chkQuantize.UseVisualStyleBackColor = true;
            this.chkQuantize.CheckedChanged += new System.EventHandler(this.chkQuantize_CheckedChanged);
            // 
            // lblPaletteSlot
            // 
            this.lblPaletteSlot.AutoSize = true;
            this.lblPaletteSlot.Location = new System.Drawing.Point(345, 23);
            this.lblPaletteSlot.Name = "lblPaletteSlot";
            this.lblPaletteSlot.Size = new System.Drawing.Size(64, 13);
            this.lblPaletteSlot.TabIndex = 4;
            this.lblPaletteSlot.Text = "Palette Slot:";
            // 
            // chkTrimBackground
            // 
            this.chkTrimBackground.AutoSize = true;
            this.chkTrimBackground.Location = new System.Drawing.Point(17, 22);
            this.chkTrimBackground.Name = "chkTrimBackground";
            this.chkTrimBackground.Size = new System.Drawing.Size(107, 17);
            this.chkTrimBackground.TabIndex = 0;
            this.chkTrimBackground.Text = "Trim Background";
            this.chkTrimBackground.UseVisualStyleBackColor = true;
            this.chkTrimBackground.CheckedChanged += new System.EventHandler(this.chkTrimBackground_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuTools});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(533, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpen,
            this.mnuSave,
            this.mnuSaveAs,
            this.toolStripMenuItem1,
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "File";
            // 
            // mnuOpen
            // 
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.Size = new System.Drawing.Size(123, 22);
            this.mnuOpen.Text = "Open";
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // mnuSave
            // 
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.Size = new System.Drawing.Size(123, 22);
            this.mnuSave.Text = "Save";
            this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
            // 
            // mnuSaveAs
            // 
            this.mnuSaveAs.Name = "mnuSaveAs";
            this.mnuSaveAs.Size = new System.Drawing.Size(123, 22);
            this.mnuSaveAs.Text = "Save As...";
            this.mnuSaveAs.Click += new System.EventHandler(this.mnuSaveAs_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(120, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(123, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuTools
            // 
            this.mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSpriteSheetSlicer});
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.Size = new System.Drawing.Size(46, 20);
            this.mnuTools.Text = "Tools";
            // 
            // mnuSpriteSheetSlicer
            // 
            this.mnuSpriteSheetSlicer.Name = "mnuSpriteSheetSlicer";
            this.mnuSpriteSheetSlicer.Size = new System.Drawing.Size(167, 22);
            this.mnuSpriteSheetSlicer.Text = "Sprite Sheet Slicer";
            this.mnuSpriteSheetSlicer.Click += new System.EventHandler(this.mnuSpriteSheetSlicer_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tspbProgress});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 571);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(533, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // tspbProgress
            // 
            this.tspbProgress.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tspbProgress.Name = "tspbProgress";
            this.tspbProgress.Size = new System.Drawing.Size(100, 16);
            // 
            // grpOutputOptions
            // 
            this.grpOutputOptions.Controls.Add(this.cboFileFormat);
            this.grpOutputOptions.Controls.Add(this.lblOutputFolder);
            this.grpOutputOptions.Controls.Add(this.butOutputFolder);
            this.grpOutputOptions.Controls.Add(this.txtOutputFolder);
            this.grpOutputOptions.Controls.Add(this.lblFileFormat);
            this.grpOutputOptions.Controls.Add(this.txtName);
            this.grpOutputOptions.Controls.Add(this.lblName);
            this.grpOutputOptions.Location = new System.Drawing.Point(13, 182);
            this.grpOutputOptions.Name = "grpOutputOptions";
            this.grpOutputOptions.Size = new System.Drawing.Size(508, 91);
            this.grpOutputOptions.TabIndex = 3;
            this.grpOutputOptions.TabStop = false;
            this.grpOutputOptions.Text = "Output Options";
            // 
            // cboFileFormat
            // 
            this.cboFileFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFileFormat.FormattingEnabled = true;
            this.cboFileFormat.Location = new System.Drawing.Point(331, 19);
            this.cboFileFormat.Name = "cboFileFormat";
            this.cboFileFormat.Size = new System.Drawing.Size(107, 21);
            this.cboFileFormat.TabIndex = 3;
            this.cboFileFormat.SelectedIndexChanged += new System.EventHandler(this.cboFileFormat_SelectedIndexChanged);
            // 
            // lblOutputFolder
            // 
            this.lblOutputFolder.AutoSize = true;
            this.lblOutputFolder.Location = new System.Drawing.Point(10, 54);
            this.lblOutputFolder.Name = "lblOutputFolder";
            this.lblOutputFolder.Size = new System.Drawing.Size(39, 13);
            this.lblOutputFolder.TabIndex = 4;
            this.lblOutputFolder.Text = "Folder:";
            // 
            // butOutputFolder
            // 
            this.butOutputFolder.Location = new System.Drawing.Point(451, 51);
            this.butOutputFolder.Name = "butOutputFolder";
            this.butOutputFolder.Size = new System.Drawing.Size(39, 20);
            this.butOutputFolder.TabIndex = 6;
            this.butOutputFolder.Text = "...";
            this.butOutputFolder.UseVisualStyleBackColor = true;
            this.butOutputFolder.Click += new System.EventHandler(this.butOutputFolder_Click);
            // 
            // txtOutputFolder
            // 
            this.txtOutputFolder.Location = new System.Drawing.Point(55, 51);
            this.txtOutputFolder.Name = "txtOutputFolder";
            this.txtOutputFolder.Size = new System.Drawing.Size(386, 20);
            this.txtOutputFolder.TabIndex = 5;
            this.txtOutputFolder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOutputFolder.TextChanged += new System.EventHandler(this.txtOutputFolder_TextChanged);
            // 
            // lblFileFormat
            // 
            this.lblFileFormat.AutoSize = true;
            this.lblFileFormat.Location = new System.Drawing.Point(261, 24);
            this.lblFileFormat.Name = "lblFileFormat";
            this.lblFileFormat.Size = new System.Drawing.Size(61, 13);
            this.lblFileFormat.TabIndex = 2;
            this.lblFileFormat.Text = "File Format:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(55, 21);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(199, 20);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(11, 24);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            // 
            // grpInputPalette
            // 
            this.grpInputPalette.Controls.Add(this.butInputPalette);
            this.grpInputPalette.Controls.Add(this.txtInputPalette);
            this.grpInputPalette.Location = new System.Drawing.Point(12, 117);
            this.grpInputPalette.Name = "grpInputPalette";
            this.grpInputPalette.Size = new System.Drawing.Size(508, 59);
            this.grpInputPalette.TabIndex = 2;
            this.grpInputPalette.TabStop = false;
            this.grpInputPalette.Text = "Input Palette";
            // 
            // butInputPalette
            // 
            this.butInputPalette.Location = new System.Drawing.Point(449, 23);
            this.butInputPalette.Name = "butInputPalette";
            this.butInputPalette.Size = new System.Drawing.Size(39, 20);
            this.butInputPalette.TabIndex = 1;
            this.butInputPalette.Text = "...";
            this.butInputPalette.UseVisualStyleBackColor = true;
            this.butInputPalette.Click += new System.EventHandler(this.butInputPalette_Click);
            // 
            // txtInputPalette
            // 
            this.txtInputPalette.Location = new System.Drawing.Point(17, 23);
            this.txtInputPalette.Name = "txtInputPalette";
            this.txtInputPalette.Size = new System.Drawing.Size(422, 20);
            this.txtInputPalette.TabIndex = 0;
            this.txtInputPalette.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInputPalette.TextChanged += new System.EventHandler(this.txtInputPalette_TextChanged);
            // 
            // grpBackgroundOptions
            // 
            this.grpBackgroundOptions.Controls.Add(this.chkReplaceBackgroundColor);
            this.grpBackgroundOptions.Controls.Add(this.rdoIndexBackground);
            this.grpBackgroundOptions.Controls.Add(this.butColor);
            this.grpBackgroundOptions.Controls.Add(this.txtBackgroundIndex);
            this.grpBackgroundOptions.Controls.Add(this.rdoAlphaBackground);
            this.grpBackgroundOptions.Controls.Add(this.rdoColorBackground);
            this.grpBackgroundOptions.Location = new System.Drawing.Point(13, 368);
            this.grpBackgroundOptions.Name = "grpBackgroundOptions";
            this.grpBackgroundOptions.Size = new System.Drawing.Size(508, 57);
            this.grpBackgroundOptions.TabIndex = 5;
            this.grpBackgroundOptions.TabStop = false;
            this.grpBackgroundOptions.Text = "Background Options";
            // 
            // chkReplaceBackgroundColor
            // 
            this.chkReplaceBackgroundColor.AutoSize = true;
            this.chkReplaceBackgroundColor.Location = new System.Drawing.Point(329, 25);
            this.chkReplaceBackgroundColor.Name = "chkReplaceBackgroundColor";
            this.chkReplaceBackgroundColor.Size = new System.Drawing.Size(154, 17);
            this.chkReplaceBackgroundColor.TabIndex = 8;
            this.chkReplaceBackgroundColor.Text = "Replace Background Color";
            this.chkReplaceBackgroundColor.UseVisualStyleBackColor = true;
            this.chkReplaceBackgroundColor.CheckedChanged += new System.EventHandler(this.chkReplaceBackgroundColor_CheckedChanged);
            // 
            // rdoIndexBackground
            // 
            this.rdoIndexBackground.AutoSize = true;
            this.rdoIndexBackground.Location = new System.Drawing.Point(200, 24);
            this.rdoIndexBackground.Name = "rdoIndexBackground";
            this.rdoIndexBackground.Size = new System.Drawing.Size(51, 17);
            this.rdoIndexBackground.TabIndex = 3;
            this.rdoIndexBackground.Text = "Index";
            this.rdoIndexBackground.UseVisualStyleBackColor = true;
            this.rdoIndexBackground.CheckedChanged += new System.EventHandler(this.rdoIndexBackground_CheckedChanged);
            // 
            // txtBackgroundIndex
            // 
            this.txtBackgroundIndex.Location = new System.Drawing.Point(257, 23);
            this.txtBackgroundIndex.Name = "txtBackgroundIndex";
            this.txtBackgroundIndex.Size = new System.Drawing.Size(63, 20);
            this.txtBackgroundIndex.TabIndex = 4;
            this.txtBackgroundIndex.TextChanged += new System.EventHandler(this.txtBackgroundIndex_TextChanged);
            // 
            // lblbaker76
            // 
            this.lblbaker76.AutoSize = true;
            this.lblbaker76.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblbaker76.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbaker76.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblbaker76.Location = new System.Drawing.Point(451, 544);
            this.lblbaker76.Name = "lblbaker76";
            this.lblbaker76.Size = new System.Drawing.Size(69, 13);
            this.lblbaker76.TabIndex = 8;
            this.lblbaker76.Text = "baker76.com";
            this.lblbaker76.Click += new System.EventHandler(this.lblbaker76_Click);
            // 
            // chkRemapPalette
            // 
            this.chkRemapPalette.AutoSize = true;
            this.chkRemapPalette.Location = new System.Drawing.Point(17, 44);
            this.chkRemapPalette.Name = "chkRemapPalette";
            this.chkRemapPalette.Size = new System.Drawing.Size(96, 17);
            this.chkRemapPalette.TabIndex = 2;
            this.chkRemapPalette.Text = "Remap Palette";
            this.chkRemapPalette.UseVisualStyleBackColor = true;
            this.chkRemapPalette.CheckedChanged += new System.EventHandler(this.chkRemapPalette_CheckedChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 593);
            this.Controls.Add(this.lblbaker76);
            this.Controls.Add(this.grpBackgroundOptions);
            this.Controls.Add(this.grpInputPalette);
            this.Controls.Add(this.grpFolders);
            this.Controls.Add(this.grpTextureOptions);
            this.Controls.Add(this.grpOutputOptions);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.grpImageOptions);
            this.Controls.Add(this.butGo);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crunchy v[VERSION]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.grpFolders.ResumeLayout(false);
            this.grpFolders.PerformLayout();
            this.grpTextureOptions.ResumeLayout(false);
            this.grpTextureOptions.PerformLayout();
            this.grpImageOptions.ResumeLayout(false);
            this.grpImageOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPaletteSlot)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.grpOutputOptions.ResumeLayout(false);
            this.grpOutputOptions.PerformLayout();
            this.grpInputPalette.ResumeLayout(false);
            this.grpInputPalette.PerformLayout();
            this.grpBackgroundOptions.ResumeLayout(false);
            this.grpBackgroundOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

