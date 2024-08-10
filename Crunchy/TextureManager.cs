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

namespace Crunchy
{
	public enum ImageType
	{
		Png,
        Aseprite
    };

    public class ImageSizeComparer : IComparer<ImageNode>
    {
        public int Compare(ImageNode x, ImageNode y)
        {
            int areaX = x.Width * x.Height;
            int areaY = y.Width * y.Height;

            return -areaX.CompareTo(areaY);
        }
    }

    public class PaletteLengthComparer : IComparer<ImageNode>
    {
        public int Compare(ImageNode x, ImageNode y)
        {
            return x.Image.Palette.Colors.Count.CompareTo(y.Image.Palette.Colors.Count);
        }
    }

    public class ClosestPaletteSlotComparer : IComparer<ImageNode>
    {
        public int Compare(ImageNode x, ImageNode y)
        {
            return x.ClosestPaletteSlot.CompareTo(y.ClosestPaletteSlot);
        }
    }

    public class PaletteSlotCountComparer : IComparer<ImageNode>
    {
        public int Compare(ImageNode x, ImageNode y)
        {
            return x.PaletteSlotCount.CompareTo(y.PaletteSlotCount);
        }
    }

    public class ImageNode : IComparer<ImageNode>
	{
		public int Index = -1;
		public string FileName = String.Empty;
		public int FrameIndex = 0;
        public string Name = String.Empty;
        public string Label = String.Empty;
		public int LoopDirection = 0;
        public int Duration = 0;
        public int X = 0;
		public int Y = 0;
		public int Width = 0;
		public int Height = 0;
		public int FrameX = 0;
		public int FrameY = 0;
		public int FrameWidth = 0;
		public int FrameHeight = 0;
		public int PaletteSlot = -1;
        public int ClosestPaletteSlot = -1;
        public int PaletteSlotCount = 0;
        public TextureNode TextureNode = null;
		public Image Image = null;
		public Color[] Palette = null;
        public ImageType ImageType = ImageType.Png;
        public bool Processed = false;
		public bool NoFit = false;

        public Rectangle Rect { get { return new Rectangle(X, Y, Width, Height); } }
		public RectangleF RectF { get { return new RectangleF((float)X / TextureNode.Width, (float)Y / TextureNode.Height, (float)Width / TextureNode.Width, (float)Height / TextureNode.Height); } }

        public ImageNode()
		{
		}

        public ImageNode(int index, string fileName)
        {
            Index = index;
            FileName = fileName;

            Size size = Baker76.Imaging.Utility.GetImageSize(fileName);
            Width = size.Width;
            Height = size.Height;
        }

        public ImageNode(int index, string fileName, int x, int y, int paletteSlot)
		{
            Index = index;
            FileName = fileName;
			X = x;
			Y = y;
			PaletteSlot = paletteSlot;

			Size size = Baker76.Imaging.Utility.GetImageSize(fileName);
			Width = size.Width;
			Height = size.Height;
        }

        public ImageNode(string name, int x, int y, int width, int height)
		{
			Name = name;
            X = x;
            Y = y;
            Width = width;
            Height = height;
			FrameX = 0;
			FrameY = 0;
			FrameWidth = width;
			FrameHeight = height;
		}

		public ImageNode(TextureNode textureNode)
		{
			TextureNode = textureNode;
			Name = textureNode.Name;
			Width = textureNode.Width;
			Height = textureNode.Height;
		}

        public ImageNode(int index, string name, Image image, ImageType imageType)
        {
            Index = index;
            Name = name;
            Width = image.Width;
            Height = image.Height;
            Image = image;
            ImageType = imageType;
        }

        public ImageNode(TextureNode textureNode, int index, int frameIndex, string name, string label, int loopDirection, int duration, int x, int y, int width, int height, int frameX, int frameY, int frameWidth, int frameHeight)
		{
			TextureNode = textureNode;
            Index = index;
            FrameIndex = frameIndex;
            Name = name;
			Label = label;
			LoopDirection = loopDirection;
			Duration = duration;
			X = x;
			Y = y;
			Width = width;
			Height = height;
			FrameX = frameX;
			FrameY = frameY;
			FrameWidth = frameWidth;
			FrameHeight = frameHeight;
		}

