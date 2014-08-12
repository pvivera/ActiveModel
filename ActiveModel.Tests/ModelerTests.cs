using System.Collections.Generic;
using ActiveModel.Tests.Fixtures;
using FluentAssertions;
using Newtonsoft.Json;
using Ploeh.AutoFixture.Xunit;
using Xunit;
using Xunit.Extensions;

namespace ActiveModel.Tests
{
    public class ModelerTests
    {
        [Theory]
        [AutoData]
        public void should_return_a_model(Profile employee)
        {
            Modeler.GetModel(employee).Should().NotBeNull();
        }

        [Theory]
        [AutoData]
        public void should_not_add_a_root_entity(Profile employee)
        {
            var result = (dynamic)Modeler.GetModel(employee, false);
            Assert.Equal(result, employee);
        }

        [Theory]
        [AutoData]
        public void should_add_a_root_entity(Profile employee)
        {
            var result = (dynamic)Modeler.GetModel(employee);
            Assert.NotNull(result.employee);
        }

        [Theory]
        [AutoData]
        public void should_add_a_root_entity_in_plural_in_list(List<Profile> employees)
        {
            var result = (dynamic)Modeler.GetModel(employees);
            Assert.NotNull(result.employees);
        }

        [Theory]
        [AutoData]
        public void should_add_a_root_entity_in_plural_in_ilist(IList<Profile> employees)
        {
            var result = (dynamic)Modeler.GetModel(employees);
            Assert.NotNull(result.employees);
        }

        [Theory]
        [AutoData]
        public void should_add_a_root_entity_in_plural_in_array(Profile[] employees)
        {
            var result = (dynamic)Modeler.GetModel(employees);
            Assert.NotNull(result.employees);
        }
    }
}
