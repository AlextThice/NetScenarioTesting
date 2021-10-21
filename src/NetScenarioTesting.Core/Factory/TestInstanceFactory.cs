using System;
using System.Linq;
using System.Reflection;

namespace NetScenarioTesting.Core.Factory
{
    /// <summary>
    /// Factory create test instance object.
    /// </summary>
    internal class TestInstanceFactory
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="serviceProvider">Services provider.</param>
        public TestInstanceFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public object Create(Type testType)
        {
            var constructorInfo = GetConstructor(testType);
            var constructorParameters = constructorInfo.GetParameters();
            if (constructorParameters.Length == 0)
                return Activator.CreateInstance(testType);
            
            var dependencies = constructorParameters.Select(parameter => Resolve(parameter, testType)).ToArray();
            return constructorInfo.Invoke(dependencies);
        }
        
        private static ConstructorInfo GetConstructor(Type type)
        {
            if (type.IsAbstract)
                throw new ArgumentException($"Cannot create a factory for an abstract type {type.Name}.");
            var constructors = type.GetConstructors();
            if (constructors.Length == 0)
                throw new ArgumentException($"The type {type.Name} has no public constructors.");
            if (constructors.Length > 1)
                throw new NotSupportedException($"Type {type.Name} has more than one constructor.");

            return constructors[0];
        }
        
        private object Resolve(ParameterInfo parameter, Type testType)
        {
            try
            {
                return _serviceProvider.GetService(parameter.ParameterType);
            }
            catch
            {
                throw new InvalidOperationException($"Could not resolve dependency {parameter.ParameterType.Name} for type {testType.Name}");
            }
        }
    }
}