        public ImageNode(int index, int frameIndex, string name, string label, int loopDirection, int duration, Image image, ImageType imageType)
        {
            Index = index;
            FrameIndex = frameIndex;
            Name = name;
            Width = image.Width;
            Height = image.Height;
            Label = label;
            LoopDirection = loopDirection;
            Duration = duration;
            Image = image;
            ImageType = imageType;
        }

        public static List<ImageNode> ProcessFile(ref int index, string fileName)
        {
            List<ImageNode> imageList = new List<ImageNode>();
            string name = Path.GetFileNameWithoutExtension(fileName);
            string extension = Path.GetExtension(fileName).ToLower();

            if (extension == ".ase" || extension == ".aseprite")
            {
                Aseprite sprite = new Aseprite(fileName);

                for (int i = 0; i < sprite.Frames.Count; i++)
                {
                    Frame frame = sprite.Frames[i];
                    var firstTagForFrame = sprite.Tags.FirstOrDefault(tag => tag.From <= i && tag.To >= i);
                    string label = String.Empty;
                    int loopDirection = 0;

                    if (firstTagForFrame != null)
                    {
                        label = firstTagForFrame.Name ?? "";
                        loopDirection = (int)firstTagForFrame.LoopDirection;
                    }

                    imageList.Add(new ImageNode(index++, i + 1, name, label, loopDirection, frame.Duration, frame.Image, ImageType.Aseprite));
                }
            }
            else if (extension == ".bmp")
            {
                Image image = Bitmap.Read(fileName);
               
				imageList.Add(new ImageNode(index++, name, image, ImageType.Png));
            }
            else if (extension == ".png")
            {
                Image image = PngReader.Read(fileName);

                imageList.Add(new ImageNode(index++, name, image, ImageType.Png));
            }

            return imageList;
        }

        public static List<ImageNode> ProcessFiles(ref int index, Dictionary<string, List<string>> imageSequence)
        {
            List<ImageNode> imageList = new List<ImageNode>();

            foreach (var sequence in imageSequence)
            {
                string name = sequence.Key;
                List<string> sequenceFiles = sequence.Value;

                sequenceFiles.Sort();

                int frameIndex = 1;

                foreach (string fileName in sequenceFiles)
                {
                    string extension = Path.GetExtension(fileName).ToLower();
                    Image image = extension == ".png" ? PngReader.Read(fileName) : Bitmap.Read(fileName);

                    imageList.Add(new ImageNode(index++, frameIndex++, name, "", 0, 100, image, ImageType.Png));
                }
            }

            return imageList;
        }

        #region IComparer<ImageNode> Members

        public int Compare(ImageNode x, ImageNode y)
        {
            if (x.Name != y.Name)
                return x.Name.CompareTo(y.Name);

            if (x.Label != y.Label)
                return x.Label.CompareTo(y.Label);

            return x.FrameIndex.CompareTo(y.FrameIndex);
        }

        #endregion
    };

	public class TextureNode
	{
		private enum XmlElement
		{
			None,
			Texture,
			Image
		}

		public string FileName = String.Empty;
		public string Name = String.Empty;
		public string Path = String.Empty;
        public int Width = 0;
        public int Height = 0;
        public int Format = 0;
		public bool Clamp = true;
		public bool Linear = true;
		public bool ColorKey = false;
		//public Texture2D Texture = null;
		public List<ImageNode> ImageList = null;
		public bool UseRefCount = true;
		public int RefCount = 0;

        public TextureNode()
        {
            ImageList = new List<ImageNode>();
        }

        public TextureNode(int width, int height, int format)
		{
			Width = width;
			Height = height; 
			Format = format;
            ImageList = new List<ImageNode>();
		}

		/* public TextureNode(string name, Texture2D texture)
		{
			Name = name;
			Texture = texture;
			FileName = texture.FileName;
			TextureSize = texture.Size;
			Clamp = texture.Clamp;
			Linear = texture.Linear;
			ImageList = new List<ImageNode>();
		} */

		public TextureNode(string fileName, string name, int width, int height)
		{
			FileName = fileName;
			Name = name;
            Width = width;
            Height = height;
            ImageList = new List<ImageNode>();
		}

		public TextureNode(string fileName, string name, bool clamp, bool linear)
		{
			FileName = fileName;
			Name = name;
			Clamp = clamp;
			Linear = linear;
			ImageList = new List<ImageNode>();
		}

