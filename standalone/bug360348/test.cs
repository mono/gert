using System;
using System.Diagnostics;
using System.IO;

class Program
{
	static int Main (string [] args)
	{
		string basedir = AppDomain.CurrentDomain.BaseDirectory;

		if (args.Length == 0) {
			Process p = new Process ();
			p.StartInfo.FileName = Path.Combine (basedir, "test.exe");
			p.StartInfo.Arguments = "fork";
			p.Start ();
			p.WaitForExit ();
			Assert.AreEqual (0, p.ExitCode, "exit code");
		} else if (args.Length == 1) {
			if (args [0] != "fork") {
				Process p = new Process ();
				p.StartInfo.FileName = args [0];
				p.StartInfo.Arguments = Path.Combine (basedir, "test.exe") + " fork";
				p.Start ();
				p.WaitForExit ();
				Assert.AreEqual (0, p.ExitCode, "exit code");
			} else {
				Process p = Process.GetCurrentProcess ();
				if (p.ProcessName == null)
					return 1;
				return 0;
			}
		} else {
			return 2;
		}

		return 0;
	}
}
