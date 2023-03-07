namespace my_simple_rsa
{
  public static partial class Test
  {
    [Theory]
    [InlineData(3, 5, new int[] { 15, 65537 }, new int[] { 15, 1 })]
    [InlineData(61, 53, new int[] { 3233, 17 }, new int[] { 3233, 413 })]
    [InlineData(71, 61, new int[] { 4979, 19 }, new int[] { 4979, 199 })]
    public static void GetPrivateKey_ReturnsExpectedValue(int p, int q, int[] publicKey, int[] expectedPrivateKey)
    {
      var private_key = (expectedPrivateKey[0], expectedPrivateKey[1]);
      var public_key = (publicKey[0], publicKey[1]);
      Assert.Equal(private_key, Util.GetPrivateKey(p, q, public_key));
    }
  }
}
