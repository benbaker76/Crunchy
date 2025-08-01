using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Collections;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static Baker76.Imaging.Aseprite;
using System.Reflection;
using System.Xml.Linq;
using System.Linq;
using System.Diagnostics.SymbolStore;
using Baker76.Imaging;
using Color = Baker76.Imaging.Color;
using Image = Baker76.Imaging.Image;
using Bitmap = Baker76.Imaging.Bitmap;
using Baker76.Core.IO;
using Baker76.ColorQuant;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Crunchy
{
    public class TextureManager
    {
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

        public static void ReadConfig(string fileName, CrunchOptions options)
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
            options.BitDepth = iniFile.GetValue<int>("General", "BitDepth", options.BitDepth);
            options.Recursive = iniFile.GetValue<bool>("General", "Recursive", options.Recursive);
            options.Name = iniFile.GetValue("General", "Name", options.Name);
            Settings.File.FileFormat = iniFile.GetValue<FileFormat>("General", "FileFormat", Settings.File.FileFormat);
            options.MultiTexture = iniFile.GetValue<bool>("General", "MultiTexture", options.MultiTexture);
            options.AutoSizeTexture = iniFile.GetValue<bool>("General", "AutoSizeTexture", options.AutoSizeTexture);
            options.TextureSize = iniFile.GetValue<Size>("General", "TextureSize", options.TextureSize);
            options.MinTextureSize = iniFile.GetValue<Size>("General", "MinTextureSize", options.MinTextureSize);
            options.MaxTextureSize = iniFile.GetValue<Size>("General", "MaxTextureSize", options.MaxTextureSize);
            options.AlphaBackground = iniFile.GetValue<bool>("General", "AlphaBackground", options.AlphaBackground);
            options.ColorBackground = iniFile.GetValue<bool>("General", "ColorBackground", options.ColorBackground);
            options.IndexBackground = iniFile.GetValue<bool>("General", "IndexBackground", options.IndexBackground);
            options.BackColor = Baker76.Imaging.Color.FromArgb(iniFile.GetValue<int>("General", "BackColor", options.BackColor.ToArgb()));
            options.BackgroundIndex = iniFile.GetValue<int>("General", "BackgroundIndex", options.BackgroundIndex);
            options.ReplaceBackgroundColor = iniFile.GetValue<bool>("General", "ReplaceBackgroundColor", options.ReplaceBackgroundColor);
            options.ColorDistance = iniFile.GetValue<DistanceType>("General", "ColorDistance", options.ColorDistance);
            options.Spacing = iniFile.GetValue<int>("General", "Spacing", options.Spacing);
            options.FillSpacing = iniFile.GetValue<bool>("General", "FillSpacing", options.FillSpacing);
            options.Quantize = iniFile.GetValue<bool>("General", "Quantize", options.Quantize);
            options.ColorCount = iniFile.GetValue<int>("General", "ColorCount", options.ColorCount);
            options.AutoPaletteSlot = iniFile.GetValue<bool>("General", "AutoPaletteSlot", options.AutoPaletteSlot);
            options.RemapPalette = iniFile.GetValue<bool>("General", "RemapPalette", options.RemapPalette);
            options.PaletteSlot = iniFile.GetValue<int>("General", "PaletteSlot", options.PaletteSlot);
            options.PaletteSlotAddIndex = iniFile.GetValue<bool>("General", "PaletteSlotAddIndex", options.PaletteSlotAddIndex);
            options.TrimBackground = iniFile.GetValue<bool>("General", "TrimBackground", options.TrimBackground);
        }

        public static void WriteConfig(string fileName, CrunchOptions options)
        {
            IniFile iniFile = new IniFile(fileName);

            iniFile.SetValue("General", "FileName", Path.GetFileName(Settings.File.FileName));
            iniFile.SetValue("General", "OutputFolder", Settings.File.OutputFolder);
            iniFile.SetValue("General", "PaletteFileName", Settings.File.PaletteFileName);

            for (int i = 0; i < Globals.MAX_FOLDERS; i++)
            {
                iniFile.SetValue("General", String.Format("Folder{0}", i + 1), Settings.File.InputFolderList[i]);
            }

            iniFile.SetValue<int>("General", "BitDepth", options.BitDepth);
            iniFile.SetValue<bool>("General", "Recursive", options.Recursive);
            iniFile.SetValue("General", "Name", options.Name);
            iniFile.SetValue<FileFormat>("General", "FileFormat", Settings.File.FileFormat);
            iniFile.SetValue<bool>("General", "MultiTexture", options.MultiTexture);
            iniFile.SetValue<bool>("General", "AutoSizeTexture", options.AutoSizeTexture);
            iniFile.SetValue<Size>("General", "TextureSize", options.TextureSize);
            iniFile.SetValue<Size>("General", "MinTextureSize", options.MinTextureSize);
            iniFile.SetValue<Size>("General", "MaxTextureSize", options.MaxTextureSize);
            iniFile.SetValue<bool>("General", "AlphaBackground", options.AlphaBackground);
            iniFile.SetValue<bool>("General", "ColorBackground", options.ColorBackground);
            iniFile.SetValue<bool>("General", "IndexBackground", options.IndexBackground);
            iniFile.SetValue<int>("General", "BackColor", options.BackColor.ToArgb());
            iniFile.SetValue<int>("General", "BackIndex", options.BackgroundIndex);
            iniFile.SetValue<bool>("General", "ReplaceBackgroundColor", options.ReplaceBackgroundColor);
            iniFile.SetValue<DistanceType>("General", "ColorDistance", options.ColorDistance);
            iniFile.SetValue<int>("General", "Spacing", options.Spacing);
            iniFile.SetValue<bool>("General", "FillSpacing", options.FillSpacing);
            iniFile.SetValue<bool>("General", "Quantize", options.Quantize);
            iniFile.SetValue<int>("General", "ColorCount", options.ColorCount);
            iniFile.SetValue<bool>("General", "AutoPaletteSlot", options.AutoPaletteSlot);
            iniFile.SetValue<bool>("General", "RemapPalette", options.RemapPalette);
            iniFile.SetValue<int>("General", "PaletteSlot", options.PaletteSlot);
            iniFile.SetValue<bool>("General", "TrimBackground", options.TrimBackground);
            iniFile.SetValue("General", "PaletteSlot", options.PaletteSlot);
            iniFile.SetValue<bool>("General", "PaletteSlotAddIndex", options.PaletteSlotAddIndex);

            iniFile.SaveToFile(fileName);
        }

        public static void GetBitmaps(List<ImageNode> imageList, BatchSettings settings, CrunchOptions options, out Color[] colorPalette)
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
                    originalBitmap = Baker76.Imaging.Pngcs.PngReader.Read(image.FileName);
                else if (extension == ".bmp")
                    originalBitmap = Bitmap.Read(image.FileName);

                if (!settings.Quantize && (originalBitmap.BitsPerPixel != 4 && originalBitmap.BitsPerPixel != 8))
                    continue;

                string name = Path.GetFileName(image.FileName);
                image.Image = originalBitmap;

                if (settings.Quantize)
                {
                    ColorQuantizerOptions colorQuantizerOptions = new ColorQuantizerOptions
                    {
                        //Palette = paletteColors,
                        ColorCountTarget = options.ColorCount,
                        BackgroundIndex = options.BackgroundIndex,
                        //PaletteSlot = paletteSlot,
                        AutoPaletteSlot = options.AutoPaletteSlot,
                        PaletteSlotAddIndex = options.PaletteSlotAddIndex,
                        DistanceType = options.ColorDistance
                    };

                    WuAlphaColorQuantizer quantizer = new WuAlphaColorQuantizer();
                    ColorQuantizerResult result = quantizer.Quantize(originalBitmap.PixelData, colorQuantizerOptions);
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
                Rectangle sourceRectangle = new Rectangle(0, 0, image.Width, image.Height);
                Point position = Point.Empty;

                if (rectanglePacker.FindPoint(sourceRectangle.Size, ref position))
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

            GetBitmaps(imageList, settings, Settings.General, out colorPalette);

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
                Rectangle sourceRectangle = new Rectangle(Point.Empty, bitmap.Size);
                Rectangle destRectangle = new Rectangle(image.X, image.Y, bitmap.Width, bitmap.Height);

                if (settings.AutoPosition)
                {
                    int destWidth = bitmap.Width, imageCount = 1;

                    destRectangle.Intersect(outputRectangle);
                    destWidth -= destRectangle.Width;

                    outputBitmap.DrawImage(bitmap, destRectangle, sourceRectangle);

                    while (destWidth > 0)
                    {
                        sourceRectangle = new Rectangle(bitmap.Width - destWidth, 0, destWidth, bitmap.Height);
                        destRectangle = new Rectangle(0, image.Y + bitmap.Height * imageCount, destWidth, bitmap.Height);

                        destRectangle.Intersect(outputRectangle);
                        destWidth -= destRectangle.Width;

                        outputBitmap.DrawImage(bitmap, destRectangle, sourceRectangle);

                        imageCount++;
                    }
                }
                else
                {
                    outputBitmap.DrawImage(bitmap, destRectangle, sourceRectangle);
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

        public static Image CreateTextureImage(Size textureSize, Palette palette, CrunchOptions options)
        {
            bool isIndexed = options.BitDepth <= 8;
            Image textureImage = new Image(textureSize.Width, textureSize.Height, System.Math.Max(options.BitDepth, 8), isIndexed ? palette : new Palette());

            if (options.ColorBackground)
                textureImage.Clear(options.BackColor);

            if (isIndexed && options.IndexBackground)
            {
                palette.TransparentColor = options.BackgroundIndex;
                textureImage.Clear(options.BackgroundIndex);
            }

            return textureImage;
        }

        public static async Task ParseAtlas(object sender, CrunchOptions options, Action<object, string, int> progressCallback)
        {
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

            Baker76.Imaging.Color[] paletteColors = await PalFile.Read(Settings.File.PaletteFileName);
            Palette palette = new Palette(paletteColors);

            IList<IFileSource> fileSources = new List<IFileSource>();

            foreach (var file in fileList)
                fileSources.Add(new DiskFileSource(file.FullName));

            List<(TextureNode, Baker76.Imaging.Image)> textures = await Crunch.ParseAtlas(sender, fileSources, palette, Settings.General, progressCallback);
            List<TextureNode> textureList = new List<TextureNode>();

            for (int i = 0; i < textures.Count; i++)
            {
                (TextureNode textureNode, Baker76.Imaging.Image textureImage) = textures[i];

                string fileName = textureNode.Name + ".png";
                string path = Path.Combine(Settings.File.OutputFolder, fileName);

                Baker76.Imaging.Pngcs.PngWriter.Write(path, textureImage);
                //Bmp.TryWrite(Path.ChangeExtension(textureNode.Path, "bmp"), textureImage);

                textureList.Add(textureNode);
            }

            switch (Settings.File.FileFormat)
            {
                case FileFormat.Bin:
                    Crunch.WriteBin(fullPath + ".crch", textureList, Settings.General.TrimBackground);
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
}
