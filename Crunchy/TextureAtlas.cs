using Baker76.Imaging;
using Baker76.Core.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Baker76.Imaging.Aseprite;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using JeremyAnsel.ColorQuant;
using Color = Baker76.Imaging.Color;
using Image = Baker76.Imaging.Image;
using Bitmap = Baker76.Imaging.Bitmap;
using Hjg.Pngcs.Zlib;

namespace Crunchy
{
    internal class TextureAtlas
    {
        private static bool IsAtlasDone(List<ImageNode> imageList)
        {
            foreach (ImageNode imageNode in imageList)
            {
                if (!imageNode.Processed)
                    return false;
            }

            return true;
        }

        private static void ResetAtlas(List<ImageNode> imageList)
        {
            foreach (ImageNode imageNode in imageList)
                imageNode.Processed = false;
        }

        private static bool IsAtlasTooSmall(List<ImageNode> imageList, int spacing, Size textureSize)
        {
            foreach (ImageNode imageNode in imageList)
            {
                if (imageNode.Width + spacing > textureSize.Width || imageNode.Height + spacing > textureSize.Height)
                    return true;
            }

            return false;
        }

        private static void ExecuteBatch(string fileName, string arguments, out string output, out string error)
        {
            int ExitCode;
            ProcessStartInfo ProcessInfo;
            Process process;

            ProcessInfo = new ProcessStartInfo(Path.GetFileName(fileName), arguments);
            ProcessInfo.CreateNoWindow = true;
            ProcessInfo.UseShellExecute = false;
            ProcessInfo.WorkingDirectory = Path.GetDirectoryName(fileName);

            ProcessInfo.RedirectStandardError = true;
            ProcessInfo.RedirectStandardOutput = true;

            process = Process.Start(ProcessInfo);
            process.WaitForExit();

            output = process.StandardOutput.ReadToEnd();
            error = process.StandardError.ReadToEnd();

            ExitCode = process.ExitCode;

            process.Close();
        }

        public static void ReadConfig(string fileName)
        {
            IniFile iniFile = new IniFile(fileName);

            for (int i = 0; i < Globals.MAX_FOLDERS; i++)
                Settings.File.InputFolderList[i] = String.Empty;

            if (iniFile.ContainsKey("General", "Folder"))
            {
                Settings.File.InputFolderList[0] = iniFile.GetValue("General", "Folder", String.Empty);

                iniFile.RemoveKey("General", "Folder");
            }
            else
            {
                for (int i = 0; i < Globals.MAX_FOLDERS; i++)
                    Settings.File.InputFolderList[i] = iniFile.GetValue("General", String.Format("Folder{0}", i + 1), String.Empty);
            }

            Settings.File.FileName = Path.GetFileName(iniFile.GetValue("General", "FileName", Settings.File.DefaultFileName));
            Settings.File.OutputFolder = iniFile.GetValue("General", "OutputFolder", Settings.File.OutputFolder);
            Settings.File.PaletteFileName = iniFile.GetValue("General", "PaletteFileName", Settings.File.PaletteFileName);
            Settings.General.BitDepth = iniFile.GetValue<int>("General", "BitDepth", Settings.General.BitDepth);
            Settings.General.Recursive = iniFile.GetValue<bool>("General", "Recursive", Settings.General.Recursive);
            Settings.General.Name = iniFile.GetValue("General", "Name", Settings.General.Name);
            Settings.General.FileFormat = iniFile.GetValue<FileFormat>("General", "FileFormat", Settings.General.FileFormat);
            Settings.General.MultiTexture = iniFile.GetValue<bool>("General", "MultiTexture", Settings.General.MultiTexture);
            Settings.General.AutoSizeTexture = iniFile.GetValue<bool>("General", "AutoSizeTexture", Settings.General.AutoSizeTexture);
            Settings.General.TextureSize = iniFile.GetValue<Size>("General", "TextureSize", Settings.General.TextureSize);
            Settings.General.MinTextureSize = iniFile.GetValue<Size>("General", "MinTextureSize", Settings.General.MinTextureSize);
            Settings.General.MaxTextureSize = iniFile.GetValue<Size>("General", "MaxTextureSize", Settings.General.MaxTextureSize);
            Settings.General.AlphaBackground = iniFile.GetValue<bool>("General", "AlphaBackground", Settings.General.AlphaBackground);
            Settings.General.ColorBackground = iniFile.GetValue<bool>("General", "ColorBackground", Settings.General.ColorBackground);
            Settings.General.IndexBackground = iniFile.GetValue<bool>("General", "IndexBackground", Settings.General.IndexBackground);
            Settings.General.BackColor = Baker76.Imaging.Color.FromArgb(iniFile.GetValue<int>("General", "BackColor", Settings.General.BackColor.ToArgb()));
            Settings.General.BackgroundIndex = iniFile.GetValue<int>("General", "BackgroundIndex", Settings.General.BackgroundIndex);
            Settings.General.ReplaceBackgroundColor = iniFile.GetValue<bool>("General", "ReplaceBackgroundColor", Settings.General.ReplaceBackgroundColor);
            Settings.General.ColorDistance = iniFile.GetValue<DistanceType>("General", "ColorDistance", Settings.General.ColorDistance);
            Settings.General.Spacing = iniFile.GetValue<int>("General", "Spacing", Settings.General.Spacing);
            Settings.General.FillSpacing = iniFile.GetValue<bool>("General", "FillSpacing", Settings.General.FillSpacing);
            Settings.General.Quantize = iniFile.GetValue<bool>("General", "Quantize", Settings.General.Quantize);
            Settings.General.ColorCount = iniFile.GetValue<int>("General", "ColorCount", Settings.General.ColorCount);
            Settings.General.AutoPaletteSlot = iniFile.GetValue<bool>("General", "AutoPaletteSlot", Settings.General.AutoPaletteSlot);
            Settings.General.RemapPalette = iniFile.GetValue<bool>("General", "RemapPalette", Settings.General.RemapPalette);
            Settings.General.PaletteSlot = iniFile.GetValue<int>("General", "PaletteSlot", Settings.General.PaletteSlot);
            Settings.General.PaletteSlotAddIndex = iniFile.GetValue<bool>("General", "PaletteSlotAddIndex", Settings.General.PaletteSlotAddIndex);
            Settings.General.TrimBackground = iniFile.GetValue<bool>("General", "TrimBackground", Settings.General.TrimBackground);
        }

