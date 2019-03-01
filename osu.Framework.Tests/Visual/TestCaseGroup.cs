using osu.Framework.Testing;

namespace osu.Framework.Tests.Visual
{
    public class TestCaseGroup
    {
        public class TestGroupUI : ITestGroup
        {
            public string GroupName => "UI";

            public string GroupDescription => "textbox, checkbox, label ,etc ...";
        }

        public class TestGroupInput : ITestGroup
        {
            public string GroupName => "Input";

            public string GroupDescription => "mouse, keyboard, joystick, etc ...";
        }

        public class TestGroupEffect : ITestGroup
        {
            public string GroupName => "Effect";

            public string GroupDescription => "textbox, checkbox, label ,etc ...";
        }

        public class TestGroupGraphic : ITestGroup
        {
            public string GroupName => "Graphic";

            public string GroupDescription => "textbox, checkbox, label ,etc ...";
        }

        public class TestGroupDrawable : ITestGroup
        {
            public string GroupName => "Drawable";

            public string GroupDescription => "Every kinds of drawable";
        }

        public class TestGroupUtilities : ITestGroup
        {
            public string GroupName => "Utilities";

            public string GroupDescription => "rigid body, markdown container, etc ...";
        }
    }
}
