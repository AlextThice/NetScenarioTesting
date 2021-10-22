using NetScenarioTesting.Core;
using Xunit;

namespace NetScenarioTesting.Examples
{
    [ScenarioTestClass(Name = "Testing injection Calculator")]
    public class TestWithInjection
    {
        private readonly Calculator _calculator;

        public TestWithInjection(Calculator calculator)
        {
            _calculator = calculator;
        }
        
        [ScenarioTestItem(Description = "Check correct sum two integer value in calculator.")]
        public void Step1()
        {
            Assert.Equal(2, _calculator.Sum(1, 1));
        }
    }
}