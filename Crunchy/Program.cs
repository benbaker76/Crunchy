using Baker76.Imaging;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static Baker76.Imaging.Aseprite;
using static System.Windows.Forms.Design.AxImporter;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Crunchy
{
    static class Program
    {
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;

        [DllImport("kernel32.dll")]
        static extern bool FreeConsole();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            //args = new string[] { "-layout", "C:\\Users\\headk\\Desktop\\Crunchy\\bin\\Debug\\Tyvarian2\\SpriteSheet.ini" };
            //args = new string[] { "-layout", "Graphics\\AnimatedSprites\\AnimatedSprites.ini" };
            //args = new string[] { "-layout", "Graphics\\SpritesMain.ini" };
            //args = new string[] { "-layout", "Graphics\\GameSprites\\SpriteSheet.ini" };
            //args = new string[] { "-layout", "Graphics\\GameTiles\\TileSheet.ini" };

            List<string> fileList = new List<string>();
            bool layout = false;

            for (int i = 0; i < args.Length; i++)
            {
                string arg = args[i].ToLower();

                if (arg.StartsWith("-"))
                {
                    if (arg == "-?" || arg == "-h")
                    {
                        DisplayHelp();
                        return 1;
                    }

                    if (arg == "-layout")
                    {
                        layout = true;
                    }
                }
                else
                {
                    fileList.Add(args[i]);
                }
            }

            if (fileList.Count > 0)
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    AttachConsole(ATTACH_PARENT_PROCESS);
                }

                if (layout)
                {
                    foreach (string file in fileList)
                        TextureManager.ProcessLayoutFile(file).Wait();
                }
                else
                {
                    for (int i = 0; i < Globals.MAX_FOLDERS; i++)
                        Settings.File.InputFolderList.Add(String.Empty);

                    List<DiskFileSource> fileSources = new List<DiskFileSource>();

                    foreach (string file in fileList)
                    {
                        Settings.File.FileName = file;

                        TextureManager.ReadConfig(Path.Combine(Application.StartupPath, Settings.File.FileName), Settings.General);

                        TextureManager.ParseAtlas(null, Settings.General, null);
                    }
                }

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    FreeConsole();
                }

                return 1;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());

            return 1;
        }

        public static void DisplayHelp()
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;

            Console.WriteLine("Crunchy v{0}", version.ToString(3));
            Console.WriteLine("Usage: Crunch <filename> [-process]\n");
            Console.WriteLine("Options:");
            Console.WriteLine("-h or -?            Display basic help");
            Console.WriteLine("<filename>          Config file or layout file");
            Console.WriteLine("-layout             Process the layout file");
        }
    }
}
