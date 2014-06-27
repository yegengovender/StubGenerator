using System;
using System.Collections.Generic;

namespace StubGenerator.Core
{
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
}