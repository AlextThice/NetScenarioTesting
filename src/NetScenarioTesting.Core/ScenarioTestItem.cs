using System;

namespace NetScenarioTesting.Core
{
    /// <summary>
    /// Attribute specifying that the marked method is a test item.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class ScenarioTestItem : Attribute
    {
        /// <summary>
        /// Scenario test item description.
        /// </summary>
        public string Description { get; set; }
    }
}