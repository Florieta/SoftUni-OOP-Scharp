using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
        {
            Type classType = Type.GetType(investigatedClass);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static |
               BindingFlags.NonPublic | BindingFlags.Public);
            StringBuilder stringBuiilder = new StringBuilder();

            Object classInstance = Activator.CreateInstance(classType, new object[] { });
            stringBuiilder.AppendLine($"Class under investigation: {investigatedClass}");

            foreach (FieldInfo field in classFields.Where(f => requestedFields.Contains(f.Name)))
            {
                stringBuiilder.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");

            }

            return stringBuiilder.ToString().Trim();
        }
    }
}
