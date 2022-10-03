using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Collections.Generic;
using System.IO.Compression;
using System.Web;
using System.Threading;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Runtime.InteropServices;
using dtlauncherform;

namespace DTlauncher
{
    static class Program
    {
		[DllImport("user32.dll", EntryPoint = "ShowCursor", CharSet = CharSet.Auto)]
		public extern static void ShowCursor(int status);
		
		[DllImport("kernel32.dll")]
		static extern IntPtr GetConsoleWindow();
		[DllImport("user32.dll")]
		static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
		const int SW_HIDE = 0;
		const int SW_SHOW = 5;
		
		
		[STAThread]
        static void Main()
        {
			Console.SetWindowSize(1, 1);
			var handle = GetConsoleWindow();
			ShowWindow(handle, SW_HIDE);
			
			
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new launcher());
        }
    }
}
