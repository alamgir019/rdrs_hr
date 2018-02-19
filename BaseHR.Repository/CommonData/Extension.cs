using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BaseHR.Repository
{
    public static class Extension
    {
        public static void Mapper<T>(this T source, object destination)
        {
            PropertyInfo[] propertyInfos;
            propertyInfos = source.GetType().GetProperties();
            foreach (var prop in propertyInfos)
            {
                var value = source.GetType().GetProperty(prop.Name).GetValue(source);
                var destProp = destination.GetType().GetProperty(prop.Name);
                if (destProp!=null)
                {
                    destProp.SetValue(destination, value, null);
                }
            }
        }
    }
}
