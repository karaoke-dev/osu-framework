using osu.Framework.Testing;

namespace osu.Framework.Tests.Visual
{
    public static class TestCaseGroup
    {
        public static TestGroup UI
            => new TestGroup("UI","textbox, checkbox, label ,etc ...");

        public static TestGroup Input
            => new TestGroup("Input","mouse, keyboard, joystick, etc ...");

        public static TestGroup Effect
            => new TestGroup("Effect","");

        public static TestGroup Graphic
            => new TestGroup("Graphic","");

        public static TestGroup Drawable
            => new TestGroup("Drawable","Every kinds of drawable");

        public static TestGroup Utilities
            => new TestGroup("Utilities","rigid body, markdown container, etc ...");
    }
}
