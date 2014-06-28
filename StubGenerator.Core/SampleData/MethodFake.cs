using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StubGenerator.Core.SampleData
{
    public class MethodFake
    {
        private readonly string _methodName;
        private readonly Type _returnType;
        private readonly List<TypeFake> _parameters;

        public MethodFake(string methodName, Type returnType, List<TypeFake> parameters)
        {
            _methodName = methodName;
            _returnType = returnType;
            _parameters = parameters;

            Declaration = new MethodDeclaration(methodName, returnType, parameters);
            Content = new MethodContent(returnType);
        }

        public MethodDeclaration Declaration { get; set; }
        public MethodContent Content { get; set; }
    }

    public class TypeFake
    {
        public Type Type { get; set; }
        public string Name { get; set; }
    }

    public class MethodContent
    {
        public MethodContent(Type type)
        {
            ReturnType = type;

            var sampleData = new SampleData(type);

            Return = new ReturnType();
            if (sampleData.IsBasic)
                Return.Text = sampleData.Sample();
            else
                Return.Object = new ObjectFake(ReturnType);
        }

        public Type ReturnType { get; set; }

        public ReturnType Return { get; set; }
    }

    public class ReturnType
    {
        public string Text { get; set; }
        public ObjectFake Object { get; set; }

        public ReturnType()
        {
            Text = string.Empty;
        }
    }

    public class ObjectFake {
        public List<ReturnType> Properties { get; set; }

        public ObjectFake(Type returnType)
        {
            Properties = new List<ReturnType>();

            foreach (var propertyInfo in returnType.GetProperties())
            {
                Properties.Add(new ReturnType());
            }
        }
    }

    public class MethodDeclaration
    {
        public MethodDeclaration(string methodName, Type returnType, List<TypeFake> parameters)
        {
            MethodName = methodName;
            ReturnType = returnType;
            Parameters = parameters;
        }

        public string MethodName { get; set; }
        public Type ReturnType { get; set; }
        public List<TypeFake> Parameters { get; set; }
    }
}
