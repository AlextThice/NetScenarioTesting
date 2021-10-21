using NetScenarioTesting.Core;
using Xunit;

namespace Tests
{
    [ScenarioTestClass]
    public class TestWithInjection
    {
        private readonly Calculator _calculator;

        public TestWithInjection(Calculator calculator)
        {
            _calculator = calculator;
        }
        
        [ScenarioTestItem]
        public void Step1()
        {
            Assert.Equal(2, _calculator.Sum(1, 1));
        }
    }
}