        public static void WriteConfig(string fileName)
        {
            IniFile iniFile = new IniFile(fileName);

            iniFile.SetValue("General", "FileName", Path.GetFileName(Settings.File.FileName));
            iniFile.SetValue("General", "OutputFolder", Settings.File.OutputFolder);
            iniFile.SetValue("General", "PaletteFileName", Settings.File.PaletteFileName);

            for (int i = 0; i < Globals.MAX_FOLDERS; i++)
            {
                iniFile.SetValue("General", String.Format("Folder{0}", i + 1), Settings.File.InputFolderList[i]);
            }

            iniFile.SetValue<int>("General", "BitDepth", Settings.General.BitDepth);
            iniFile.SetValue<bool>("General", "Recursive", Settings.General.Recursive);
            iniFile.SetValue("General", "Name", Settings.General.Name);
            iniFile.SetValue<FileFormat>("General", "FileFormat", Settings.General.FileFormat);
            iniFile.SetValue<bool>("General", "MultiTexture", Settings.General.MultiTexture);
            iniFile.SetValue<bool>("General", "AutoSizeTexture", Settings.General.AutoSizeTexture);
            iniFile.SetValue<Size>("General", "TextureSize", Settings.General.TextureSize);
            iniFile.SetValue<Size>("General", "MinTextureSize", Settings.General.MinTextureSize);
            iniFile.SetValue<Size>("General", "MaxTextureSize", Settings.General.MaxTextureSize);
            iniFile.SetValue<bool>("General", "AlphaBackground", Settings.General.AlphaBackground);
            iniFile.SetValue<bool>("General", "ColorBackground", Settings.General.ColorBackground);
            iniFile.SetValue<bool>("General", "IndexBackground", Settings.General.IndexBackground);
            iniFile.SetValue<int>("General", "BackColor", Settings.General.BackColor.ToArgb());
            iniFile.SetValue<int>("General", "BackIndex", Settings.General.BackgroundIndex);
            iniFile.SetValue<bool>("General", "ReplaceBackgroundColor", Settings.General.ReplaceBackgroundColor);
            iniFile.SetValue<DistanceType>("General", "ColorDistance", Settings.General.ColorDistance);
            iniFile.SetValue<int>("General", "Spacing", Settings.General.Spacing);
            iniFile.SetValue<bool>("General", "FillSpacing", Settings.General.FillSpacing);
            iniFile.SetValue<bool>("General", "Quantize", Settings.General.Quantize);
            iniFile.SetValue<int>("General", "ColorCount", Settings.General.ColorCount);
            iniFile.SetValue<bool>("General", "AutoPaletteSlot", Settings.General.AutoPaletteSlot);
            iniFile.SetValue<bool>("General", "RemapPalette", Settings.General.RemapPalette);
            iniFile.SetValue<int>("Gneeral", "PaletteSlot", Settings.General.PaletteSlot);
            iniFile.SetValue<bool>("General", "TrimBackground", Settings.General.TrimBackground);
            iniFile.SetValue("General", "PaletteSlot", Settings.General.PaletteSlot);
            iniFile.SetValue<bool>("General", "PaletteSlotAddIndex", Settings.General.PaletteSlotAddIndex);

            iniFile.SaveToFile(fileName);
        }

