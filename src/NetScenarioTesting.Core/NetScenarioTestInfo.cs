using System;
using System.Reflection;

namespace NetScenarioTesting.Core
{
    /// <summary>
    /// Test info.
    /// </summary>
    public class NetScenarioTestInfo
    {
        internal NetScenarioTestInfo(string name, Type test)
        {
            Name = name;
            Test = test;
        }
        
        internal NetScenarioTestInfo(Type test)
        {
            var classAttribute = test.GetCustomAttribute<ScenarioTestClass>();
            Name = classAttribute?.Name ?? test.Name;
            Test = test;
        }

        /// <summary>
        /// Test name.
        /// </summary>
        public string Name { get; }
        
        /// <summary>
        /// Test class type.
        /// </summary>
        internal Type Test { get; }
    }
}