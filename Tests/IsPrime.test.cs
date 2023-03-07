namespace my_simple_rsa
{
  public partial class Test
  {
    [Theory]
    [InlineData(0, false)]
    [InlineData(1, false)]
    [InlineData(2, true)]
    [InlineData(3, true)]
    [InlineData(4, false)]
    [InlineData(5, true)]
    [InlineData(6, false)]
    [InlineData(7, true)]
    [InlineData(8, false)]
    [InlineData(9, false)]
    [InlineData(10, false)]
    [InlineData(11, true)]
    [InlineData(12, false)]
    [InlineData(13, true)]
    [InlineData(97, true)]
    [InlineData(100, false)]
    [InlineData(113, true)]
    [InlineData(123456789, false)]
    [InlineData(2147483647, true)]
    public static void IsPrime_ReturnsExpectedValue(int input, bool expectedOutput)
    {
      var result = Util.IsPrime(input);
      Assert.Equal(expectedOutput, result);
    }
  }
}