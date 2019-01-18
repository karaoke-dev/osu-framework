using System.Collections.Generic;
using System.Linq;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.UserInterface;

namespace osu.Framework.Testing.Drawables
{
    internal class TestCaseButtonGroup : BasicDropdown<TestCaseButton>, IFilterable
    {
        public IEnumerable<string> FilterTerms => Children.OfType<IHasFilterTerms>().SelectMany(c => c.FilterTerms);

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

        public TestCaseButtonGroup(string groupName)
        {
            this.Header.Label = groupName;

            RelativeSizeAxes = Axes.X;
        }
    }
}