		public TextureNode(string fileName, string name, int width, int height, bool clamp, bool linear)
		{
			FileName = fileName;
			Name = name;
            Width = width;
            Height = height;
            Clamp = clamp;
			Linear = linear;
			ImageList = new List<ImageNode>();
		}

		public static TextureNode ReadXml(string fileName)
		{
			XmlReader xmlReader = null;
			XmlElement xmlElement = XmlElement.None;
			Hashtable attribHash = new Hashtable();
			TextureNode textureNode = null;

			try
			{
				xmlReader = XmlReader.Create(fileName);

				xmlReader.Read();

				while (xmlReader.Read())
				{
					switch (xmlReader.NodeType)
					{
						case XmlNodeType.Element:
							switch (xmlReader.LocalName.ToLower())
							{
								case "texture":
									xmlElement = XmlElement.Texture;
									textureNode = new TextureNode();
									break;
								case "image":
									xmlElement = XmlElement.Image;
									break;
								default:
									xmlElement = XmlElement.None;
									break;
							}

							if (xmlReader.HasAttributes)
							{
								attribHash.Clear();
								while (xmlReader.MoveToNextAttribute())
									attribHash.Add(xmlReader.Name.ToLower(), xmlReader.Value);
							}

							switch (xmlElement)
							{
								case XmlElement.Texture:
									if (textureNode != null)
									{
										textureNode.FileName = System.IO.Path.Combine((string)attribHash["path"], (string)attribHash["name"]);
										textureNode.Name = (string)attribHash["name"];
										textureNode.Path = (string)attribHash["path"];
										textureNode.Width = StringTools.FromString<int>((string)attribHash["width"]);
                                        textureNode.Height = StringTools.FromString<int>((string)attribHash["height"]);
                                        textureNode.Clamp = StringTools.FromString<bool>((string)attribHash["clamp"]);
										textureNode.Linear = StringTools.FromString<bool>((string)attribHash["linear"]);
										textureNode.ColorKey = StringTools.FromString<bool>((string)attribHash["colorkey"]);
									}
									break;
								case XmlElement.Image:
									if (textureNode != null)
										textureNode.ImageList.Add(new ImageNode(textureNode, StringTools.FromString<int>((string)attribHash["id"]), StringTools.FromString<int>((string)attribHash["frameindex"]), (string)attribHash["name"], (string)attribHash["label"], StringTools.FromString<int>((string)attribHash["loopdirection"]), StringTools.FromString<int>((string)attribHash["duration"]), StringTools.FromString<int>((string)attribHash["x"]), StringTools.FromString<int>((string)attribHash["y"]), StringTools.FromString<int>((string)attribHash["width"]), StringTools.FromString<int>((string)attribHash["height"]), StringTools.FromString<int>((string)attribHash["framex"]), StringTools.FromString<int>((string)attribHash["framey"]), StringTools.FromString<int>((string)attribHash["framewidth"]), StringTools.FromString<int>((string)attribHash["frameheight"])));
									break;
								default:
									break;
							}

							xmlReader.MoveToElement();
							break;

						case XmlNodeType.Text:
							string text = xmlReader.Value.Trim();
							switch (xmlElement)
							{
								default:
									break;
							}
							break;

						case XmlNodeType.EndElement:
							switch (xmlElement)
							{
								case XmlElement.Texture:
									textureNode = null;
									break;
								default:
									break;
							}
							break;
					}
				}
			}
			catch (Exception ex)
			{
				//LogFile.WriteLine("ReadTextureXml", "TextureManager", ex.Message, ex.StackTrace);
			}
			finally
			{
				if (xmlReader != null)
				{
					xmlReader.Close();
					xmlReader = null;
				}
			}

			return textureNode;
		}

