using System;

namespace osu.Framework.Testing
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TestGroupAttribute : Attribute
    {
        public TestGroupAttribute(TestGroup testGroup)
        {
            TestGroup = testGroup;
        }

        public TestGroup TestGroup { get; set; }
    }
}
