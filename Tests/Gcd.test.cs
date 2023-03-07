namespace my_simple_rsa
{
  public static partial class Test
  {
    [Theory]
    [InlineData(2, 3, 1)]
    [InlineData(10, 25, 5)]
    [InlineData(14, 21, 7)]
    [InlineData(15, 18, 3)]
    [InlineData(35, 49, 7)]
    [InlineData(100, 125, 25)]
    [InlineData(72, 96, 24)]
    [InlineData(168, 216, 24)]
    [InlineData(111, 123, 3)]
    [InlineData(222, 123, 3)]
    [InlineData(0, 0, 0)]
    public static void TestGcd(int a, int b, int expectedOutput)
    {
      Assert.Equal(expectedOutput, Util.Gcd(a, b));
      Assert.Equal(expectedOutput, Util.Gcd(b, a));
    }

    [Theory]
    [InlineData(-2, 3)]
    [InlineData(2, -3)]
    public static void TestGcdWithBadInputs(double a, double b)
    {
      Assert.Throws<ArgumentException>(() => Util.Gcd((int)a, (int)b));
      Assert.Throws<ArgumentException>(() => Util.Gcd((int)b, (int)a));
    }
  }
}
