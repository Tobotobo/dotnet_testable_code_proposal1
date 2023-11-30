using dotnet_testable_code_proposal1.Service;
using Microsoft.VisualBasic;

namespace dotnet_testable_code_proposal1.ServiceTest;

public class EstimateServiceTest
{
  [Theory]
  [InlineData(2023, 1, 3)]
  [InlineData(2024, 1, 4)]
  public void Calc_Test_OK(int year, int x, int expected)
  {
    var service = new EstimateService();
    var result = service.Calc(year, x);
    Assert.Equal(expected, result);
  }

  [Theory]
  [InlineData(2022, typeof(NotImplementedException))]
  [InlineData(2025, typeof(NotImplementedException))]
  public void Calc_Test_NG(int year, Type expected)
  {
    var service = new EstimateService();
    Assert.Throws(expected, () => service.Calc(year, 1));
  }

  [Theory]
  [InlineData(0, 0)]
  [InlineData(1, 3)]
  [InlineData(9, 27)]
  [InlineData(10, 30)]
  [InlineData(100, 300)]
  [InlineData(-1, -3)]
  [InlineData(-9, -27)]
  [InlineData(-10, -30)]
  [InlineData(-100, -300)]
  public void Calc_2023_Test(int x, int expected)
  {
    var result = EstimateService._.Calc_2023(x);
    Assert.Equal(expected, result);
  }

  [Theory]
  [InlineData(0, 0)]
  [InlineData(1, 4)]
  [InlineData(9, 36)]
  [InlineData(10, 40)]
  [InlineData(100, 400)]
  [InlineData(-1, -4)]
  [InlineData(-9, -36)]
  [InlineData(-10, -40)]
  [InlineData(-100, -400)]
  public void Calc_2024_Test(int x, int expected)
  {
    var result = EstimateService._.Calc_2024(x);
    Assert.Equal(expected, result);
  }
}
