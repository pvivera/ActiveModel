using System;
using System.Linq;
using Inflector;
using System.Collections.Generic;
using System.Dynamic;

namespace ActiveModel
{
    public static class Modeler
    {
        public static object GetModel(object obj, bool addRoot = true)
        {
            var expando = new ExpandoObject() as IDictionary<string, object>;
            if(addRoot)
                expando.Add(GetRoot(obj), obj);
            else
                return obj;
            return expando;
        }

        private static string GetRoot(object obj)
        {
            var objType = obj.GetType();
            var root = objType.Name.ToLower();
            if (objType.IsGenericType && objType.GetGenericTypeDefinition() == typeof(List<>))
            {
                var genericType = objType.GetGenericArguments().Single();
                root = genericType.Name.ToLower().Pluralize();
            }
            if (objType.BaseType == null || objType.BaseType != typeof (Array)) return root;
            var arrayType = objType.GetElementType();
            root = arrayType.Name.ToLower().Pluralize();
            return root;
        }
    }
}
