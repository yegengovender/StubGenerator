using System;
using StubGenerator.Core;

namespace StubConsole
{
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
}

namespace StubGenerator.Core
{
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
}