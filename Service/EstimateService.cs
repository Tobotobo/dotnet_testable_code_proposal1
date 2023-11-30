namespace dotnet_testable_code_proposal1.Service;

public class EstimateService : IEstimateService
{
  public static class _ {
    public static int Calc_2023(int x) {
      return x * 3;
    }

    public static int Calc_2024(int x) {
      return x * 4;
    }
  }

  public int Calc(int year, int x) {
    return year switch
    {
      2023 => _.Calc_2023(x),
      2024 => _.Calc_2024(x),
      _ => throw new NotImplementedException(),
    };
  }
}
