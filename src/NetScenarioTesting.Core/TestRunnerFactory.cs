using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using NetScenarioTesting.Core.Factory;

namespace NetScenarioTesting.Core
{
    /// <summary>
    /// Factory for tests runner.
    /// </summary>
    public class TestRunnerFactory
    {
        private TestRunnerFactory() {}
        
        /// <summary>
        /// Create runner with all test in project.
        /// </summary>
        /// <returns>Test runner.</returns>
        public static ITestRunner Create()
        {
            var assemblies = new List<Assembly>();
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            foreach (var dll in Directory.GetFiles(path, "*.dll"))
                assemblies.Add(Assembly.LoadFile(dll));
            
            var testsRunnerData = assemblies.Select(GetAssemblyTestTypes).Where(data => data != null).ToArray();
            return Create(testsRunnerData);
        }

        /// <summary>
        /// Create runner for tests in assembly.
        /// </summary>
        /// <param name="assembly">Assembly with tests.</param>
        /// <returns>Test runner.</returns>
        public static ITestRunner Create(Assembly assembly)
        {
            var testRunnerData = GetAssemblyTestTypes(assembly);
            return new ScenarioTestRunner(new []{testRunnerData});
        }

        /// <summary>
        /// Create runner for test classes.
        /// </summary>
        /// <param name="testClasses">Collection test classes.</param>
        /// <returns>Test runner.</returns>
        public static ITestRunner Create(IEnumerable<Type> testClasses)
        {
            var testAssemblies = testClasses.GroupBy(type => type.Assembly);
            var testsRunnerData = testAssemblies.Select(pair => GetAssemblyTestTypes(pair.Key, pair.ToArray()))
                                                .Where(data => data != null)
                                                .ToArray();
            return Create(testsRunnerData);
        }

        private static ITestRunner Create(IEnumerable<TestsRunnerData> testsRunnerData)
        {
            return new ScenarioTestRunner(testsRunnerData);
        }
        
        private static TestsRunnerData GetAssemblyTestTypes(Assembly assembly)
        {
            return GetAssemblyTestTypes(assembly, null);
        }

        private static TestsRunnerData GetAssemblyTestTypes(Assembly assembly, IReadOnlyCollection<Type> filters)
        {
            try
            {
                var testTypes = assembly.DefinedTypes
                                        .Where(x => x.GetTypeInfo().GetCustomAttribute<ScenarioTestClass>() != null 
                                                    && !x.IsAbstract)
                                        .ToArray();
                if (filters != null)
                    testTypes = testTypes.Where(typeInfo => filters.Contains(typeInfo.AsType())).ToArray();
                
                if (testTypes.Length == 0)
                    return null;

                var configurationType = assembly.DefinedTypes.SingleOrDefault(type => !type.IsAbstract && type.IsSubclassOf(typeof(ScenarioTestsConfiguration))) 
                                        ?? typeof(SimpleScenarioTestsConfiguration);
                var testsConfiguration = (ScenarioTestsConfiguration)Activator.CreateInstance(configurationType);
                var testInstanceFactory = new TestInstanceFactory(testsConfiguration?.Build(assembly.GetName().Name));
                return new TestsRunnerData(testTypes, testInstanceFactory, assembly);
            }
            catch
            {
                return null;
            }
        }
    }
}