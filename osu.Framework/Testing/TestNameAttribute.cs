using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace osu.Framework.Testing
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TestNameAttribute : DisplayNameAttribute
    {
        public TestNameAttribute(string testName) : base(testName)
        {
        }
    }
}