        public static void GetBitmaps(List<ImageNode> imageList, BatchSettings settings, out Color[] colorPalette)
        {
            colorPalette = new Color[256];
            List<Color> colorList = new List<Color>();

            for (int i = 0; i < 256; i++)
                colorPalette[i] = Color.Empty;

            for (int i = 0; i < imageList.Count; i++)
            {
                ImageNode image = imageList[i];

                if (!File.Exists(image.FileName))
                {
                    Console.WriteLine("Error: File '{0}' Not Found", image.FileName);

                    continue;
                }

                string extension = Path.GetExtension(image.FileName).ToLower();
                Image originalBitmap = null;

                if (extension == ".png")
                    originalBitmap = PngReader.Read(image.FileName);
                else if (extension == ".bmp")
                    originalBitmap = Bitmap.Read(image.FileName);

                if (!settings.Quantize && (originalBitmap.BitsPerPixel != 4 && originalBitmap.BitsPerPixel != 8))
                    continue;

                string name = Path.GetFileName(image.FileName);
                image.Image = originalBitmap;

                if (settings.Quantize)
                {
                    ColorQuantizerOptions options = new ColorQuantizerOptions
                    {
                        //Palette = paletteColors,
                        ColorCountTarget = Settings.General.ColorCount,
                        BackgroundIndex = Settings.General.BackgroundIndex,
                        //PaletteSlot = paletteSlot,
                        AutoPaletteSlot = Settings.General.AutoPaletteSlot,
                        PaletteSlotAddIndex = Settings.General.PaletteSlotAddIndex,
                        DistanceType = Settings.General.ColorDistance
                    };

                    WuAlphaColorQuantizer quantizer = new WuAlphaColorQuantizer();
                    ColorQuantizerResult result = quantizer.Quantize(originalBitmap.PixelData, options);
                    colorPalette = result.ColorPalette;

                    image.Image = new Image(originalBitmap.Width, originalBitmap.Height, 8, new Palette(result.ColorPalette), result.Bytes);
                }

                image.Image.Palette.SetNearestColorPalette(settings.ColorPalette, DistanceType.Sqrt);

                image.Palette = image.Image.GetUsedColors();

                colorList.AddRange(image.Palette);

                for (int j = 0; j < 16 - image.Palette.Length; j++)
                    colorList.Add(Color.Empty);
            }

            for (int i = 0; i < imageList.Count; i++)
            {
                ImageNode image = imageList[i];
                List<Color> colorPaletteTemp = new List<Color>(colorList);
                Palette imagePalette = new Palette(image.Palette);

                for (int j = 0; j < 16; j++)
                    colorPaletteTemp[i * 16 + j] = Color.Empty;

                image.ClosestPaletteSlot = imagePalette.GetBestPaletteSlot(colorPaletteTemp.ToArray(), DistanceType.Sqrt);

                imageList[image.ClosestPaletteSlot].PaletteSlotCount++;

                //Color[] nearestColorPalette = new Color[16];
                //Array.Copy(colorPaletteTemp.ToArray(), image.ClosestPaletteSlot * 16, nearestColorPalette, 0, 16);

                //SetBitmapNearestColorPaletteIndices(image.PngImage, nearestColorPalette, DistanceType.Sqrt);
            }

            //imageList.Sort(new ClosestPaletteSlotComparer());
            //imageList.Reverse()

            imageList.Sort(new PaletteSlotCountComparer());
            imageList.Reverse();

            /* for (int i = 0; i < imageList.Count; i++)
            {
                ImageNode image = imageList[i];

                Console.WriteLine("{0}: {1} -> {2}", i, image.ClosestPaletteSlot, image.PaletteSlotCount);
            } */

            imageList.Sort(new PaletteLengthComparer());
            imageList.Reverse();
        }

