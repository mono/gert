public class C : IB
{
  public void methodA() {}
  public void methodA2() {}
  public void methodB() {}
}


public class MainClass
{
  static void foo(IA ia) {}

  public static void Main()
  {
    C c = new C();
    foo(c);
  }
}
