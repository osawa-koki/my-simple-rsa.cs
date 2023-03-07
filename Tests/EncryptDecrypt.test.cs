namespace my_simple_rsa
{
  public class EncryptDecryptTests
  {
    private static readonly int[] primes = {
      11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83,
      89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167,
      173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251,
      257, 263, 269, 271, 277, 281, 283, 293, 307, 311, 313, 317, 331, 337, 347,
      349, 353, 359, 367, 373, 379, 383, 389, 397, 401, 409, 419, 421, 431, 433,
      439, 443, 449, 457, 461, 463, 467, 479, 487, 491, 499, 503, 509, 521, 523,
      541, 547, 557, 563, 569, 571, 577, 587, 593, 599, 601, 607, 613, 617, 619,
      631, 641, 643, 647, 653, 659, 661, 673, 677, 683, 691, 701, 709, 719, 727,
      733, 739, 743, 751, 757, 761, 769, 773, 787, 797, 809, 811, 821, 823, 827,
      829, 839, 853, 857, 859, 863, 877, 881, 883, 887, 907, 911, 919, 929, 937,
      941, 947, 953, 967, 971, 977, 983, 991, 997,
    };
    private static readonly string[] messages = {
      "dog",
      "cat",
      "bird",
      "fish",
      "rabbit",
      "hamster",
      "snake",
      "lizard",
      "frog",
      "turtle",
      "horse",
      "cow",
      "pig",
      "sheep",
      "goat",
      "chicken",
      "duck",
      "goose",
      "deer",
      "bear",
      "wolf",
      "fox",
      "squirrel",
      "mouse",
      "rat",
      "123",
      "%%%",
      "!!!",
      "###",
      "&&&",
      "***",
      "???",
      "...",
      "---",
      "___",
      "===",
      "^^^",
      "|||",
      "<<<",
      ">>>",
      "あいうえお",
      "かきくけこ",
      "さしすせそ",
      "たちつてと",
      "なにぬねの",
      "はひふへほ",
      "まみむめも",
      "やゆよ",
      "らりるれろ",
      "わをん",
      "アイウエオ",
      "カキクケコ",
      "サシスセソ",
      "タチツテト",
      "ナニヌネノ",
      "ハヒフヘホ",
      "マミムメモ",
      "ヤユヨ",
      "ラリルレロ",
      "ワヲン",
      "電子計算機",
      "電子計算機科学",
    };

    [Fact]
    public void TestEncryptDecrypt()
    {
      for (int i = 0; i < 500; i++)
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
