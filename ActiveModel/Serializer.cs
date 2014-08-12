using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Inflector;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ActiveModel
{
    public class Serializer
    {
        private object _item;
        public Options Options { get; set; }

        public Serializer(object item, Options options = null)
        {
            _item = item;
            Options = options ?? new Options();
        }

        public object SerializableObject {
            get { return GetModel(Options); }
        }

        public string AsJSON(Options options = null)
        {
            var opts = options ?? Options;
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = opts.KeyFormat.HasValue && opts.KeyFormat.Value == KeyFormatType.LowerCamel
                        ? new CamelCasePropertyNamesContractResolver()
                        : new DefaultContractResolver()
            };
            return JsonConvert.SerializeObject(GetModel(opts), Formatting.None, jsonSerializerSettings);
        }

        private object GetModel(Options options)
        {
            var expando = new ExpandoObject() as IDictionary<string, object>;
            if (_item == null || _item.IsSimpleType()) return _item;
            expando.Add(GetRoot(_item, options), _item);
            AddMeta(expando, options);
            return expando;
        }

        private static void AddMeta(IDictionary<string, object> expando, Options options)
        {
            if (!string.IsNullOrEmpty(options.MetaKey))
            {
                expando.Add(options.MetaKey, options.Meta);
            }
            else if (options.Meta != null)
            {
                expando.Add("Meta", options.Meta);
            }
        }

        private string GetRoot(object obj, Options options)
        {
            if (!string.IsNullOrEmpty(options.Root)) return options.Root;
            var objType = obj.GetType();
            var root = objType.Name;
            if (objType.IsGenericType && objType.GetGenericTypeDefinition() == typeof(List<>))
            {
                var genericType = objType.GetGenericArguments().Single();
                root = genericType.Name.Pluralize();
            }
            if (objType.BaseType == null || objType.BaseType != typeof(Array)) return root;
            var arrayType = objType.GetElementType();
            root = arrayType.Name.Pluralize();
            return root;
        }
    }
}