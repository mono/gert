using System.Reflection;
using System.Windows.Forms;

[assembly: AssemblyInformationalVersion ("1.2.3.4")]
[assembly: AssemblyVersion ("5.6.7.8")]

class Program
{
	static int Main ()
	{
		if (Application.ProductVersion != "1.2.3.4")
			return 1;
		return 0;
	}
}
