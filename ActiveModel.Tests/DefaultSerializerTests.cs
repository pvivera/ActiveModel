using FluentAssertions;
using Xunit;

namespace ActiveModel.Tests
{
    public class DefaultSerializerTests
    {
        [Fact]
        public void serialize_objects()
        {
            Assert.Equal(null, new DefaultSerializer(null).SerializableObject);
            Assert.Equal(1, new DefaultSerializer(1).SerializableObject);
            Assert.Equal("hi", new DefaultSerializer("hi").SerializableObject);
        }
    }
}