        public static async Task ProcessLayoutFile(string fileName)
        {
            string appPath = System.Windows.Forms.Application.StartupPath;
            string workingPath = Path.GetDirectoryName(fileName);
            List<ImageNode> imageList = new List<ImageNode>();
            List<SliceNode> sliceList = new List<SliceNode>();
            IniFile iniFile = new IniFile(fileName);
            BatchSettings settings = new BatchSettings();

            string sourceDirectory = iniFile.GetValue("General", "SourceDirectory");
            string destinationDirectory = iniFile.GetValue("General", "DestinationDirectory");
            string outputFileName = iniFile.GetValue("General", "OutputFileName");
            Size outputSize = iniFile.GetValue<Size>("General", "OutputSize");
            string paletteFileName = iniFile.GetValue("General", "PaletteFileName");

            if (!String.IsNullOrEmpty(paletteFileName))
            {
                GetFullPath(workingPath, ref paletteFileName);

                if (!File.Exists(paletteFileName))
                {
                    paletteFileName = iniFile.GetValue("General", "PaletteFileName");
                    GetFullPath(appPath, ref paletteFileName);
                }

                settings.ColorPalette = await PalFile.Read(paletteFileName);
            }

            settings.SwapMagentaWithTransparentIndex = iniFile.GetValue<bool>("General", "SwapMagentaWithTransparentIndex", true);
            settings.SortSizes = iniFile.GetValue<bool>("General", "SortSizes", true);
            settings.SortColors = iniFile.GetValue<bool>("General", "SortColors", true);
            settings.Quantize = iniFile.GetValue<bool>("General", "Quantize", true);
            settings.AddPaletteOffset = iniFile.GetValue<bool>("General", "AddPaletteOffset", false);
            settings.CreateCombinedImage = iniFile.GetValue<bool>("General", "CreateCombinedImage", true);
            settings.MaxPaletteCount = iniFile.GetValue<int>("General", "MaxPaletteCount", 16);
            settings.TransparentIndex = iniFile.GetValue<int>("General", "TransparentIndex", 0);
            settings.AutoPosition = iniFile.GetValue<bool>("General", "AutoPosition", true);

            GetFullPath(workingPath, ref sourceDirectory);
            GetFullPath(workingPath, ref destinationDirectory);
            GetFullPath(workingPath, ref outputFileName);

            if (!Directory.Exists(sourceDirectory))
            {
                Console.WriteLine("Error: Source Directory '{0}' Doesn't Exist", sourceDirectory);

                return;
            }

            for (int i = 0; i < 256; i++)
            {
                string sectionName = String.Format("Image{0}", i);
                string name = iniFile.GetValue(sectionName, "Name");

                if (name == null)
                    break;

                Point position = iniFile.GetValue<Point>(sectionName, "Position", Point.Empty);
                int paletteSlot = iniFile.GetValue<int>(sectionName, "PaletteSlot", -1);
                string path = Path.Combine(sourceDirectory, name);

                imageList.Add(new ImageNode(i, path, position.X, position.Y, paletteSlot));
            }

            for (int i = 0; i < 256; i++)
            {
                string sectionName = String.Format("Slice{0}", i);
                string name = iniFile.GetValue(sectionName, "Name");

                if (name == null)
                    break;

                Point position = iniFile.GetValue<Point>(sectionName, "Position", Point.Empty);
                Size size = iniFile.GetValue<Size>(sectionName, "Size", Size.Empty);
                string path = Path.Combine(destinationDirectory, name);

                sliceList.Add(new SliceNode(path, position, size));
            }

            settings.SourceDirectory = sourceDirectory;
            settings.DestinationDirectory = destinationDirectory;
            settings.OutputFileName = outputFileName;
            settings.OutputSize = outputSize;

            BatchProcessFolder(imageList, sliceList, settings);
        }

        public static void GetFullPath(string path1, ref string path2)
        {
            if (String.IsNullOrEmpty(path2))
                return;

            if (Path.IsPathRooted(path2))
                return;

            path2 = Path.GetFullPath(Path.Combine(path1, path2));
        }

        public static void BatchProcessFolder(Form parent, BatchSettings settings)
        {
            if (!Directory.Exists(settings.SourceDirectory))
            {
                Console.WriteLine("Error: Source Directory '{0}' Doesn't Exist", settings.SourceDirectory);

                return;
            }

            string[] fileArray = Directory.GetFiles(settings.SourceDirectory, "*.*");
            List<ImageNode> imageList = new List<ImageNode>();
            RectanglePacker rectanglePacker = new RectanglePacker(settings.OutputSize.Width, settings.OutputSize.Height);

            if (fileArray.Length == 0)
            {
                Console.WriteLine("Error: No Files Found in '{0}'", settings.SourceDirectory);

                return;
            }

            for (int i = 0; i < fileArray.Length; i++)
                imageList.Add(new ImageNode(i, fileArray[i]));

            imageList.Sort(new ImageNode());

            if (settings.SortSizes)
            {
                imageList.Sort(new ImageSizeComparer());
            }

            for (int i = 0; i < imageList.Count; i++)
            {
                ImageNode image = imageList[i];
                Rectangle srcRectangle = new Rectangle(0, 0, image.Width, image.Height);
                Point position = Point.Empty;

                if (rectanglePacker.FindPoint(srcRectangle.Size, ref position))
                {
                    image.X = position.X;
                    image.Y = position.Y;
                }

                image.PaletteSlot = i;
            }

            string outputFileName = null;

            if (!FileIO.TrySaveFile(parent, null, null, "Bitmap Files", new string[] { ".bmp", ".png" }, out outputFileName))
            {
                Console.WriteLine("Error: Saving File '{0}'", outputFileName);
            }

            settings.OutputFileName = outputFileName;

            BatchProcessFolder(imageList, new List<SliceNode>(), settings);
        }

