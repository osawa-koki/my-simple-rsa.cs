using CommandLine;
using my_simple_rsa;

var result = Parser.Default.ParseArguments<Options>(args)
  .WithParsed(options =>
  {
    int prime1 = (int)options.Prime1!;
    int prime2 = (int)options.Prime2!;
    string message = options.Message!;

    if (!Util.IsPrime(prime1))
    {
      throw new ArgumentException("prime1 is not a prime number.");
    }

    if (!Util.IsPrime(prime2))
    {
      throw new ArgumentException("prime2 is not a prime number.");
    }

    if (prime1 == prime2)
    {
      throw new ArgumentException("prime1 and prime2 must be different.");
    }

    (int a, int b) = Util.GetPublicKey(prime1, prime2);

    Console.WriteLine($"公開鍵: ({a}, {b})");

    (int c, int d) = Util.GetPrivateKey(prime1, prime2, (a, b));

    Console.WriteLine($"秘密鍵: ({c}, {d})");

    Console.WriteLine($"元のメッセージ: {message} ({message.Length})");

    var encrypted = Util.Encrypt((a, b), message);
    Console.WriteLine($"暗号化されたメッセージ: {encrypted} ({encrypted.Length})");

    var decrypted = Util.Decrypt((c, d), encrypted);
    Console.WriteLine($"復号化されたメッセージ: {decrypted} ({decrypted.Length})");
  })
  .WithNotParsed(errors =>
  {
    var errorMessage = errors
        .Select(error => error.Tag.ToString())
        .Aggregate((acc, error) => acc + ", " + error);
    Console.Error.WriteLine($"Error: {errorMessage}");
  });

public class Options
{
  [Option('p', "prime1", Required = true, HelpText = "The first prime number.")]
  public int? Prime1 { get; set; }

  [Option('q', "prime2", Required = true, HelpText = "The second prime number.")]
  public int? Prime2 { get; set; }

  [Option('m', "message", Required = true, HelpText = "The message to encrypt.")]
  public string? Message { get; set; }
}
