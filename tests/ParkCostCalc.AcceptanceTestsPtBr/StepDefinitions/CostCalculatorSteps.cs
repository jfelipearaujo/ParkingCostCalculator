using NUnit.Framework;

using ParkCostCalc.Core.Specs.Dsl;
using ParkCostCalc.Core.Specs.Models;

using ParkingCostCalculator.Specs.Helpers;

using TechTalk.SpecFlow;

namespace ParkCostCalc.AcceptanceTestsPtBr.StepDefinitions
{
    [Binding]
    public class CostCalculatorSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly CostCalculatorDsl _costCalcDsl;

        public CostCalculatorSteps(ScenarioContext scenarioContext, CostCalculatorDsl costCalculatorDsl)
        {
            _scenarioContext = scenarioContext;
            _costCalcDsl = costCalculatorDsl;
        }

        [Given(@"que o estacionamento é (.*)")]
        public void DadoQueOEstacionamentoEValet(ParkTypeEnum parkingLot)
        {
            _scenarioContext.Add("parkingLot", parkingLot);
        }

        [Given(@"a duração é de (.*)")]
        public void DadoADuracaoEDe(string duration)
        {
            _scenarioContext.Add("duration", duration);
        }

        [When(@"o custo for calculado")]
        public void QuandoOCustoForCalculado()
        {
            _scenarioContext.TryGetValue("duration", out string duration);
            _scenarioContext.TryGetValue("parkingLot", out ParkTypeEnum parkType);

            var cost = _costCalcDsl.CalculateCost(parkType, duration);

            _scenarioContext.Add("cost", cost);
        }

        [Then(@"o custo deve ser (.*)")]
        public void EntaoOCustoDeveSer(string expectedCost)
        {
            _scenarioContext.TryGetValue("cost", out decimal cost);

            Assert.AreEqual(Parser.ParseCost(expectedCost), cost);
        }
    }
}
