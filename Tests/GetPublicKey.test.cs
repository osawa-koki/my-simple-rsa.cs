namespace my_simple_rsa
{
  public static partial class Test
  {
    [Theory]
    [InlineData(3, 5, new[] { 15, 65537 })]
    [InlineData(11, 17, new[] { 187, 65537 })]
    [InlineData(101, 103, new[] { 10403, 65537 })]
    [InlineData(631, 641, new[] { 404471, 65537 })]
    [InlineData(10007, 10009, new[] { 100160063, 65537 })]
    public static void GetPublicKey_ReturnsExpectedValue(int p, int q, int[] expectedOutput)
    {
      var expected = (expectedOutput[0], expectedOutput[1]);
      Assert.Equal(expected, Util.GetPublicKey(p, q));
    }
  }
}
