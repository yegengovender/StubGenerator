using System.Reflection;

namespace StubGenerator.Core
{
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