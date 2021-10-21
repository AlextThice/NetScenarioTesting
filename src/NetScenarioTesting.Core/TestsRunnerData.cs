using System;
using System.Collections.Generic;
using NetScenarioTesting.Core.Factory;

namespace NetScenarioTesting.Core
{
    internal class TestsRunnerData
    {
        public TestsRunnerData(IReadOnlyCollection<Type> testTypes, TestInstanceFactory factory)
        {
            TestTypes = testTypes;
            Factory = factory;
        }

        public IReadOnlyCollection<Type> TestTypes { get; }
        
        public TestInstanceFactory Factory { get; }
    }
}