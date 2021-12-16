using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        //public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
        //{
        //    Type classType = Type.GetType(investigatedClass);
        //    FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static |
        //       BindingFlags.NonPublic | BindingFlags.Public);
        //    StringBuilder stringBuiilder = new StringBuilder();

        //    Object classInstance = Activator.CreateInstance(classType, new object[] { });
        //    stringBuiilder.AppendLine($"Class under investigation: {investigatedClass}");

        //    foreach (FieldInfo field in classFields.Where(f => requestedFields.Contains(f.Name)))
        //    {
        //        stringBuiilder.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");

        //    }

        //    return stringBuiilder.ToString().Trim();
        //}

        public string CollectGettersAndSetters(string investigatedClass)
        {
            Type classType = Type.GetType(investigatedClass);
            MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            StringBuilder stringBuiilder = new StringBuilder();

            foreach (MethodInfo method in classMethods.Where(m => m.Name.StartsWith("get")))
            {
                stringBuiilder.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            foreach (MethodInfo method in classMethods.Where(m => m.Name.StartsWith("set")))
            {
                stringBuiilder.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }
            return stringBuiilder.ToString().Trim();

        }

    }
}