        public static void BatchProcessFolder(List<ImageNode> imageList, List<SliceNode> sliceList, BatchSettings settings)
        {
            if (!Directory.Exists(settings.SourceDirectory))
            {
                Console.WriteLine("Error: Source Directory '{0}' Doesn't Exist", settings.SourceDirectory);

                return;
            }

            Color[] colorPalette = null;
            bool[] paletteUsed = new bool[16];
            int paletteCount = 0;
            Palette globalPalette = new Palette(256);

            GetBitmaps(imageList, settings, out colorPalette);

            for (int i = 0; i < imageList.Count; i++)
            {
                ImageNode image = imageList[i];

                if (image.Image == null)
                    continue;

                string name = Path.GetFileName(image.FileName);
                int paletteSlot = (image.PaletteSlot == -2 ? paletteCount++ : image.PaletteSlot);
                int paletteOffset = paletteSlot * 16;
                Palette palette = image.Image.Palette;
                int totalColors = palette.Colors.Count;

                if (paletteCount > settings.MaxPaletteCount || paletteSlot > 15)
                {
                    paletteSlot = image.Image.Palette.GetBestPaletteSlot(colorPalette, DistanceType.Sqrt);
                    paletteOffset = paletteSlot * 16;
                }

                Console.WriteLine("Processing '{0}' palette index {1} ({2} used of {3} colors)", name, paletteSlot, image.Palette.Length, totalColors);

                if (paletteSlot != -1 && paletteUsed[paletteSlot])
                {
                    Color[] nearestColorPalette = new Color[16];
                    Array.Copy(colorPalette, paletteOffset, nearestColorPalette, 0, 16);

                    Console.WriteLine("'{0}' Reusing PaletteSlot {1}", image.FileName, paletteSlot);

                    image.Image.RemapColors(nearestColorPalette, settings.TransparentIndex, DistanceType.Sqrt);
                    palette = image.Image.Palette;
                }
                else
                {
                    int transparentIndex = -1;

                    if (settings.SwapMagentaWithTransparentIndex)
                    {
                        for (int j = 0; j < palette.Colors.Count; j++)
                        {
                            if (palette.Colors[j].R == Color.Magenta.R &&
                                palette.Colors[j].G == Color.Magenta.G &&
                                palette.Colors[j].B == Color.Magenta.B)
                            {
                                transparentIndex = j;
                                break;
                            }
                        }

                        if (transparentIndex != -1)
                        {
                            image.Image.SwapColors(settings.TransparentIndex, transparentIndex);
                            palette = image.Image.Palette;
                        }
                    }

                    if (settings.SortColors)
                    {
                        image.Image.SortPalette(SortColorMode.Sqrt, HSBSortMode.HSB, settings.TransparentIndex);
                        palette = image.Image.Palette;
                    }
                }

                Image newBitmap = new Image(image.Image.Width, image.Image.Height, 8, image.Image.Palette, image.Image.PixelData);

                if (paletteSlot != -1)
                {
                    if (settings.AddPaletteOffset)
                    {
                        newBitmap.AddIndexOffset(paletteOffset);
                    }

                    if (!paletteUsed[paletteSlot])
                    {
                        for (int j = 0; j < palette.Colors.Count && j < 16; j++)
                        {
                            colorPalette[paletteOffset + j] = palette.Colors[j];
                        }

                        paletteUsed[paletteSlot] = true;
                    }
                }

                image.Image = newBitmap;
            }

            if (settings.ColorPalette != null)
            {
                for (int i = 0; i < 256; i++)
                {
                    if (colorPalette[i].A == 0)
                        globalPalette.AddColor(colorPalette[i]);
                    else
                    {
                        Color nearestColor = null;

                        Palette.GetNearestColor(colorPalette[i], settings.ColorPalette, DistanceType.Sqrt, out nearestColor);

                        globalPalette.AddColor(nearestColor);
                    }
                }
            }
            else
            {
                for (int i = 0; i < 256; i++)
                    globalPalette.AddColor(colorPalette[i]);
            }

            if (!settings.CreateCombinedImage)
            {
                if (Directory.Exists(settings.DestinationDirectory))
                {
                    for (int i = 0; i < imageList.Count; i++)
                    {
                        ImageNode image = imageList[i];
                        Image bitmap = image.Image;
                        string fileName = Path.GetFileName(image.FileName);
                        string destinationFileName = Path.Combine(settings.DestinationDirectory, fileName);

                        bitmap.Palette = globalPalette;
                        bitmap.Save(destinationFileName);
                    }
                }
            }

            Rectangle outputRectangle = new Rectangle(Point.Empty, settings.OutputSize);
            Image outputBitmap = new Image(settings.OutputSize.Width, settings.OutputSize.Height, 8, globalPalette);

            outputBitmap.Clear(settings.TransparentIndex);

            for (int i = 0; i < imageList.Count; i++)
            {
                ImageNode image = imageList[i];
                Image bitmap = image.Image;
                Rectangle srcRectangle = new Rectangle(Point.Empty, bitmap.Size);
                Rectangle dstRectangle = new Rectangle(image.X, image.Y, bitmap.Width, bitmap.Height);

                if (settings.AutoPosition)
                {
                    int dstWidth = bitmap.Width, imageCount = 1;

                    dstRectangle.Intersect(outputRectangle);
                    dstWidth -= dstRectangle.Width;

                    outputBitmap.DrawImage(bitmap, dstRectangle, srcRectangle);

                    while (dstWidth > 0)
                    {
                        srcRectangle = new Rectangle(bitmap.Width - dstWidth, 0, dstWidth, bitmap.Height);
                        dstRectangle = new Rectangle(0, image.Y + bitmap.Height * imageCount, dstWidth, bitmap.Height);

                        dstRectangle.Intersect(outputRectangle);
                        dstWidth -= dstRectangle.Width;

                        outputBitmap.DrawImage(bitmap, dstRectangle, srcRectangle);

                        imageCount++;
                    }
                }
                else
                {
                    outputBitmap.DrawImage(bitmap, dstRectangle, srcRectangle);
                }

                image.Image = null;

                if (settings.CreateCombinedImage)
                {
                    if (File.Exists(settings.OutputFileName))
                        File.Delete(settings.OutputFileName);

                    string extension = Path.GetExtension(settings.OutputFileName);

                    if (extension == ".png")
                        outputBitmap.Save(settings.OutputFileName);
                    else
                        Bitmap.Write(settings.OutputFileName, outputBitmap);
                }

                foreach (SliceNode slice in sliceList)
                {
                    Image sliceBitmap = new Image(slice.Size.Width, slice.Size.Height, 8, globalPalette);

                    sliceBitmap.DrawImage(outputBitmap, new Rectangle(Point.Empty, slice.Size), new Rectangle(slice.Position, slice.Size));

                    string extension = Path.GetExtension(slice.FileName);

                    if (extension == ".png")
                        sliceBitmap.Save(slice.FileName);
                    else
                        Bitmap.Write(slice.FileName, outputBitmap);
                }
            }
        }

