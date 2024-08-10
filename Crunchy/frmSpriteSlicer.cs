using System;
using Baker76.Imaging;
using Image = Baker76.Imaging.Image;

namespace Crunchy
{
    public partial class frmSpriteSlicer : Form
    {
        public frmSpriteSlicer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            Size inputSize = new Size(System.Convert.ToInt32(inputWidth.Text), System.Convert.ToInt32(inputHeight.Text));
			Size marginSize = new Size(System.Convert.ToInt32(marginWidth.Text), System.Convert.ToInt32(marginHeight.Text));
			Size spacingSize = new Size(System.Convert.ToInt32(spacingWidth.Text), System.Convert.ToInt32(spacingHeight.Text));
            Size outputSize = chkUseTrimSize.Checked ? inputSize : new Size(System.Convert.ToInt32(outputWidth.Text), System.Convert.ToInt32(outputHeight.Text));

            Image srcImage = PngReader.Read(openFileDialog.FileName);
            Image[] images = Baker76.Imaging.Utility.SpriteSheetSplicer(srcImage, inputSize, marginSize, spacingSize, outputSize, chkAutoTrim.Checked, chkUseTrimSize.Checked, 0, false, 0);

            for (int i = 0; i < images.Length; i++)
            {
                string directoryName = Path.GetDirectoryName(openFileDialog.FileName);
                string fileName = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                string suffix = String.Format("{0:00}", i);
                string extension = ".png";

                PngWriter.Write(Path.Combine(directoryName, fileName + suffix + extension), images[i]);
            }
            
            MessageBox.Show("Done!");
        }
    }
}
