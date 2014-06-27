using System;
using System.Collections.Generic;
using System.Reflection;

namespace StubGenerator.Core
{
    public class Generator
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

        public Generator(Type type)
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
}