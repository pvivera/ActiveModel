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
            _profile = new Profile {FirstName = "FirstName 1", LastName = "LastName 1", Description = "Description 1", Comments = "Comments 1"};
        }

        [Fact]
        public void root_using_as_json()
        {
            var serializer = new ProfileSerializer(_profile, new Options { Root = "initialize" });
            Assert.Equal(
                @"{""initialize"":{""firstName"":""FirstName 1"",""lastName"":""LastName 1"",""description"":""Description 1"",""comments"":""Comments 1""}}",
                serializer.AsJSON());
        }

        [Fact]
        public void root_from_object_type()
        {
            var serializer = new ProfileSerializer(_profile);
            Assert.Equal(@"{""profile"":{""firstName"":""FirstName 1"",""lastName"":""LastName 1"",""description"":""Description 1"",""comments"":""Comments 1""}}", serializer.AsJSON());
        }

        [Fact]
        public void root_as_argument_takes_precedence()
        {
            var serializer = new ProfileSerializer(_profile);
            Assert.Equal(
                @"{""argument"":{""firstName"":""FirstName 1"",""lastName"":""LastName 1"",""description"":""Description 1"",""comments"":""Comments 1""}}",
                serializer.AsJSON(new Options{Root = "argument"}));
        }
    }
}