using System;

namespace StubGenerator.Tests
{
    public interface ITargetObject
    {
        string TheString();
        int ANumber();
        SimpleObject SimpleObj();
        ComplexObject ComplexObj();
    }

    public class ComplexObject
    {
        public string TheString { get; set; }
        public int ANumber { get; set; }
        public SimpleObject Obj { get; set; }
    }

    public class SimpleObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class X : ITargetObject
    {
        public String TheString()
        {
            return "TheString1";
        }
        public Int32 ANumber()
        {
            return 1;
        }

        public SimpleObject SimpleObj()
        {
            return new SimpleObject
            {
                FirstName = "FirstName1",
                LastName = "LastName1",
            };
        }

        public ComplexObject ComplexObj()
        {
            return new ComplexObject
            {
                TheString = "TheString1",
                ANumber = 1,
                Obj = new SimpleObject
                {
                    FirstName = "FirstName1",
                    LastName = "LastName1",
                },
            };
        }

    }

}