using System;

namespace osu.Framework.Testing
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TestGroupAttribute : Attribute
    {
<<<<<<< HEAD
        public TestGroupAttribute(string groupName)
        {
            GroupName = groupName;
        }

        public string GroupName { get; }
=======
        public TestGroupAttribute(Type testGroupType)
        {
            TestGroup = (ITestGroup)Activator.CreateInstance(testGroupType);
        }

        public ITestGroup TestGroup { get; set; }
>>>>>>> 80941d1902b760da73fed43f569ec61f053e6de7
    }
}
