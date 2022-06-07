using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string investigateClass, params string[] fields)
        {
            Type type = Type.GetType(investigateClass);
            FieldInfo[] classFields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic
                | BindingFlags.Static | BindingFlags.Instance);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Class under investigation: {investigateClass}");
            Object classInstance = Activator.CreateInstance(type, new object[] { });

            foreach (FieldInfo field in classFields.Where(x => fields.Contains(x.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().TrimEnd();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            Type type = Type.GetType(className);
            FieldInfo[] classFields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
            MethodInfo[] classPublicMethods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            MethodInfo[] classNonPublicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            
            StringBuilder sb =  new StringBuilder();

            foreach (FieldInfo field in classFields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            foreach (MethodInfo method in classNonPublicMethods.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }

            foreach (MethodInfo method in classPublicMethods.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }

            return sb.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string className)
        {
            Type type = Type.GetType(className);
            MethodInfo[] classMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {type.BaseType.Name}");

            foreach (MethodInfo method in classMethods)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().TrimEnd();
        }

        public string CollectGettersAndSetters(string className)
        {
            Type type = Type.GetType(className);
            MethodInfo[] classMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            StringBuilder sb = new StringBuilder();

            foreach (MethodInfo method in classMethods.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            foreach (MethodInfo method in classMethods.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
