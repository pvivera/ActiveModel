using System;
using System.Collections.Generic;

namespace ActiveModel
{
    public static class ObjectExtensions
    {
        public static bool IsSimpleType(this object obj)
        {
            var type = obj.GetType();
            return
                type.IsValueType ||
                type.IsPrimitive ||
                new List<Type>
                {
                    typeof (String),
                    typeof (Decimal),
                    typeof (DateTime),
                    typeof (DateTimeOffset),
                    typeof (TimeSpan),
                    typeof (Guid)
                }.Contains(type) ||
                Convert.GetTypeCode(type) != TypeCode.Object;
        }
    }
}