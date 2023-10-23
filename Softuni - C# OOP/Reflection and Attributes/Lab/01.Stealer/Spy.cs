using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Stealer
{
    public class Spy
    {
        public Spy()
        {

        }
        public string StealFieldInfo(string className, string[] fields)
        {
            StringBuilder output = new StringBuilder();
            Type type = Type.GetType(className);
            object instance = Activator.CreateInstance(type);
            FieldInfo[] getFields = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            output.AppendLine($"Class under investigation: {type.Name}");
            for (int i = 0; i < fields.Length; i++)
            {
                for (int k = 0; k < getFields.Length; k++)
                {
                    if (fields[i] == getFields[k].Name)
                    {
                        output.AppendLine($"{getFields[k].Name} = {getFields[k].GetValue(instance)}");
                    }
                }
            }
            return output.ToString().TrimEnd();
        }
    }
}
