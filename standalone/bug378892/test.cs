using System;
using System.Globalization;
using System.Threading;

class Program
{
	static int Main (string [] args)
	{
		for (int i = 0; i < 250; ++i) {
			Thread thread = new Thread (new ThreadStart (Test));
			if (i != 200)
				thread.CurrentCulture = new CultureInfo ("en-CA");
			thread.Start ();
		}

		return 1;
	}

	static void Test ()
	{
		string name = Thread.CurrentThread.CurrentCulture.Name;
		if (name != "en-CA")
			Environment.Exit (0);
	}
}
