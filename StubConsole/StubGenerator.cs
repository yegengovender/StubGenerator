using System;
using System.Collections.Generic;
using System.Reflection;

namespace StubConsole
{
    public class StubGenerator
    {
        private Type _type;
        private string _declaration;
        private List<FakeMethod> _methods;

        public string Declaration
        {
            get { return _declaration; }
        }

        public List<FakeMethod> Methods
        {
            get { return _methods; }
        }

        public StubGenerator(Type type)
        {
            _type = type;
            CreateClassName();
            CreateMethods();
        }



        private void CreateClassName()
        {
            var typeName = _type.Name;
            var className = typeName[0] == 'I' ? typeName.Substring(1) : typeName;
            _declaration = "public " + _type.Name + " " + className + "Fake";
        }

        private void CreateMethods()
        {
            _methods = new List<FakeMethod>();
            MethodInfo[] methodInfo = _type.GetMethods();
            foreach (var info in methodInfo)
            {
                _methods.Add(new FakeMethod(info));
            }
        }
    }

    public class Returnable
    {
        private string _returnValue;
        private FakeObject _returnObject;

        private bool _isBasic;
        public bool IsBasic
        {
            get { return _isBasic; }
        }
        public string ReturnValue
        {
            get { return _returnValue; }
        }

        public FakeObject ReturnObject
        {
            get { return _returnObject; }
        }

        public Returnable(Type returnType, string name)
        {
            _isBasic = (returnType.IsPrimitive || returnType.IsSealed);
            _returnValue = IsBasic ? (SampleValue(returnType.Name, name) ?? "") : "";
            _returnObject = new FakeObject(returnType);   
        }
        private string SampleValue(string typeName, string methodName)
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
   
    }
    public class FakeMethod: Returnable
    {
        private string _signature;

        public string Signature
        {
            get { return _signature; }
        }

        public FakeMethod(MethodInfo methodInfo)
            : base(methodInfo.ReturnType, methodInfo.Name)
        {
            var returnType = methodInfo.ReturnType;
            _signature = "public " + returnType.Name + " " + methodInfo.Name;
        }

    }

    public class FakeObject
    {
        private string _declaration;
        private readonly List<FakeProperty> _properties;
        public string Declaration
        {
            get { return _declaration; }
        }
        
        public List<FakeProperty> Properties 
        {
            get { return _properties; }
        }

        public FakeObject(Type returnType)
        {
            _declaration = "new " + returnType.Name;
            _properties = new List<FakeProperty>();
            foreach (var propertyInfo in returnType.GetProperties())
            {
                _properties.Add(new FakeProperty(propertyInfo));
            }
        }

    }

    public class FakeProperty: Returnable
    {
        private string _name;

        public string Name
        {
            get { return _name; }
        }

        public FakeProperty(PropertyInfo propertyInfo)
            : base(propertyInfo.PropertyType, propertyInfo.Name)
        {
            _name = propertyInfo.Name;
        }
    }
}