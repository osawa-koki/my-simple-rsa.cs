namespace my_simple_rsa
{
  public static partial class Util
  {
    public static (int a, int b) GetPrivateKey(int p, int q, (int a, int b) privateKey)
    {
      var (n, e) = privateKey;
      var phi = Lcm(p - 1, q - 1);
      var d = ModInv(e, phi);

      if (p == q)
      {
        throw new ArgumentException();
      }

      // dが正の数になるようにする
      while (d < 0)
      {
        d += phi;
      }

      return (n, d);
    }

    public static int ModInv(int a, int m)
    {
      var (gcdVal, x, _) = ExtEuclidean(a, m);
      if (gcdVal != 1)
      {
        throw new Exception($"a = {a}(mod {m})における逆元が存在しません。");
      }
      return ((x % m) + m) % m;
    }

    public static Tuple<int, int, int> ExtEuclidean(int a, int b)
    {
      int x = 0, y = 1, u = 1, v = 0;
      while (a != 0)
      {
        var q = b / a;
        var r = b % a;
        var m = x - u * q;
        var n = y - v * q;
        b = a;
        a = r;
        x = u;
        y = v;
        u = m;
        v = n;
      }

      return Tuple.Create(b, x, y);
    }
  }
}
