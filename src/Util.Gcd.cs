namespace my_simple_rsa
{
  public static partial class Util
  {
    public static int Gcd(int a, int b)
    {
      if (a < 0 || b < 0)
      {
        throw new ArgumentException("引数は正の整数である必要があります。");
      }
      if (a == 0)
      {
        return b;
      }
      if (b == 0)
      {
        return a;
      }
      return Gcd(b, a % b);
    }
  }
}
