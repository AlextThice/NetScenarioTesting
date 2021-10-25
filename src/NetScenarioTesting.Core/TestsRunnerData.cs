using System;
using System.Collections.Generic;
using System.Reflection;
using NetScenarioTesting.Core.Factory;

namespace NetScenarioTesting.Core
{
    internal class TestsRunnerData
    {
        public TestsRunnerData(IReadOnlyCollection<Type> testTypes, TestInstanceFactory factory, Assembly assembly)
        {
            TestTypes = testTypes;
            Factory = factory;
            Assembly = assembly;
        }

        public IReadOnlyCollection<Type> TestTypes { get; }
        
        public Assembly Assembly { get; }
        
        public TestInstanceFactory Factory { get; }
    }
}