using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

class Program
{
	static int Main ()
	{
		Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
		Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

		HttpWebRequest request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/NotExistingService.asmx");
		request.Method = "GET";

		try {
			request.GetResponse ();
			return 1;
		} catch (WebException ex) {
			HttpWebResponse response = (HttpWebResponse) ex.Response;
			Assert.AreEqual (WebExceptionStatus.ProtocolError, ex.Status, "#A1");
			Assert.IsNotNull (response, "#A2");
			Assert.AreEqual (HttpStatusCode.NotFound, response.StatusCode, "#A3");
		}

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/NotExistingForm.aspx");
		request.Method = "GET";

		try {
			request.GetResponse ();
			return 2;
		} catch (WebException ex) {
			HttpWebResponse response = (HttpWebResponse) ex.Response;
			Assert.AreEqual (WebExceptionStatus.ProtocolError, ex.Status, "#B1");
			Assert.IsNotNull (response, "#B2");
			Assert.AreEqual (HttpStatusCode.NotFound, response.StatusCode, "#B3");
		}

		return 0;
	}
}
