using dotnet_testable_code_proposal1.Service;

IEstimateService service = new EstimateService();

Console.WriteLine(service.Calc(2023, 10));
