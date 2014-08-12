namespace ActiveModel
{
    public class Options
    {
        public string Root { get; set; }
        public KeyFormatType? KeyFormat { get; set; }
        public string MetaKey { get; set; }
        public dynamic Meta { get; set; }
    }

    public enum KeyFormatType
    {
        Default,
        LowerCamel
    }
}