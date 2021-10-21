using System;

namespace NetScenarioTesting.Core
{
    /// <summary>
    /// Attribute specifying that the marked method is a test item.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class ScenarioTestItem : Attribute
    {
        
    }
}