namespace my_simple_rsa
{
  public class EncryptDecryptTests
  {
    private static readonly int[] primes = {
      11, 13, 17, 19
    };
    private static readonly string[] messages = {
      "cat", "ネコ", "猫"
    };

    [Fact]
    public void TestEncryptDecrypt()
    {
      for (int i = 0; i < 100; i++)
      {
        int prime1 = primes[new Random().Next(primes.Length)];
        int prime2 = primes[new Random().Next(primes.Length)];
        string message = messages[new Random().Next(messages.Length)];

        if (prime1 == prime2)
        {
          continue;
        }

        // 公開鍵を生成する
        (int, int) publicKey = Util.GetPublicKey(prime1, prime2);

        // 秘密鍵を生成する
        (int, int) privateKey = Util.GetPrivateKey(prime1, prime2, publicKey);

        // データを暗号化する
        string encrypted = Util.Encrypt(publicKey, message);

        // 暗号化されたデータを復号する
        string decrypted = Util.Decrypt(privateKey, encrypted);

        Assert.Equal(message, decrypted);
      }
    }
  }
}
