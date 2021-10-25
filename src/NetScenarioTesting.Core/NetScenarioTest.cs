using System;
using System.Collections.Generic;
using System.Reflection;

namespace NetScenarioTesting.Core
{
    /// <summary>
    /// Test description.
    /// </summary>
    public class NetScenarioTest
    {
        internal NetScenarioTest(NetScenarioAssemblyInfo assembly, IReadOnlyCollection<string> hierarchy, NetScenarioTestInfo test)
        {
            Assembly = assembly;
            Hierarchy = hierarchy;
            Test = test;
        }
        
        internal NetScenarioTest(Assembly assembly, Type test)
        {
            Assembly = new NetScenarioAssemblyInfo(assembly);
            var testPath = test.FullName?.Replace(Assembly.Name, "").Replace(test.Name, "");
            Hierarchy = testPath?.Split('.', StringSplitOptions.RemoveEmptyEntries) ?? Array.Empty<string>();
            Test = new NetScenarioTestInfo(test);
        }

        /// <summary>
        /// Test assembly info.
        /// </summary>
        public NetScenarioAssemblyInfo Assembly { get; }
        
        /// <summary>
        /// DirectoryHierarchy.
        /// </summary>
        public IReadOnlyCollection<string> Hierarchy { get; }
        
        /// <summary>
        /// Test info.
        /// </summary>
        public NetScenarioTestInfo Test { get; }
    }
}