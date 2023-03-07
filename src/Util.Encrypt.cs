using System.Text;

namespace my_simple_rsa
{
  public static partial class Util
  {
    public static string Encrypt((int n, int e) publicKey, string message)
    {
      var (n, e) = publicKey;
      var blockSize = (int)Math.Floor(Math.Log10(n) / Math.Log10(2)) / 4 * 4;
      var bytes = Encoding.UTF8.GetBytes(message);
      var blocks = Enumerable.Range(0, bytes.Length / blockSize + 1)
          .Select(i => bytes.Skip(i * blockSize).Take(Math.Min(blockSize, bytes.Length - i * blockSize)))
          .Where(s => s.Any())
          .Select(block => BitConverter.ToInt32(block.Concat(new byte[4 - (block.Count() % 4)]).ToArray(), 0))
          .Select(num => num.ToString().PadLeft(blockSize / 4, '0'))
          .ToList();
      var encryptedBlocks = blocks.Select(block =>
      {
        var num = int.Parse(block);
        return ModExp(num, e, n).ToString().PadLeft(blockSize / 4 + 1, '0');
      }).ToList();
      return string.Join("", encryptedBlocks);
    }
  }
}
