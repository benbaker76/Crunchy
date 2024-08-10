using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Collections;
using System.Drawing;
using Baker76.Imaging;

namespace Crunchy
{
    public enum FileFormat
    {
        Bin,
        Text,
        Json,
        Xml,
		Meta
    };

    public class Globals
    {
        public const int MAX_FOLDERS = 10;
        public const string Version = "1.0.0";

        public static string[] BitDepthStrings
        {
            get
            {
                return new string[] { "8", "24", "32" };
            }
        }
    }

    public class Settings
    {
        public class General
        {
            public static bool Recursive = false;
            public static string Name = "texture";
			public static FileFormat FileFormat = FileFormat.Bin;
            public static bool MultiTexture = false;
            public static int BitDepth = 8;
            public static bool AutoSizeTexture = true;
            public static Size TextureSize = new Size(256, 256);
            public static Size MinTextureSize = new Size(16, 16);
            public static Size MaxTextureSize = new Size(4096, 4096);
            public static int TextureFormat = 0;
            public static bool AlphaBackground = true;
            public static bool ColorBackground = false;
            public static bool IndexBackground = false;
            public static Baker76.Imaging.Color BackColor = Baker76.Imaging.Color.FromArgb(unchecked((int)0xFFFF00FF));
            public static int BackgroundIndex = 0;
            public static bool ReplaceBackgroundColor = false;
            public static DistanceType ColorDistance = DistanceType.CIEDE2000;
            public static int Spacing = 1;
            public static bool FillSpacing = false;
            public static bool TrimBackground = true;
            public static bool Quantize = false;
            public static bool AutoPaletteSlot = true;
            public static bool RemapPalette = true;
            public static int PaletteSlot = 0;
            public static int ColorCount = 16;
            public static bool PaletteSlotAddIndex = false;
        }

        public class File
        {
            public static string FileName = "Crunchy.ini";
            public static string DefaultFileName = "Crunchy.ini";
            public static string PaletteFileName = "";
            public static string OutputFolder = "";
            public static List<string> InputFolderList = new List<string>();
        }
    }
}
