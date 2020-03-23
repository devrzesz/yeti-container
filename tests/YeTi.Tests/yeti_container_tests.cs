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
            // Arange
            var container = new YetiContainer();
            container.Register<ITestInterface, TestImplementation>();

            //Act
            var resolved_object = container.Resolve<ITestInterface>();

            // Assert 
            resolved_object.ShouldBeOfType<TestImplementation>();

        } 

        public interface ITestInterface
        {

        }

        public class TestImplementation : ITestInterface
        {

        }
    }
}
