using System.Reflection;

namespace StubGenerator.Core
{
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
}