using Baker76.Imaging;
using Baker76.Imaging.Pngcs;
using System;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Image = Baker76.Imaging.Image;

namespace Crunchy
{
    public partial class frmSpriteStripper : Form
    {
        public frmSpriteStripper()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            Size spriteSize = new Size(System.Convert.ToInt32(spriteWidth.Text), System.Convert.ToInt32(spriteHeight.Text));
			Rectangle paddingRect = Rectangle.FromLTRB(System.Convert.ToInt32(paddingLeft.Text), System.Convert.ToInt32(paddingTop.Text), System.Convert.ToInt32(paddingRight.Text), System.Convert.ToInt32(paddingBottom.Text));

            var sourcePath = openFileDialog.FileName;
            var destPath = Path.Combine(
                Path.GetDirectoryName(sourcePath)!,
                Path.GetFileNameWithoutExtension(sourcePath) + "_out" + Path.GetExtension(sourcePath));
            Image sourceImage = PngReader.Read(openFileDialog.FileName);
            Baker76.Imaging.Utility.SpriteSheetStripper(sourceImage, destPath, spriteSize, paddingRect);

            MessageBox.Show("Done!");
        }
    }
}
