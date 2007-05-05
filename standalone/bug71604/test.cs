using System;

/// <summary>
/// <see cref="ITest.Start" />
/// <see cref="ITest.Foo" />
/// </summary>
public interface ITest
{
	/// <summary>whatever</summary>
	event EventHandler Start;

	/// <summary>hogehoge</summary>
	int Foo {
		get;
	}
}
