using System;

namespace osu.Framework.Testing
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TestNameAttribute : Attribute
    {
        public TestNameAttribute(string testName)
        {
            TestName = testName;
        }

        public string TestName { get; }
    }
}
