using ActiveModel.Tests.Fixtures;
using Xunit;

namespace ActiveModel.Tests
{
    public class RootAsOptionTests
    {
        private Profile _profile;
        private ProfileSerializer _serializer;

        public RootAsOptionTests()
        {
            _profile = new Profile {Name = "Name 1", Description = "Description 1", Comments = "Comments 1"};
            _serializer = new ProfileSerializer(_profile, new Options{Root = "initialize"});
        }

        [Fact]
        public void root_using_as_json()
        {
            Assert.Equal(@"{""initialize"":{""Name"":""Name 1"",""Description"":""Description 1"",""Comments"":""Comments 1""}}", _serializer.AsJSON());
        }

        [Fact]
        public void root_from_object_type()
        {
            var serializer = new ProfileSerializer(_profile);
            Assert.Equal(@"{""Profile"":{""Name"":""Name 1"",""Description"":""Description 1"",""Comments"":""Comments 1""}}", serializer.AsJSON());
        }

        [Fact]
        public void root_as_argument_takes_precedence()
        {
            var serializer = new ProfileSerializer(_profile);
            Assert.Equal(
                @"{""argument"":{""Name"":""Name 1"",""Description"":""Description 1"",""Comments"":""Comments 1""}}",
                serializer.AsJSON(new Options{Root = "argument"}));
        }
    }
}