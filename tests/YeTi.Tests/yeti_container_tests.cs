using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Yeti;

namespace YeTi.Tests
{
    public class yeti_container_tests
    {
        [Fact]
        public void resolves_registered_components()
        {
            var container = new YetiContainer();
            container.Register<ITestInterface, TestImplementation>();

            var resolved_object = container.Resolve<ITestInterface>();

            resolved_object.ShouldBeOfType<TestImplementation>();
        }

        [Fact]
        public void resolves_components_with_ctor_with_dependencies()
        {
            var container = new YetiContainer();
            container.Register<Dependecy, Dependecy>();
            container.Register<ITestInterface, TestImplementationWithDepenedncy>();

            var resolved_object = container.Resolve<ITestInterface>();

            resolved_object.ShouldBeOfType<TestImplementationWithDepenedncy>();
        }

        public interface ITestInterface
        {
        }

        public class TestImplementation : ITestInterface
        {
        }

        public class Dependecy
        {
        }


        public class TestImplementationWithDepenedncy : ITestInterface
        {
            public TestImplementationWithDepenedncy(Dependecy dependecy)
            {

            }

        }
    }
}
