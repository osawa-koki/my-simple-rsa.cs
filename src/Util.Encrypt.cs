namespace my_simple_rsa
{
  public static partial class Util
  {
    public static string Encrypt((int, int) publicKey, string message)
    {
      (int n, int e) = publicKey;
      var _message = Uri.EscapeDataString(message);
      var blockSize = (int)Math.Floor(Math.Log10(n) / Math.Log10(2)) - 1;
      var blocks = Enumerable.Range(0, (_message.Length + blockSize - 1) / blockSize)
          .Select(i => _message.Substring(i * blockSize, Math.Min(blockSize, _message.Length - i * blockSize)))
          .Where(s => !string.IsNullOrEmpty(s))
          .Select(s => s.Aggregate(0, (acc, c) => acc * 256 + c))
          .Select(num => num.ToString().PadLeft(blockSize, '0'))
          .ToList();

      var encryptedBlocks = blocks.Select(block =>
      {
        var num = int.Parse(block);
        return ModExp(num, e, n).ToString().PadLeft(blockSize + 1, '0');
      }).ToList();
      return string.Join("", encryptedBlocks);
    }
  }
}
