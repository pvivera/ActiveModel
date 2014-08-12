using System.Collections;
using System.Collections.Generic;

namespace ActiveModel
{
    public class SerializerOptions : Dictionary<string, object>
    {
        public SerializerOptions() : base()
        {
        }
        
        public SerializerOptions(object parameters) : this()
        {
            if (parameters == null) return;
            
            if (parameters is IDictionary)
            {
                Merge(parameters as IDictionary, true);
            }
            else
            {
                foreach (var info in parameters.GetType().GetProperties())
                {
                    var value = info.GetValue(parameters, null);
                    Add(info.Name, value);
                }
            }
        }

        public SerializerOptions Merge(IDictionary dict, bool replace)
        {
            foreach (string key in dict.Keys)
            {
                if (ContainsKey(key))
                {
                    if (replace)
                    {
                        this[key] = dict[key];
                    }
                }
                else
                {
                    Add(key, dict[key]);
                }
            }
            return this;
        }

        public SerializerOptions Merge(object dict)
        {
            return Merge(dict, true);
        }

        public SerializerOptions Merge(object dict, bool replace)
        {
            var newDict = new SerializerOptions(dict);
            return Merge(newDict, replace);
        }
    }
}