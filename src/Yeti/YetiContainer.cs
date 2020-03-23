using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yeti
{
    public class YetiContainer
    {
        readonly Dictionary<Type, Type> _registrations = new Dictionary<Type, Type>();

        public void Register<TRegistration, TImplementation>()
        {
            _registrations.Add(typeof(TRegistration), typeof(TImplementation));
        }

        public T Resolve<T>()
        {
            var requested_type = typeof(T);

            Type actual_type = _registrations[requested_type];

            var ctors = actual_type.GetConstructors();

            var ctor = ctors.First();

            IEnumerable<Type> dependency_types = ctor.GetParameters()
                .Select(x => x.ParameterType);



            var instance = Activator.CreateInstance(actual_type);

            return (T)instance;
        }

        object Resolve(Type type)
        {
            var requested_type = type;

            Type actual_type = _registrations[requested_type];

            var ctors = actual_type.GetConstructors();

            var ctor = ctors.First();

            IEnumerable<Type> dependency_types = ctor.GetParameters()
                .Select(x => x.ParameterType);

            var dependencies = dependency_types
                .Select(x => this.Resolve(x))
                .ToArray();


            var instance = Activator.CreateInstance(actual_type);

            return (T)instance;
        }
    }
}
