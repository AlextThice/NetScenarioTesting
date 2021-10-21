using System;
using System.Threading.Tasks;
using NetScenarioTesting.Core;
using Xunit;

namespace Tests
{
    [ScenarioTestClass]
    public class FirstTestClass
    {
        [ScenarioTestItem]
        public void Step1()
        {
            DoStep1();
        }
        
        [ScenarioTestItem]
        public void Step2()
        {
            Assert.Throws<Exception>(DoStep2);
        }

        [ScenarioTestItem]
        public void Step3()
        {
            Assert.Equal(2, DoStep3());
        }
        
        [ScenarioTestItem]
        public async Task Step4Async()
        {
            var result = await DoStep4Async();
            Assert.Equal(2, result);
        }
        
        private void DoStep1()
        {
        }

        private void DoStep2()
        {
            throw new Exception();
        }
        
        private int DoStep3()
        {
            return 1;
        }

        private Task<int> DoStep4Async()
        {
            return Task.FromResult(1);
        }
    }
}