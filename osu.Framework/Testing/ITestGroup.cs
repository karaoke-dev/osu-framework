using System;
using System.Collections.Generic;
using System.Text;

namespace osu.Framework.Testing
{
    public interface ITestGroup
    {
        string GroupName { get; }

        string GroupDescription { get; }
    }
}
