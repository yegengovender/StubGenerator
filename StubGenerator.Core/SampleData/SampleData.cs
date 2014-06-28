using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StubGenerator.Core.SampleData
{
    public class SampleData
    {
        private readonly Type _returnType;

        public SampleData(Type returnType)
        {
            _returnType = returnType;
            IsBasic = _returnType.IsPrimitive || _returnType.IsSealed;
        }

        public string Sample()
        {
            string typeName = _returnType.Name;
            if (IsBasic)
            {
                switch (typeName)
                {
                    case "String":
                        return "\"StringValue\"";
                        break;
                    case "Int32":
                        return "1";
                        break;
                    default:
                        return null;
                }
            }
            return string.Empty;
        }

        public bool     IsBasic { get; set; }
    }
}
