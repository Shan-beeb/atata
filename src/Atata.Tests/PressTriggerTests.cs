﻿using NUnit.Framework;
using OpenQA.Selenium;

namespace Atata.Tests
{
    public class PressTriggerTests : UITestFixture
    {
        private ScrollablePage page;

        protected override void OnSetUp()
        {
            page = Go.To<ScrollablePage>();
        }

        [Test]
        public void PressEndAttribute()
        {
            page.
                BottomText.Should.Not.BeVisibleInViewPort().
                BottomText.Triggers.Add(new PressEndAttribute(TriggerEvents.BeforeGet));

            page.
                BottomText.Get(out string text).
                BottomText.Should.BeVisibleInViewPort();
        }

        [Test]
        public void PressHomeAttribute()
        {
            page.
                Press(Keys.End).
                TopText.Should.Not.BeVisibleInViewPort().
                TopText.Triggers.Add(new PressHomeAttribute(TriggerEvents.BeforeGet));

            page.
                TopText.Get(out string text).
                TopText.Should.BeVisibleInViewPort();
        }
    }
}
