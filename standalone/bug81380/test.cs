using System;

class Program
{
	public static void Main ()
	{
		IFoo foo = null;
		if (foo is IFoo)
			Console.WriteLine ("got an IFoo");
		Bar bar = null;
		if (bar is Bar)
			Console.WriteLine ("got a bar");
	}
}

interface IFoo
{
}

class Bar
{
}
