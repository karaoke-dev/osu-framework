﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.MathUtils;
using osu.Framework.Testing;
using osuTK;

namespace osu.Framework.Tests.Visual
{
    [TestName("Layout transform rewinding")]
    [System.ComponentModel.Description("Rewinding of transforms that are important to layout.")]
    public class TestCaseLayoutTransformRewinding : TestCase
    {
        private readonly ManualUpdateSubTreeContainer manualContainer;

        public TestCaseLayoutTransformRewinding()
        {
            Child = manualContainer = new ManualUpdateSubTreeContainer();

            testAutoSizeInstant();
            testFlowInstant();
        }

        private void testAutoSizeInstant()
        {
            AddStep("Initialize autosize test", () =>
            {
                manualContainer.Child = new Container
                {
                    AutoSizeAxes = Axes.Both,
                    Masking = true,
                    Child = new Box { Size = new Vector2(150) }
                };
            });

            AddStep("Run to end", () => manualContainer.PerformUpdate(null));
            AddAssert("Size = 150", () => Precision.AlmostEquals(new Vector2(150), manualContainer.Child.Size));

            AddStep("Rewind", () => manualContainer.PerformUpdate(() => manualContainer.ApplyTransformsAt(-1, true)));
            AddAssert("Size = 150", () => Precision.AlmostEquals(new Vector2(150), manualContainer.Child.Size));
        }

        private void testFlowInstant()
        {
            Box box2 = null;

            AddStep("Initialize flow test", () =>
            {
                manualContainer.Child = new FillFlowContainer
                {
                    AutoSizeAxes = Axes.Both,
                    Children = new[]
                    {
                        new Box { Size = new Vector2(150) },
                        box2 = new Box { Size = new Vector2(150) }
                    }
                };
            });

            AddStep("Run to end", () => manualContainer.PerformUpdate(null));
            AddAssert("Box2 @ (150, 0)", () => Precision.AlmostEquals(new Vector2(150, 0), box2.Position));

            AddStep("Rewind", () => manualContainer.PerformUpdate(() => manualContainer.ApplyTransformsAt(-1, true)));
            AddAssert("Box2 @ (150, 0)", () => Precision.AlmostEquals(new Vector2(150, 0), box2.Position));
        }

        private class ManualUpdateSubTreeContainer : Container
        {
            public override bool RemoveCompletedTransforms => false;

            private Action onUpdateAfterChildren;

            public ManualUpdateSubTreeContainer()
            {
                RelativeSizeAxes = Axes.Both;
            }

            public void PerformUpdate(Action afterChildren)
            {
                onUpdateAfterChildren = afterChildren;
                base.UpdateSubTree();
                onUpdateAfterChildren = null;
            }

            public override bool UpdateSubTree() => false;

            protected override void UpdateAfterChildren()
            {
                base.UpdateAfterChildren();
                onUpdateAfterChildren?.Invoke();
            }
        }
    }
}
