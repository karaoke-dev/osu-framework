using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;

namespace osu.Framework.Testing.Drawables
{
    internal class TestCaseButtonGroup : BasicDropdown<Type>, IFilterable
    {
        public IEnumerable<string> FilterTerms => Children.OfType<IHasFilterTerms>().SelectMany(c => c.FilterTerms);

        protected override DropdownMenu CreateMenu() => new TestGroupDropdownMenu();

        protected override DropdownHeader CreateHeader() => new TestGroupDropdownHeader();

        public bool MatchingFilter
        {
            set
            {
                if (value)
                    Show();
                else
                    Hide();
            }
        }

        public TestCaseButtonGroup(string groupName,IList<Type> testcases)
        {
            Header.Label = groupName;
            RelativeSizeAxes = Axes.X;

            foreach (var testCase in testcases)
            {
                AddDropdownItem(testCase);
            }
        }

        protected override string GenerateItemText(Type item)
        {
            var testName = item.GetCustomAttribute<TestNameAttribute>()?.TestName
                           ?? item.Name.Replace("TestCase", "");

            return testName;
        }

        /// <summary>
        /// Hide the menu item of specified value.
        /// </summary>
        /// <param name="val">The value to hide.</param>
        internal void HighLightItem(Type val)
        {
            var dropdownMenuItem = GetDropdownMenuItemItem(val);
            if (dropdownMenuItem  != null)
            {
                (Menu as TestGroupDropdownMenu)?.HighLightItem(dropdownMenuItem);
            }
        }

        /// <summary>
        /// Show the menu item of specified value.
        /// </summary>
        /// <param name="val">The value to show.</param>
        internal void UnHighLightItem(Type val)
        {
            var dropdownMenuItem = GetDropdownMenuItemItem(val);
            if (dropdownMenuItem != null)
            {
                (Menu as TestGroupDropdownMenu)?.UnHighLightItem(dropdownMenuItem);
            }
        }

        public class TestGroupDropdownHeader : BasicDropdownHeader
        {
            
        }

        public class TestGroupDropdownMenu : DropdownMenu
        {
            public TestGroupDropdownMenu()
            {
                CornerRadius = 4;
            }

            /// <summary>
            /// Shows an item from this <see cref="Dropdown{T}.DropdownMenu"/>.
            /// </summary>
            /// <param name="item">The item to show.</param>
            public void HighLightItem(DropdownMenuItem<Type> item) => (Children.FirstOrDefault(c => c.Item == item) as DrawableTestCaseDropdownMenuItem)?.HighLight();

            /// <summary>
            /// Hides an item from this <see cref="Dropdown{T}.DropdownMenu"/>
            /// </summary>
            /// <param name="item"></param>
            public void UnHighLightItem(DropdownMenuItem<Type> item) => (Children.FirstOrDefault(c => c.Item == item) as DrawableTestCaseDropdownMenuItem)?.UnHighLight();


            protected override DrawableMenuItem CreateDrawableMenuItem(MenuItem item) => new DrawableTestCaseDropdownMenuItem(item as DropdownMenuItem<Type>);

            private class DrawableTestCaseDropdownMenuItem : DrawableDropdownMenuItem
            {
                public DrawableTestCaseDropdownMenuItem(DropdownMenuItem<Type> item)
                    : base(item)
                {
                    Foreground.Padding = new MarginPadding(2);
                }

                protected override Drawable CreateContent() => new SpriteText();

                /// <summary>
                /// Hide sprite instantly.
                /// </summary>
                public virtual void HighLight()
                {

                }

                /// <summary>
                /// Show sprite instantly.
                /// </summary>
                public virtual void UnHighLight()
                {

                }
            }
        }
    }
}
