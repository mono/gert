using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;

public class GlobalBase : System.Web.HttpApplication
{
	public void Application_Start (object sender, EventArgs e)
	{
		Counters.AppStart |= 4;
	}

	protected virtual void Application_BeginRequest (object sender, EventArgs e)
	{
		Counters.AppBeginRequest |= 4;
	}

	public void Session_Start ()
	{
		Counters.SessionStart |= 4;
	}
}

public class Global : GlobalBase
{
}
