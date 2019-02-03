﻿using System;
using System.Collections.Generic;
using System.Text;

namespace osu.Framework.Testing
{
    public struct TestGroup
    {
        public TestGroup(string groupName, string groupDescription)
        {
            GroupName = groupName;
            GroupDescription = groupDescription;
        }

        public string GroupName { get; set; }

        public string GroupDescription { get; set; }
    }
}
