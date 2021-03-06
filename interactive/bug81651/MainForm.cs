using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _mainMenu
		// 
		_mainMenu = new MainMenu ();

		// 
		// _fileMenu
		// 
		_fileMenuItem = new MenuItem ();
		_fileMenuItem.Text = "&File";
		_mainMenu.MenuItems.Add (_fileMenuItem);
		// 
		// openToolStripMenuItem
		// 
		_openMenuItem = new MenuItem ();
		_openMenuItem.Text = "&Open";
		_openMenuItem.Click += new EventHandler (OpenMenuItem_Click);
		_fileMenuItem.MenuItems.Add (_openMenuItem);
		// 
		// MainForm
		// 
		ClientSize = new Size (400, 300);
		IsMdiContainer = true;
		Location = new Point (200, 100);
		Menu = _mainMenu;
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81651";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.EnableVisualStyles ();
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void OpenMenuItem_Click (object sender, EventArgs e)
	{
		Form child = new Form ();
		child.ClientSize = new Size (150, 150);
		child.MdiParent = this;
		child.Text = "Child";
		child.Show ();
	}

	private MainMenu _mainMenu;
	private MenuItem _fileMenuItem;
	private MenuItem _openMenuItem;
}

public class InstructionsForm : Form
{
	public InstructionsForm ()
	{
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Fill;
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. In the File menu, select Open.{0}{0}" +
			"2. Hover over the close button of the child form.{0}{0}" +
			"3. Click the Close button while the tooltip is displayed.{0}{0}" +
			"4. Wait for a few seconds.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 3, the tooltip is no longer visible.{0}{0}" +
			"2. On step 4, the tooltip does not become visible again.",
			Environment.NewLine);
		// 
		// _tabPage1
		// 
		_tabPage1 = new TabPage ();
		_tabPage1.Text = "#1";
		_tabPage1.Controls.Add (_bugDescriptionText1);
		_tabControl.Controls.Add (_tabPage1);
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (350, 240);
		Location = new Point (650, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81651";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
