using ActiveModel.Tests.Fixtures;
using FluentAssertions;
using Xunit;

namespace ActiveModel.Tests
{
    public class MetaTests
    {
        private Profile _profile;

        public MetaTests()
        {
            _profile = new Profile
            {
                Name = "Name 1",
                Description = "Description 1",
                Comments = "Comments 1"
            };
        }

        [Fact]
        public void meta()
        {
            var serializer = new ProfileSerializer(_profile, new Options {Meta = new {total = 10}});
            Assert.Equal(@"{""Profile"":{""Name"":""Name 1"",""Description"":""Description 1"",""Comments"":""Comments 1""},""Meta"":{""total"":10}}", serializer.AsJSON());
        }

        [Fact]
        public void meta_using_meta_key()
        {
            var serializer = new ProfileSerializer(_profile, new Options{MetaKey = "my_meta", Meta = new { total = 10 }});
            Assert.Equal(@"{""Profile"":{""Name"":""Name 1"",""Description"":""Description 1"",""Comments"":""Comments 1""},""my_meta"":{""total"":10}}", serializer.AsJSON());
        }
    }
}