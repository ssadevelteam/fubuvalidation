﻿using FubuMVC.Core.Registration.Querying;
using FubuMVC.Core.UI.Forms;
using FubuMVC.Validation.UI;
using FubuTestingSupport;
using HtmlTags;
using NUnit.Framework;

namespace FubuMVC.Validation.Tests.UI
{
    [TestFixture]
    public class RenderingStrategyTester
    {
        private FormRequest theRequest;

        [SetUp]
        public void SetUp()
        {
            theRequest = new FormRequest(new ChainSearch {Type = typeof (object)}, new object());
            var theForm = new FormTag("test");
            theRequest.ReplaceTag(theForm);
        }

        [Test]
        public void summary_strategy_adds_the_validation_summary_attribute()
        {
            RenderingStrategies.Summary.Modify(theRequest);
            theRequest.CurrentTag.ToString()
                .ShouldEqual("<form method=\"post\" action=\"test\" data-validation-summary=\"true\">");
        }

        [Test]
        public void highlight_strategy_adds_the_validation_highlight_attribute()
        {
            RenderingStrategies.Highlight.Modify(theRequest);
            theRequest.CurrentTag.ToString()
                .ShouldEqual("<form method=\"post\" action=\"test\" data-validation-highlight=\"true\">");
        }

        [Test]
        public void inline_strategy_adds_the_validation_inline_attribute()
        {
            RenderingStrategies.Inline.Modify(theRequest);
            theRequest.CurrentTag.ToString()
                .ShouldEqual("<form method=\"post\" action=\"test\" data-validation-inline=\"true\">");
        }
    }
}