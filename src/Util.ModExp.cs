using System.Numerics;

namespace my_simple_rsa
{
  public static partial class Util
  {
    public static BigInteger ModExp(BigInteger x, BigInteger y, BigInteger m)
    {
      if (y == 0)
      {
        return 1;
      }
      else if (y % 2 == 0)
      {
        var z = ModExp(x, y / 2, m);
        return (z * z) % m;
      }
      else
      {
        return (x * ModExp(x, y - 1, m)) % m;
      }
    }
  }
}
