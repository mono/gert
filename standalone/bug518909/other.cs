using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo ("snafu2, PublicKey=00240000048000009400000006020000002400005253413100040000010001001B9C35E2DCD4BFF869A53724361E53598E40CC132F83D328AD2395C11036C920B9192640D41C4748E9668AD4AC5DD59D0EDF42F743A0FA55CECAC535270337A7D4CE644A99F5E377761A1A0D2A86C47CF58FC1896FC18725BB2F173AD34244EF22D4D8DE4A29D1E475A0407B7DB47DDA5DD44ED6F9220B9F19466F3E395FC5BA")]

namespace other
{
	public class MainClass
	{
		internal virtual string Main()
		{
			return "internal";
		}
		public virtual string Main2()
		{
			return "public";
		}
	}
}
