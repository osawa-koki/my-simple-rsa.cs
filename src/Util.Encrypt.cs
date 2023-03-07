using System;
using System.Linq;
using System.Numerics;
using System.Text;

namespace my_simple_rsa
{
  public static partial class Util
  {
    public static string Encrypt((BigInteger n, BigInteger e) publicKey, string message)
    {
      var _message = Uri.EscapeDataString(message);
      var (n, e) = publicKey;
      var blockSize = (int)Math.Floor(BigInteger.Log10(n) / Math.Log10(2)) - 1;
      var bytes = Encoding.UTF8.GetBytes(_message);
      var blocks = Enumerable.Range(0, bytes.Length / blockSize + 1)
          .Select(i => bytes.Skip(i * blockSize).Take(Math.Min(blockSize, bytes.Length - i * blockSize)))
          .Where(s => s.Any())
          .Select(block => {
            var padded = new byte[blockSize];
            block.ToArray().CopyTo(new Span<byte>(padded));
            return new BigInteger(padded);
          })
          .Select(num => num.ToString().PadLeft(blockSize, '0'))
          .ToList();

      var encryptedBlocks = blocks.Select(block =>
      {
        var num = BigInteger.Parse(block);
        return BigInteger.ModPow(num, e, n).ToString().PadLeft(blockSize + 1, '0');
      }).ToList();
      return string.Join("", encryptedBlocks);
    }
  }
}
