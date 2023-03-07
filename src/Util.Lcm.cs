namespace my_simple_rsa
{

  public static partial class Util
  {
    public static int Lcm(int a, int b)
    {
      if (a == 0 || b == 0)
      {
        return 0;
      }
      if (a < 0 || b < 0)
      {
        throw new ArgumentException("引数は正の整数である必要があります。");
      }
      return a * b / Gcd(a, b);
    }
  }

}
