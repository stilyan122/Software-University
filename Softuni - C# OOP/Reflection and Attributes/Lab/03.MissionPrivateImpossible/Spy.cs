using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

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
        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder output = new StringBuilder();
            Type type = Type.GetType(className);
            FieldInfo[] getFields = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            MethodInfo[] publicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] nonPublicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var field in getFields)
            {
                output.AppendLine($"{field.Name} must be private");
            }
            foreach (var method in nonPublicMethods.Where(c=>c.Name.StartsWith("get")))
            {
                output.AppendLine($"{method.Name} have to be public");
            }
            foreach (var method in publicMethods.Where(c => c.Name.StartsWith("set")))
            {
                output.AppendLine($"{method.Name} have to be private");
            }
            return output.ToString().TrimEnd();
        }
        public string RevealPrivateMethods(string className)
        {
            Type type = Type.GetType(className);
            StringBuilder output = new StringBuilder();
            output.AppendLine($"All Private Methods of Class: {className}");
            output.AppendLine($"Base Class: {type.BaseType.Name}");
            MethodInfo[] methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var method in methods)
            {
                output.AppendLine(method.Name);
            }
            return output.ToString().TrimEnd();
        }
    }
}
