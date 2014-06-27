namespace StubGenerator.Tests
{
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
}