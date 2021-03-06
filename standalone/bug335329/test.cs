using System;
using System.Data;
using System.Data.Odbc;
using System.Globalization;
using System.Text;
using System.Threading;

class Program
{
	[STAThread]
	static int Main ()
	{
		if (Environment.GetEnvironmentVariable ("MONO_TESTS_ODBC") == null)
			return 0;

		Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
		Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

		OdbcConnection conn = new OdbcConnection (CreateOdbcConnectionString ());
		conn.Open ();

		OdbcCommand cmd;
		OdbcDataReader dr;

		cmd = new OdbcCommand ("SELECT @@version", conn);
		dr = cmd.ExecuteReader ();
		if (!dr.Read ())
			return 1;
		if (dr.GetString (0).IndexOf ("Microsoft SQL Server") == -1)
			return 2;
		dr.Close ();

		conn.Dispose ();

		return 0;
	}

	static string CreateOdbcConnectionString ()
	{
#if NET_2_0
		OdbcConnectionStringBuilder csb = new OdbcConnectionStringBuilder ();
		csb.Driver = "SQL Server";
#else
		StringBuilder sb = new StringBuilder ();
		sb.Append ("Driver={SQL Server};");
#endif

		string serverName = Environment.GetEnvironmentVariable ("MONO_TESTS_SQL_HOST");
		if (serverName == null)
			throw CreateEnvironmentVariableNotSetException ("MONO_TESTS_SQL_HOST");
#if NET_2_0
		csb.Add ("Server", serverName);
#else
		sb.AppendFormat ("Server={0};", serverName);
#endif

		string userName = Environment.GetEnvironmentVariable ("MONO_TESTS_SQL_USER");
		if (userName != null)
#if NET_2_0
			csb.Add ("Uid", userName);
#else
			sb.AppendFormat ("Uid={0};", userName);
#endif

		string pwd = Environment.GetEnvironmentVariable ("MONO_TESTS_SQL_PWD");
		if (pwd != null)
#if NET_2_0
			csb.Add ("Pwd", pwd);
#else
			sb.AppendFormat ("Pwd={0};", pwd);
#endif

#if NET_2_0
		return csb.ToString ();
#else
		return sb.ToString ();
#endif
	}

	static ArgumentException CreateEnvironmentVariableNotSetException (string name)
	{
		return new ArgumentException ("The " + name + " environment variable is not set");
	}
}
