using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Domain.Helpers
{
    public static class Extention
    {
        public static void UpdateForType<T>(Type type, T source, T destination)
        {
            FieldInfo[] myObjectFields = type.GetFields(
                BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            foreach (FieldInfo fi in myObjectFields)
            {
                fi.SetValue(destination, fi.GetValue(source));
            }
        }
    }
}
