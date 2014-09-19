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
        public void should_add_a_root_entity(Profile profile)
        {
            var result = (dynamic)Modeler.GetModel(profile);
            Assert.NotNull(result.profile);
        }

        [Theory]
        [AutoData]
        public void should_add_a_root_entity_in_plural_in_list(List<Profile> profiles)
        {
            var result = (dynamic)Modeler.GetModel(profiles);
            Assert.NotNull(result.profiles);
        }

        [Theory]
        [AutoData]
        public void should_add_a_root_entity_in_plural_in_ilist(IList<Profile> profiles)
        {
            var result = (dynamic)Modeler.GetModel(profiles);
            Assert.NotNull(result.profiles);
        }

        [Theory]
        [AutoData]
        public void should_add_a_root_entity_in_plural_in_array(Profile[] profiles)
        {
            var result = (dynamic)Modeler.GetModel(profiles);
            Assert.NotNull(result.profiles);
        }
    }
}
