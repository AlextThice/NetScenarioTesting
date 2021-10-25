using System.Reflection;

namespace NetScenarioTesting.Core
{
    /// <summary>
    /// Assembly info.
    /// </summary>
    public class NetScenarioAssemblyInfo
    {
        internal NetScenarioAssemblyInfo(string name, Assembly assembly)
        {
            Name = name;
            Assembly = assembly;
        }
        
        internal NetScenarioAssemblyInfo(Assembly assembly)
        {
            Name = assembly.GetName().Name;
            Assembly = assembly;
        }

        /// <summary>
        /// Assembly name.
        /// </summary>
        public string Name { get;}
        
        /// <summary>
        /// Assembly with tests.
        /// </summary>
        internal Assembly Assembly { get; }
    }
}