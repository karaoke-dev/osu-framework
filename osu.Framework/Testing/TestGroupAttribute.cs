using System;

namespace osu.Framework.Testing
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TestGroupAttribute : Attribute
    {
        public TestGroupAttribute(Type testGroupType)
        {
            TestGroup = (ITestGroup)Activator.CreateInstance(testGroupType);
        }

        public ITestGroup TestGroup { get; set; }
    }
}
