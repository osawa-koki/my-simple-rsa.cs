namespace my_simple_rsa
{
  public static partial class Util
  {
    public static (int, int) GetPublicKey(int p, int q)
    {
      int n = p * q;
      int phi = (p - 1) * (q - 1);
      int e = 65537;

      if (p == q)
      {
        throw new ArgumentException();
      }

      while (Gcd(e, phi) != 1)
      {
        e++;
      }

      return (n, e);
    }
  }
}
