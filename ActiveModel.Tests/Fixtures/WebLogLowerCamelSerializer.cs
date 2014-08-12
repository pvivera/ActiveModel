namespace ActiveModel.Tests.Fixtures
{
    public class WebLogLowerCamelSerializer : Serializer
    {
        public WebLogLowerCamelSerializer(object item, Options options = null) : base(item, options)
        {
            Options.KeyFormat = KeyFormatType.LowerCamel;
        }
    }
}