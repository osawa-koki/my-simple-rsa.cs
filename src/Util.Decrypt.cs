using System.Text;

namespace my_simple_rsa
{
  public static partial class Util
  {
    public static string Decrypt((int, int) privateKey, string encrypted)
    {
      var (n, d) = privateKey;
      var blockSize = (int)Math.Floor(Math.Log10(n) / Math.Log10(2)) - 1;
      var encryptedBlocks = Enumerable.Range(0, encrypted.Length / (blockSize + 1))
          .Select(i => encrypted.Substring(i * (blockSize + 1), Math.Min(blockSize + 1, encrypted.Length - i * (blockSize + 1))));
      var decryptedChars = encryptedBlocks.Select(block =>
      {
        var encryptedBlockNum = int.Parse(block);
        var decryptedBlockNum = ModExp(encryptedBlockNum, d, n);
        return (byte)decryptedBlockNum;
      });
      var decryptedBytes = decryptedChars.ToArray();
      var decodedString = Encoding.UTF8.GetString(decryptedBytes);
      return decodedString;
    }
  }
}
