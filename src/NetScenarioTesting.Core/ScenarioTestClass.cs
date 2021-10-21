using System;
using Xunit;

namespace NetScenarioTesting.Core
{
    /// <summary>
    /// Attribute specifying that the specified class is a test.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ScenarioTestClass : Attribute
    {
    }
}