		public static void WriteBin(string fileName, List<TextureNode> textureList)
		{
			try
			{
				using (FileStream fs = new FileStream(fileName, FileMode.Create))
				{
					using (BinaryWriter writer = new BinaryWriter(fs))
					{
						writer.Write(new char[] { 'c', 'r', 'c', 'h' });
						writer.Write((ushort)0);
						writer.Write((byte)(Settings.General.TrimBackground ? 1 : 0));
						writer.Write((byte)0);
						writer.Write((byte)3);
						writer.Write((ushort)1);

						foreach (TextureNode textureNode in textureList)
						{
							writer.Write(Encoding.ASCII.GetBytes(textureNode.Name.PadRight(16, '\0')));
							writer.Write((ushort)textureNode.Width);
							writer.Write((ushort)textureNode.Height);
							writer.Write((ushort)textureNode.Format);
							writer.Write((ushort)textureNode.ImageList.Count);

							foreach (ImageNode imageNode in textureNode.ImageList)
							{
								writer.Write((ushort)imageNode.FrameIndex);
								writer.Write(Encoding.ASCII.GetBytes(imageNode.Name.PadRight(16, '\0')));
								writer.Write(Encoding.ASCII.GetBytes(imageNode.Label.PadRight(16, '\0')));
								writer.Write((byte)imageNode.LoopDirection);
								writer.Write((ushort)imageNode.Duration);
								writer.Write((ushort)imageNode.X);
								writer.Write((ushort)imageNode.Y);
								writer.Write((ushort)imageNode.Width);
								writer.Write((ushort)imageNode.Height);
								if (Settings.General.TrimBackground)
								{
									writer.Write((ushort)imageNode.FrameX);
									writer.Write((ushort)imageNode.FrameY);
									writer.Write((ushort)imageNode.FrameWidth);
									writer.Write((ushort)imageNode.FrameHeight);
								}
								writer.Write((byte)imageNode.PaletteSlot);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
			}
        }

		public static void WriteTxt(string fileName, List<TextureNode> textureList)
		{
			List<string> textList = new List<string>();

			foreach(TextureNode textureNode in textureList)
			{
                textList.Add(String.Format("tex n={0} w={1} h={2} n={3}", textureNode.Name, textureNode.Width, textureNode.Height, textureNode.ImageList.Count));

                foreach (ImageNode imageNode in textureNode.ImageList)
                    textList.Add(String.Format("img fi={0} n={1} l={2} ld={3} d={4} x={5} y={6} w={7} h={8} fx={9} fy={10} fw={11} fh={12} ps={13}", imageNode.FrameIndex, imageNode.Name, imageNode.Label, imageNode.LoopDirection, imageNode.Duration, imageNode.X, imageNode.Y, imageNode.Width, imageNode.Height, imageNode.FrameX, imageNode.FrameY, imageNode.FrameWidth, imageNode.FrameHeight, imageNode.PaletteSlot));
            }

			File.WriteAllLines(fileName, textList.ToArray());
		}

        public static void WriteJson(string fileName, List<TextureNode> textureList)
        {
            try
            {
                using (StreamWriter jsonWriter = new StreamWriter(fileName))
                {
                    jsonWriter.WriteLine("{");
                    jsonWriter.WriteLine("\t\"trim\":true,");
                    jsonWriter.WriteLine("\t\"rotate\":false,");
                    jsonWriter.WriteLine("\t\"textures\":[");

                    foreach (TextureNode textureNode in textureList)
                    {
                        jsonWriter.WriteLine("\t\t{");
                        jsonWriter.WriteLine($"\t\t\t\"name\":\"{textureNode.Name}\",");
                        jsonWriter.WriteLine($"\t\t\t\"width\":{textureNode.Width},");
                        jsonWriter.WriteLine($"\t\t\t\"height\":{textureNode.Height},");
                        jsonWriter.WriteLine($"\t\t\t\"format\":\"{textureNode.Format}\",");
                        jsonWriter.WriteLine("\t\t\t\"images\":[");

                        foreach (ImageNode imageNode in textureNode.ImageList)
                        {
                            jsonWriter.WriteLine("\t\t\t\t{");
                            jsonWriter.WriteLine($"\t\t\t\t\t\"fi\":{imageNode.FrameIndex},");
                            jsonWriter.WriteLine($"\t\t\t\t\t\"n\":\"{imageNode.Name}\",");
                            jsonWriter.WriteLine($"\t\t\t\t\t\"l\":\"{imageNode.Label}\",");
                            jsonWriter.WriteLine($"\t\t\t\t\t\"ld\":{imageNode.LoopDirection},");
                            jsonWriter.WriteLine($"\t\t\t\t\t\"d\":{imageNode.Duration},");
                            jsonWriter.WriteLine($"\t\t\t\t\t\"x\":{imageNode.X},");
                            jsonWriter.WriteLine($"\t\t\t\t\t\"y\":{imageNode.Y},");
                            jsonWriter.WriteLine($"\t\t\t\t\t\"w\":{imageNode.Width},");
                            jsonWriter.WriteLine($"\t\t\t\t\t\"h\":{imageNode.Height},");
                            jsonWriter.WriteLine($"\t\t\t\t\t\"fx\":{imageNode.FrameX},");
                            jsonWriter.WriteLine($"\t\t\t\t\t\"fy\":{imageNode.FrameY},");
                            jsonWriter.WriteLine($"\t\t\t\t\t\"fw\":{imageNode.FrameWidth},");
                            jsonWriter.WriteLine($"\t\t\t\t\t\"fh\":{imageNode.FrameHeight},");
                            jsonWriter.WriteLine($"\t\t\t\t\t\"ps\":{imageNode.PaletteSlot}");
                            jsonWriter.WriteLine("\t\t\t\t},");
                        }

                        jsonWriter.WriteLine("\t\t\t]");
                        jsonWriter.Write("\t\t}");
                        if (textureNode != textureList.Last())
                        {
                            jsonWriter.Write(",");
                        }
                        jsonWriter.WriteLine();
                    }

                    jsonWriter.WriteLine("\t]");
                    jsonWriter.WriteLine("}");
                }
            }
            catch (Exception ex)
            {
                // Handle exception
            }
        }

        public static void WriteXml(string fileName, List<TextureNode> textureList)
        {
            try
            {
                using (StreamWriter xml = new StreamWriter(fileName))
                {
                    xml.WriteLine("<atlas>");
                    xml.WriteLine("\t<trim>true</trim>");
                    xml.WriteLine("\t<rotate>false</rotate>");

					foreach (TextureNode textureNode in textureList)
					{
						xml.WriteLine("\t<tex n=\"" + textureNode.Name + "\" w=\"" + textureNode.Width + " h=\"" + textureNode.Height + "\" format=\"" + textureNode.Format + "\">");

						foreach (ImageNode imageNode in textureNode.ImageList)
							xml.WriteLine("\t\t<img fi=\"" + imageNode.FrameIndex + "\" n=\"" + imageNode.Name + "\" l=\"" + imageNode.Label + "\" ld=\"" + imageNode.LoopDirection + "\" d=\"" + imageNode.Duration + "\" x=\"" + imageNode.X + "\" y=\"" + imageNode.Y + "\" w=\"" + imageNode.Width + "\" h=\"" + imageNode.Height + "\" fx=\"" + imageNode.FrameX + "\" fy=\"" + imageNode.FrameY + "\" fw=\"" + imageNode.FrameWidth + "\" fh=\"" + imageNode.FrameHeight + "\" ps=\"" + imageNode.PaletteSlot + "\" />");

						xml.WriteLine("\t</tex>");
					}

                    xml.WriteLine("</atlas>");
                }
            }
            catch (Exception ex)
            {
                // Handle exception
            }
        }

        private static long UnixTimeNow()
		{
			var timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
			return (long)timeSpan.TotalSeconds;
		}

		public static void WriteMeta(List<TextureNode> textureList)
		{

			foreach (TextureNode textureNode in textureList)
			{
				List<string> textList = new List<string>();

				textList.Add("fileFormatVersion: 2");
				textList.Add(String.Format("guid: {0}", Guid.NewGuid().ToString("N")));
				textList.Add(String.Format("timeCreated: {0}", UnixTimeNow()));
				textList.Add("licenseType: Pro");
				textList.Add("TextureImporter:");
				textList.Add("  fileIDToRecycleName:");

				int fileID = 21300000;

				foreach (ImageNode imageNode in textureNode.ImageList)
				{
					textList.Add(String.Format("    {0}: {1}", fileID, imageNode.Name));

					fileID += 2;
				}

				textList.Add("  serializedVersion: 4");
				textList.Add("  mipmaps:");
				textList.Add("    mipMapMode: 0");
				textList.Add("    enableMipMap: 0");
				textList.Add("    sRGBTexture: 1");
				textList.Add("    linearTexture: 0");
				textList.Add("    fadeOut: 0");
				textList.Add("    borderMipMap: 0");
				textList.Add("    mipMapFadeDistanceStart: 1");
				textList.Add("    mipMapFadeDistanceEnd: 3");
				textList.Add("  bumpmap:");
				textList.Add("    convertToNormalMap: 0");
				textList.Add("    externalNormalMap: 0");
				textList.Add("    heightScale: 0.25");
				textList.Add("    normalMapFilter: 0");
				textList.Add("  isReadable: 0");
				textList.Add("  grayScaleToAlpha: 0");
				textList.Add("  generateCubemap: 6");
				textList.Add("  cubemapConvolution: 0");
				textList.Add("  seamlessCubemap: 0");
				textList.Add("  textureFormat: -3");
				textList.Add("  maxTextureSize: 2048");
				textList.Add("  textureSettings:");
				textList.Add("    filterMode: -1");
				textList.Add("    aniso: 16");
				textList.Add("    mipBias: -1");
				textList.Add("    wrapMode: 1");
				textList.Add("  nPOTScale: 0");
				textList.Add("  lightmap: 0");
				textList.Add("  compressionQuality: 50");
				textList.Add("  spriteMode: 2");
				textList.Add("  spriteExtrude: 1");
				textList.Add("  spriteMeshType: 0");
				textList.Add("  alignment: 0");
				textList.Add("  spritePivot: {x: 0.5, y: 0.5}");
				textList.Add("  spriteBorder: {x: 0, y: 0, z: 0, w: 0}");
				textList.Add("  spritePixelsToUnits: 1");
				textList.Add("  alphaUsage: 1");
				textList.Add("  alphaIsTransparency: 1");
				textList.Add("  spriteTessellationDetail: -1");
				textList.Add("  textureType: 8");
				textList.Add("  textureShape: 1");
				textList.Add("  maxTextureSizeSet: 0");
				textList.Add("  compressionQualitySet: 0");
				textList.Add("  textureFormatSet: 0");
				textList.Add("  platformSettings:");
				textList.Add("  - buildTarget: DefaultTexturePlatform");
				textList.Add("    maxTextureSize: 2048");
				textList.Add("    textureFormat: -1");
				textList.Add("    textureCompression: 0");
				textList.Add("    compressionQuality: 50");
				textList.Add("    crunchedCompression: 0");
				textList.Add("    allowsAlphaSplitting: 0");
				textList.Add("    overridden: 0");
				textList.Add("  - buildTarget: Standalone");
				textList.Add("    maxTextureSize: 2048");
				textList.Add("    textureFormat: -1");
				textList.Add("    textureCompression: 0");
				textList.Add("    compressionQuality: 50");
				textList.Add("    crunchedCompression: 0");
				textList.Add("    allowsAlphaSplitting: 0");
				textList.Add("    overridden: 0");
				textList.Add("  spriteSheet:");
				textList.Add("    serializedVersion: 2");
				textList.Add("    sprites:");

				foreach (ImageNode imageNode in textureNode.ImageList)
				{
					textList.Add("    - serializedVersion: 2");
					textList.Add(String.Format("      name: {0}", imageNode.Name));
					textList.Add("      rect:");
					textList.Add("        serializedVersion: 2");
					textList.Add(String.Format("        x: {0}", imageNode.X));
					textList.Add(String.Format("        y: {0}", textureNode.Height - imageNode.Y - imageNode.Height));
					textList.Add(String.Format("        width: {0}", imageNode.Width));
					textList.Add(String.Format("        height: {0}", imageNode.Height));
					textList.Add("      alignment: 0");
					textList.Add("      pivot: {x: 0.5, y: 0.5}");
					textList.Add("      border: {x: 0, y: 0, z: 0, w: 0}");
					textList.Add("      outline: []");
					textList.Add("      tessellationDetail: -1");
				}

				textList.Add("    outline: []");
				textList.Add("  spritePackingTag: ");
				textList.Add("  userData: ");
				textList.Add("  assetBundleName: ");
				textList.Add("  assetBundleVariant: ");

				File.WriteAllLines(textureNode.Path + ".meta", textList.ToArray());
			}
		}

		public int ImageCount
		{
			get { return ImageList.Count; }
		}
	}
}
