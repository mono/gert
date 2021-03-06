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
		h.Execute ("Index1.aspx", sw);
		string result = sw.ToString ();
		if (result != "<html>Index1</html>") {
			Console.WriteLine (result);
			return 1;
		}

		sw.GetStringBuilder ().Length = 0;
		h.Execute ("Index2.aspx", sw);
		result = sw.ToString ();
		if (result != "<html>Index2</html>") {
			Console.WriteLine (result);
			return 2;
		}

		sw.GetStringBuilder ().Length = 0;
		h.Execute ("Index3.aspx", sw);
		result = sw.ToString ();
		if (result != "<html>Index3</html>") {
			Console.WriteLine (result);
			return 3;
		}

		sw.GetStringBuilder ().Length = 0;
		h.Execute ("Index4.aspx", sw);
		result = sw.ToString ();
		if (result != "<html>Index4</html>") {
			Console.WriteLine (result);
			return 4;
		}

		return 0;
	}
}
