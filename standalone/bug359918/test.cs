using System;

class Program
{
	static void Main ()
	{
		int [] counters = new int [11];
		Random rnd = new Random ();

		for (int i = 0; i < 100000; i++) {
			int idx = rnd.Next (-5, 5) + 5;
			counters [idx]++;
		}

		for (int i = 0; i < 10; i++)
			Assert.IsTrue (counters [i] > 0, "#" + (i - 5).ToString () + ":" + counters [i]);
		Assert.AreEqual (0, counters [10], "#5:" + counters [10]);
	}
}