        public static Image CreateTextureImage(Size textureSize, Palette palette)
        {
            bool isIndexed = Settings.General.BitDepth <= 8;
            Image textureImage = new Image(textureSize.Width, textureSize.Height, System.Math.Max(Settings.General.BitDepth, 8), isIndexed ? palette : new Palette());

            if (Settings.General.ColorBackground)
                textureImage.Clear(Settings.General.BackColor);

            if (isIndexed && Settings.General.IndexBackground)
            {
                palette.TransparentColor = Settings.General.BackgroundIndex;
                textureImage.Clear(Settings.General.BackgroundIndex);
            }

            return textureImage;
        }

        public static async Task<(bool, string, string)> ProcessAtlasFiles(BackgroundWorker worker)
        {
            string output = String.Empty;
            string error = String.Empty;

            string[] patterns = new string[] { "*.png", "*.bmp", "*.ase", "*.aseprite" };
            Settings.General.Name = String.IsNullOrEmpty(Settings.General.Name) ? "texture" : Settings.General.Name;
            Settings.General.TextureFormat = (int)Dave2D.BitsToD2Format(Settings.General.BitDepth);

            string fullPath = Path.Combine(Settings.File.OutputFolder, Settings.General.Name);
            List<FileInfo> fileList = new List<FileInfo>();

            for (int i = 0; i < Globals.MAX_FOLDERS; i++)
            {
                if (String.IsNullOrEmpty(Settings.File.InputFolderList[i]))
                    continue;

                if (!Directory.Exists(Settings.File.InputFolderList[i]))
                    continue;

                foreach (string pattern in patterns)
                    fileList.AddRange(FileIO.GetFileList(Settings.File.InputFolderList[i], pattern, Settings.General.Recursive));
            }

            if (fileList.Count == 0)
            {
                error = "No Files Found";
                return (false, output, error);
            }

            Size textureSize = (Settings.General.AutoSizeTexture ? Settings.General.MinTextureSize : Settings.General.TextureSize);
            List<ImageNode> imageList = new List<ImageNode>();
            Dictionary<string, List<string>> imageSequence = new Dictionary<string, List<string>>();
            int textureCount = 0, imageIndex = 0;
            RectanglePacker rectPacker;
            int index = 0;

            // Stage 1 Process files
            foreach (FileInfo fileInfo in fileList)
            {
                string fileName = fileInfo.FullName;
                Match match = Regex.Match(fileInfo.Name, @"^(?<name>.+)(?<suffix>\d{2})\.(?<extension>\w+)$");

                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    string suffix = match.Groups["suffix"].Value;

                    if (!imageSequence.ContainsKey(name))
                        imageSequence[name] = new List<string>();

                    imageSequence[name].Add(fileName);
                }
                else
                {
                    imageList.AddRange(ImageNode.ProcessFile(ref index, fileInfo.FullName));
                }
            }

