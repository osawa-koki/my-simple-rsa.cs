using System.Numerics;

namespace my_simple_rsa
{
  public static partial class Util
  {
    public static string Encrypt((BigInteger n, BigInteger e) publicKey, string message)
    {
      var _message = System.Web.HttpUtility.UrlEncode(message);
      var (n, e) = publicKey;
      var blockSize = (int)(BigInteger.Log10(n) / BigInteger.Log10(2)) - 1;
      var blocks = _message.ToCharArray().Aggregate(new List<string>(), (acc, _char) =>
      {
        var code = (int)_char;
        var padded = code.ToString().PadLeft(blockSize, '0');
        acc.Add(padded);
        return acc;
      });
      var encryptedBlocks = blocks.Select(block =>
      {
        var num = BigInteger.Parse(block);
        return ModExp(num, e, n).ToString().PadLeft(blockSize + 1, '0');
      });
      return string.Join("", encryptedBlocks);
    }
  }
}
