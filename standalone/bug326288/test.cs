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
		h.Execute ("Default.aspx", sw);
		string result = sw.ToString ();
#if ONLY_1_1 && !MONO
		if (result.IndexOf ("<option value=\"1\">janvier</option>") == -1) {
#else
		if (result.IndexOf ("<option value=\"1\" title=\"tooltip of 1\">janvier</option>") == -1) {
#endif
			Console.WriteLine (result);
			return 1;
		}
#if ONLY_1_1 && !MONO
		if (result.IndexOf ("<option value=\"12\">d&#233;cembre</option>") == -1) {
#else
		if (result.IndexOf ("<option value=\"12\" title=\"tooltip of 12\">d&#233;cembre</option>") == -1) {
#endif
			Console.WriteLine (result);
			return 2;
		}
		return 0;
	}
}
