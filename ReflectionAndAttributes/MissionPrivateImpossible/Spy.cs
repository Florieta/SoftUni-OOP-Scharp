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

        public string AnalyzeAccessModifiers(string investigatedClass)
        {
            Type classType = Type.GetType(investigatedClass);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            MethodInfo[] classPublicMethod = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] classNonPublicMethod = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder stringBuiilder = new StringBuilder();

            foreach (FieldInfo field in classFields)
            {
                stringBuiilder.AppendLine($"{field.Name} must be private!");
            }
            foreach (MethodInfo method in classNonPublicMethod.Where(m => m.Name.StartsWith("get")))
            {
                stringBuiilder.AppendLine($"{method.Name} have to be public!");
            }
            foreach (MethodInfo method in classPublicMethod.Where(m => m.Name.StartsWith("set")))
            {
                stringBuiilder.AppendLine($"{method.Name} have to be private!");
            }

            return stringBuiilder.ToString().Trim();

        }
        

        public string RevealPrivateMethods(string investigatedClass)
        {
            Type classType = Type.GetType(investigatedClass);
            
            MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder stringBuiilder = new StringBuilder();
            stringBuiilder.AppendLine($"All private Methods of Class: {investigatedClass}");
            stringBuiilder.AppendLine($"Base Class: {classType.BaseType.Name}");


            foreach (MethodInfo method in classMethods)
            {
                stringBuiilder.AppendLine($"{method.Name} have to be public!");
            }
            

            return stringBuiilder.ToString().Trim();

        }
    }
}
