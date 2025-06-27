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
        public static CrunchOptions General = new CrunchOptions();

        public class File
        {
            public static string FileName = "Crunchy.ini";
            public static string DefaultFileName = "Crunchy.ini";
            public static string PaletteFileName = "";
            public static string OutputFolder = "";
            public static FileFormat FileFormat = FileFormat.Bin;
            public static List<string> InputFolderList = new List<string>();
        }
    }
}