            imageList.AddRange(ImageNode.ProcessFiles(ref index, imageSequence));

            if (!Settings.General.AutoSizeTexture)
            {
                if (IsAtlasTooSmall(imageList, Settings.General.Spacing, textureSize))
                {
                    error = "Texture Size Too Small";
                    return (false, output, error);
                }
            }

            imageList.Sort(new ImageNode());
            imageList.Sort(new ImageSizeComparer());

            rectPacker = new RectanglePacker(textureSize.Width, textureSize.Height);
            Baker76.Imaging.Color[] paletteColors = await PalFile.Read(Settings.File.PaletteFileName);
            Palette palette = new Palette(paletteColors);
            List<TextureNode> textureList = new List<TextureNode>();
            TextureNode textureNode = null;

            textureList.Add(textureNode = new TextureNode(textureSize.Width, textureSize.Height, Settings.General.TextureFormat));

            // Stage 2 Replace background color
            if (Settings.General.ReplaceBackgroundColor)
            {
                foreach (ImageNode imageNode in imageList)
                {
                    Image image = imageNode.Image;

                    if (image.BitsPerPixel <= 8)
                    {
                        if (image.Palette.IsTransparent)
                            image.Palette.Colors[image.Palette.TransparentColor] = Settings.General.BackColor;
                        else
                            image.Palette.Colors[0] = Settings.General.BackColor;
                    }
                }
            }

            // Stage 3 Quantize images
            if (Settings.General.Quantize)
            {
                foreach (ImageNode imageNode in imageList)
                {
                    Image image = imageNode.Image;
                    int paletteSlot = Settings.General.PaletteSlot;

                    if (Settings.General.BitDepth <= 8)
                    {
                        if (image.BitsPerPixel <= 8)
                            image = image.ToRGBA();

                        ColorQuantizerOptions options = new ColorQuantizerOptions
                        {
                            Palette = paletteColors,
                            ColorCountTarget = Settings.General.ColorCount,
                            BackgroundIndex = Settings.General.BackgroundIndex,
                            PaletteSlot = paletteSlot,
                            AutoPaletteSlot = Settings.General.AutoPaletteSlot,
                            PaletteSlotAddIndex = Settings.General.PaletteSlotAddIndex,
                            RemapPalette = Settings.General.RemapPalette,
                            DistanceType = Settings.General.ColorDistance
                        };

                        WuAlphaColorQuantizer quantizer = new WuAlphaColorQuantizer();
                        ColorQuantizerResult result = quantizer.Quantize(image.PixelData, options);

                        if (!options.RemapPalette)
                            palette = new Palette(result.ColorPalette);

                        imageNode.PaletteSlot = options.PaletteSlot;
                        imageNode.Image = new Image(image.Width, image.Height, 8, palette, result.Bytes);
                    }

                    if (worker != null)
                        worker.ReportProgress((imageList.IndexOf(imageNode) + 1) * 100 / imageList.Count);
                }
            }

