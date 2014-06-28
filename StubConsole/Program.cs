using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace StubConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
        }
    }

    public interface ITargetObject
    {
        string TheString();
        int ANumber();

        TargetObj Obj();
    }

    public class TargetObj
    {
        public string TheString { get; set; }
        public int ANumber { get; set; }
        public SubObj Obj { get; set; }
    }

    public class SubObj
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }


    public class SampleData
    {
        public string Sample(Type returnType, string methodName)
        {
            string typeName = returnType.Name;
            if (returnType.IsPrimitive || returnType.IsSealed)
            {
                switch (typeName)
                {
                    case "String":
                        return "\"" + methodName + "1\"";
                        break;
                    case "Int32":
                        return "1";
                        break;
                    default:
                        return null;
                }
            }
            else
            {
                var sb = new StringBuilder();
                sb.Append("new ");
                sb.Append(typeName);
                sb.Append(" {\n");

                foreach (var propertyInfo in returnType.GetProperties())
                {
                    var propertyName = propertyInfo.Name;
                    var propertyValue = Sample(propertyInfo.PropertyType, propertyName);
                    sb.Append(propertyName);
                    sb.Append(" = ");
                    sb.Append(propertyValue);
                    sb.Append(",\n");
                }
                
                sb.Append("}");
                return sb.ToString();
            }
        }
    }

    public class X: ITargetObject
    {
        public String TheString()
        {
            return "TheString1";
        }
        public Int32 ANumber()
        {
            return 1;
        }
        public TargetObj Obj()
        {
            return new TargetObj
            {
                TheString = "TheString1",
                ANumber = 1,
                Obj = new SubObj
                {
                    FirstName = "FirstName1",
                    LastName = "LastName1",
                },
            };
        }

    }
}
