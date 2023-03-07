namespace my_simple_rsa
{
  public class ModExpTest
  {
    [Theory]
    [InlineData(new int[] { 2, 5, 13 }, 6)]
    [InlineData(new int[] { 3, 7, 13 }, 3)]
    [InlineData(new int[] { 5, 11, 13 }, 8)]
    [InlineData(new int[] { 7, 13, 13 }, 7)]
    [InlineData(new int[] { 11, 17, 13 }, 7)]
    [InlineData(new int[] { 13, 19, 13 }, 0)]
    [InlineData(new int[] { 17, 23, 13 }, 10)]
    [InlineData(new int[] { 19, 29, 13 }, 2)]
    [InlineData(new int[] { 23, 31, 13 }, 10)]
    [InlineData(new int[] { 29, 37, 13 }, 3)]
    public void TestModExp(int[] inputs, int expectedOutput)
    {
      var (a, b, m) = (inputs[0], inputs[1], inputs[2]);
      Assert.Equal(expectedOutput, Util.ModExp(a, b, m));
    }
  }
}
