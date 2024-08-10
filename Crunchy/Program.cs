using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.Linq;
using static Baker76.Imaging.Aseprite;
using System.ComponentModel;
using System.Drawing.Imaging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Runtime.InteropServices.ComTypes;
using System.Text.RegularExpressions;
using System.Diagnostics.Metrics;

namespace Crunchy
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            //args = new string[] { "C:\\Users\\headk\\Desktop\\Crunchy\\bin\\Debug\\Tyvarian2\\SpriteSheet.ini" };

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
                if (layout)
                {
                    foreach (string file in fileList)
                    {
                        var task = Task.Run(async () =>
                        {
                            await TextureAtlas.ProcessLayoutFile(file);
                        });
                    }
                }
                else
                {
                    for (int i = 0; i < Globals.MAX_FOLDERS; i++)
                        Settings.File.InputFolderList.Add(String.Empty);

                    foreach (string file in fileList)
                    {
                        Settings.File.FileName = file;

                        TextureAtlas.ReadConfig(Path.Combine(Application.StartupPath, Settings.File.FileName));

                        var task = Task.Run(async () =>
                        {
                            return await TextureAtlas.ProcessAtlasFiles(null);
                        });

                        (bool success, string output, string error) = task.Result;

                        Console.WriteLine(output);
                        Console.Error.WriteLine(error);
                    }
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
            Console.WriteLine("Crunchy v{0}", Globals.Version);
            Console.WriteLine("Usage: Crunch <filename> [-process]\n");
            Console.WriteLine("Options:");
            Console.WriteLine("-h or -?            Display basic help");
            Console.WriteLine("<filename>          Config file or layout file");
            Console.WriteLine("-layout             Process the layout file");
        }
    }
}
