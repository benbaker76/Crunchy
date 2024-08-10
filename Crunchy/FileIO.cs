using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Crunchy
{
	public class FileIO
	{
		public static DateTime GetFileLastWriteTime(string fileName)
		{
			try
			{
				return File.GetLastWriteTime(fileName);
			}
			catch
			{
			}

			return DateTime.MinValue;
		}

        public static bool TryOpenFile(Form owner, string initialDirectory, string initialFileName, string fileFormat, string[] extensions, out string fileName)
        {
            fileName = null;

            try
            {
                OpenFileDialog fd = new OpenFileDialog();

                fd.Title = "Open File";
                fd.InitialDirectory = initialDirectory;
                fd.FileName = initialFileName;
                fd.Filter = String.Format("{0} ({1})|*{2}|All Files (*.*)|*.*", fileFormat, String.Join(",", extensions).Replace(".", "").ToUpper(), String.Join(";*", extensions));
                fd.RestoreDirectory = true;
                fd.CheckFileExists = true;

                if (fd.ShowDialog(owner) == DialogResult.OK)
                {
                    fileName = fd.FileName;

                    /* if (Convert.IsWindows())
                    {
                        Win32.RemoveMouseUpMessage();
                    } */

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }

        public static bool TrySaveFile(Control parent, string initialDirectory, string initialFileName, string fileFormat, string[] extensions, out string fileName)
        {
            fileName = null;

            try
            {
                SaveFileDialog fd = new SaveFileDialog();

                fd.Title = "Save Layout";
                fd.InitialDirectory = initialDirectory;
                fd.FileName = initialFileName;
                fd.Filter = String.Format("{0} ({1})|*{2}|All Files (*.*)|*.*", fileFormat, String.Join(",", extensions).Replace(".", "").ToUpper(), String.Join(";*", extensions));
                fd.OverwritePrompt = false;
                fd.RestoreDirectory = true;

                if (fd.ShowDialog(parent) == DialogResult.OK)
                {
                    fileName = fd.FileName;

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }

        public static bool TryOpenFolder(Control parent, string selectedPath, out string folder)
		{
			folder = null;

			try
			{
				FolderBrowserDialog fb = new FolderBrowserDialog();

				fb.SelectedPath = selectedPath;
				fb.ShowNewFolderButton = true;

				if (fb.ShowDialog(parent) == DialogResult.OK)
				{
					folder = fb.SelectedPath;

					return true;
				}
			}
			catch (Exception ex)
			{
				//LogFile.WriteEntry("TryOpenFolder", "FileIO", ex.Message, ex.StackTrace);
			}

			return false;
		}

		public static List<FileInfo> GetFileList(string path, string[] searchPattern, bool recursive)
		{
			List<FileInfo> fileList = new List<FileInfo>();

			foreach (string ext in searchPattern)
				fileList.AddRange(GetFileList(path, ext, recursive));

			return fileList;
		}

		public static List<FileInfo> GetFileList(string path, string searchPattern, bool recursive)
		{
			List<FileInfo> fileList = new List<FileInfo>();
			DirectoryInfo di = new DirectoryInfo(path);
			FileInfo[] fileInfo = di.GetFiles(searchPattern);

			DirectoryInfo[] directoryInfo = di.GetDirectories();

			if (recursive)
			{
				foreach (DirectoryInfo diSub in directoryInfo)
					fileList.AddRange(GetFileList(diSub.FullName, searchPattern, recursive));
			}

			foreach (FileInfo fi in fileInfo)
				fileList.Add(fi);

			return fileList;
		}
	}
}
