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

            var instance = Activator.CreateInstance(actual_type);

            return (T)instance;
        }
    }
}
