using System;

namespace NetScenarioTesting.Core
{
    /// <summary>
    /// Attribute specifying that the specified class is a test.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class ScenarioTestClass : Attribute
    {
        /// <summary>
        /// Name for scenario.
        /// </summary>
        public string Name { get; set; }
    }
}