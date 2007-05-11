using System;
using System.IO;
using System.Web;
using System.Web.Hosting;

class TinyHost : MarshalByRefObject
{
	static TinyHost CreateHost ()
	{
		string path = Path.Combine (AppDomain.CurrentDomain.BaseDirectory, "web");
		string bin = Path.Combine (path, "bin");
		string asm = Path.GetFileName (typeof (TinyHost).Assembly.Location);

		Directory.CreateDirectory (bin);
		File.Copy (asm, Path.Combine (bin, asm), true);

		return (TinyHost) ApplicationHost.CreateApplicationHost (
			typeof (TinyHost), "/", path);
	}

	public void Execute (string page, TextWriter tw)
	{
		SimpleWorkerRequest req = new SimpleWorkerRequest (
			page, "", tw);
		HttpRuntime.ProcessRequest (req);
	}

	static int Main ()
	{
		TinyHost h = CreateHost ();
		StringWriter sw = new StringWriter ();
		h.Execute ("Create.aspx", sw);
		string result = sw.ToString ();
		if (result.IndexOf ("Een titel") == -1) {
			Console.WriteLine (result);
			return 1;
		}
		if (result.IndexOf ("Hoofding") == -1) {
			Console.WriteLine (result);
			return 2;
		}

		sw.GetStringBuilder ().Length = 0;
		h.Execute ("Default.aspx", sw);
		result = sw.ToString ();
		if (result.IndexOf ("Noot") == -1) {
			Console.WriteLine (result);
			return 3;
		}
		if (result.IndexOf ("Inhoudstafel") == -1) {
			Console.WriteLine (result);
			return 4;
		}

		sw.GetStringBuilder ().Length = 0;
		h.Execute ("Sub" + Path.DirectorySeparatorChar + "Default.aspx", sw);
		result = sw.ToString ();
		if (result.IndexOf ("Noot") == -1) {
			Console.WriteLine (result);
			return 5;
		}
		if (result.IndexOf ("Inhoudsopgave") == -1) {
			Console.WriteLine (result);
			return 6;
		}

		return 0;
	}
}