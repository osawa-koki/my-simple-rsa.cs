namespace my_simple_rsa
{
  public static partial class Test
  {
    [Theory]
    [InlineData(2, 3, 6)]
    [InlineData(10, 25, 50)]
    [InlineData(14, 21, 42)]
    [InlineData(15, 18, 90)]
    [InlineData(35, 49, 245)]
    [InlineData(100, 125, 500)]
    [InlineData(72, 96, 288)]
    [InlineData(168, 216, 1512)]
    [InlineData(111, 123, 4551)]
    [InlineData(222, 123, 9102)]
    [InlineData(0, 0, 0)]
    public static void Lcm_ReturnsExpectedValue(int a, int b, int expectedOutput)
    {
      var result = Util.Lcm(a, b);
      Assert.Equal(expectedOutput, result);
    }

    [Theory]
    [InlineData(-2, 3)]
    [InlineData(2, -3)]
    public static void Lcm_ThrowsArgumentException_ForNonIntegerInputs(double a, double b)
    {
      Assert.Throws<ArgumentException>(() => Util.Lcm((int)a, (int)b));
    }
  }
}