            // Stage 4 Pack images
            while (!IsAtlasDone(imageList))
            {
                foreach (ImageNode imageNode in imageList)
                {
                    if (imageNode.Processed)
                        continue;

                    try
                    {
                        Point imagePoint = Point.Empty;
                        Size imageSize = new Size(Math.Min(imageNode.Width, textureSize.Width - Settings.General.Spacing), Math.Min(imageNode.Height, textureSize.Height - Settings.General.Spacing));
                        int backgroundIndex = (Settings.General.PaletteSlotAddIndex ? Settings.General.BackgroundIndex + (imageNode.PaletteSlot * 16) : Settings.General.BackgroundIndex);
                        Rectangle trimmedRect = (Settings.General.TrimBackground && imageNode.ImageType != ImageType.Aseprite ? Baker76.Imaging.Utility.GetTrimmedBackgroundRect(imageNode.Image, backgroundIndex) : new Rectangle(0, 0, imageNode.Width, imageNode.Height));
                        Rectangle frameRect = new Rectangle(-trimmedRect.X, -trimmedRect.Y, imageSize.Width, imageSize.Height);
                        imageSize = new Size(trimmedRect.Width, trimmedRect.Height);

                        if (rectPacker.FindPoint(new Size(imageSize.Width + Settings.General.Spacing, imageSize.Height + Settings.General.Spacing), ref imagePoint))
                        {
                            int halfSpacing = Settings.General.Spacing / 2;
                            Point imageOffset = new Point(imagePoint.X + halfSpacing, imagePoint.Y + halfSpacing);

                            imageNode.Index = imageIndex;
                            imageNode.TextureNode = textureNode;
                            imageNode.X = imageOffset.X;
                            imageNode.Y = imageOffset.Y;
                            imageNode.Width = imageSize.Width;
                            imageNode.Height = imageSize.Height;
                            imageNode.FrameX = -frameRect.X;
                            imageNode.FrameY = -frameRect.Y;
                            imageNode.FrameWidth = frameRect.Width;
                            imageNode.FrameHeight = frameRect.Height;
                            imageNode.Processed = true;

                            textureNode.ImageList.Add(imageNode);

                            imageIndex++;
                        }
                    }
                    catch
                    {
                        imageNode.Processed = true;
                    }

                    if (worker != null)
                        worker.ReportProgress((imageList.IndexOf(imageNode) + 1) * 100 / imageList.Count);
                }

                if (IsAtlasDone(imageList))
                    break;

                if (Settings.General.AutoSizeTexture)
                {
                    ResetAtlas(textureNode.ImageList);

                    textureSize.Width <<= 1;
                    textureSize.Height <<= 1;

                    if (textureSize.Width > Settings.General.MaxTextureSize.Width || textureSize.Height > Settings.General.MaxTextureSize.Height)
                    {
                        error = "Texture Size Too Large";
                        return (false, output, error);
                    }

                    rectPacker = new RectanglePacker(textureSize.Width, textureSize.Height);

                    textureNode.Width = textureSize.Width;
                    textureNode.Height = textureSize.Height;
                    textureNode.ImageList.Clear();

                    continue;
                }

                rectPacker = new RectanglePacker(textureSize.Width, textureSize.Height);

                textureList.Add(textureNode = new TextureNode(textureSize.Width, textureSize.Height, Settings.General.TextureFormat));

                textureCount++;
            }

            // Stage 5 Write images
            foreach (TextureNode texture in textureList)
            {
                Image textureImage = CreateTextureImage(textureSize, palette);

                textureNode.ImageList.Sort(new ImageNode());

                foreach (ImageNode imageNode in texture.ImageList)
                {
                    Image image = imageNode.Image;
                    Point imagePoint = new Point(imageNode.X, imageNode.Y);
                    Size imageSize = new Size(imageNode.Width, imageNode.Height);
                    Rectangle trimmedRect = new Rectangle(imageNode.FrameX, imageNode.FrameY, imageSize.Width, imageSize.Height);

                    textureImage.DrawImage(image, new Rectangle(imagePoint, imageSize), trimmedRect);

                    if (Settings.General.FillSpacing)
                        Baker76.Imaging.Utility.FillSpacing(textureImage, image, imagePoint, imageSize, Settings.General.Spacing);
                }

                textureNode.Name = Settings.General.Name + (Settings.General.MultiTexture && textureList.Count > 1 ? textureList.IndexOf(texture).ToString("00") : String.Empty);
                textureNode.FileName = textureNode.Name + ".png";
                textureNode.Path = Path.Combine(Settings.File.OutputFolder, textureNode.FileName);            

                PngWriter.Write(textureNode.Path, textureImage);
                //Bmp.TryWrite(Path.ChangeExtension(textureNode.Path, "bmp"), textureImage);


                if (worker != null)
                    worker.ReportProgress((textureList.IndexOf(texture) + 1) * 100 / textureList.Count);
            }

            // Stage 6 Write metadata
            switch (Settings.General.FileFormat)
            {
                case FileFormat.Bin:
                    TextureNode.WriteBin(fullPath + ".crch", textureList);
                    break;
                case FileFormat.Text:
                    TextureNode.WriteTxt(fullPath + ".txt", textureList);
                    break;
                case FileFormat.Json:
                    TextureNode.WriteJson(fullPath + ".json", textureList);
                    break;
                case FileFormat.Xml:
                    TextureNode.WriteXml(fullPath + ".xml", textureList);
                    break;
                case FileFormat.Meta:
                    TextureNode.WriteMeta(textureList);
                    break;
            }

            return (true, output, error);
        }
    }

    public class BatchSettings
    {
        public string SourceDirectory;
        public string DestinationDirectory;
        public string OutputFileName;
        public Size OutputSize;
        public string PaletteFileName;
        public Color[] ColorPalette;
        public int TransparentIndex;
        public bool SwapMagentaWithTransparentIndex;
        public bool SortSizes;
        public bool SortColors;
        public bool Quantize;
        public bool AddPaletteOffset;
        public bool CreateCombinedImage;
        public bool AutoPosition;
        public int MaxPaletteCount;
    }

    public class SliceNode
    {
        public string FileName = null;
        public Point Position = Point.Empty;
        public Size Size = Size.Empty;

        public SliceNode(string fileName, Point position, Size size)
        {
            FileName = fileName;
            Position = position;
            Size = size;
        }
    }
}
