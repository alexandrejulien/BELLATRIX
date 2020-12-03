﻿// <copyright file="AnchorControlTestsEdge.cs" company="Automate The Planet Ltd.">
// Copyright 2020 Automate The Planet Ltd.
// Licensed under the Apache License, Version 2.0 (the "License");
// You may not use this file except in compliance with the License.
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// <author>Anton Angelov</author>
// <site>https://bellatrix.solutions/</site>
using Allure.Commons;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bellatrix.Web.Tests.Controls
{
    [TestClass]
    [Browser(BrowserType.Edge, BrowserBehavior.ReuseIfStarted)]
    [AllureSuite("Anchor Control")]
    [AllureTag("Edge Browser")]
    [ScreenshotOnFail(true)]
    [VideoRecording(VideoRecordingMode.OnlyFail)]
    public class AnchorControlTestsEdge : WebTest
    {
        public override void TestInit() => App.NavigationService.NavigateToLocalPage(ConfigurationService.GetSection<TestPagesSettings>().AnchorLocalPage);

        [TestMethod]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Anton")]
        [TestCategory(Categories.CI)]
        [TestCategory(Categories.Edge), TestCategory(Categories.Windows)]
        public void ClickOpensAutomateThePlanetUrl_When_DefaultClickIsSet_Edge()
        {
            var anchorElement = App.ElementCreateService.CreateById<Anchor>("myAnchor");

            anchorElement.Click();

            App.NavigationService.WaitForPartialUrl("automatetheplanet");

            Assert.IsTrue(App.BrowserService.Url.ToString().Contains("automatetheplanet.com"));
        }

        [TestMethod]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Nick")]
        [TestCategory(Categories.CI)]
        [TestCategory(Categories.Edge), TestCategory(Categories.Windows)]
        public void ReturnRed_When_Hover_Edge()
        {
            var anchorElement = App.ElementCreateService.CreateById<Anchor>("myAnchor1");

            anchorElement.Hover();

            Assert.AreEqual("color: red;", anchorElement.GetStyle());
        }

        [TestMethod]
        [TestCategory(Categories.CI)]
        [TestCategory(Categories.Edge), TestCategory(Categories.Windows)]
        public void ReturnBlue_When_Focus_Edge()
        {
            var anchorElement = App.ElementCreateService.CreateById<Anchor>("myAnchor2");

            anchorElement.Focus();

            Assert.AreEqual("color: blue;", anchorElement.GetStyle());
        }

        [TestMethod]
        [TestCategory(Categories.CI)]
        [TestCategory(Categories.Edge), TestCategory(Categories.Windows)]
        public void ReturnAutomateThePlanet_When_InnerText_Edge()
        {
            var anchorElement = App.ElementCreateService.CreateById<Anchor>("myAnchor");

            Assert.AreEqual("Automate The Planet", anchorElement.InnerText);
        }

        [TestMethod]
        [TestCategory(Categories.CI)]
        [TestCategory(Categories.Edge), TestCategory(Categories.Windows)]
        public void ReturnButtonHtml_When_InnerHtml_Edge()
        {
            var anchorElement = App.ElementCreateService.CreateById<Anchor>("myAnchor4");

            Assert.IsTrue(anchorElement.InnerHtml.Contains("<button name=\"button\">Click me</button>"));
        }

        [TestMethod]
        [TestCategory(Categories.CI)]
        [TestCategory(Categories.Edge), TestCategory(Categories.Windows)]
        public void ReturnEmpty_When_InnerTextNotSet_Edge()
        {
            var anchorElement = App.ElementCreateService.CreateById<Anchor>("myAnchor6");

            Assert.AreEqual(string.Empty, anchorElement.InnerText);
        }

        [TestMethod]
        [TestCategory(Categories.CI)]
        [TestCategory(Categories.Edge), TestCategory(Categories.Windows)]
        public void ReturnEmpty_When_InnerHtmlNotSet_Edge()
        {
            var anchorElement = App.ElementCreateService.CreateById<Anchor>("myAnchor6");

            string actualInnerHtml = anchorElement.InnerHtml;

            Assert.AreEqual(string.Empty, actualInnerHtml);
        }

        [TestMethod]
        [TestCategory(Categories.CI)]
        [TestCategory(Categories.Edge), TestCategory(Categories.Windows)]
        public void ReturnEmpty_When_RelNotSet_Edge()
        {
            var anchorElement = App.ElementCreateService.CreateById<Anchor>("myAnchor");

            string actualRel = anchorElement.Rel;

            Assert.AreEqual(string.Empty, actualRel);
        }

        [TestMethod]
        [TestCategory(Categories.CI)]
        [TestCategory(Categories.Edge), TestCategory(Categories.Windows)]
        public void ReturnCanonical_When_RelRel_Edge()
        {
            var anchorElement = App.ElementCreateService.CreateById<Anchor>("myAnchor5");

            Assert.AreEqual("canonical", anchorElement.Rel);
        }

        [TestMethod]
        [TestCategory(Categories.CI)]
        [TestCategory(Categories.Edge), TestCategory(Categories.Windows)]
        public void ReturnEmpty_When_TargetNotSet_Edge()
        {
            var anchorElement = App.ElementCreateService.CreateById<Anchor>("myAnchor1");

            Assert.AreEqual(string.Empty, anchorElement.Target);
        }

        [TestMethod]
        [TestCategory(Categories.CI)]
        [TestCategory(Categories.Edge), TestCategory(Categories.Windows)]
        public void ReturnSelf_When_RelRel_Edge()
        {
            var anchorElement = App.ElementCreateService.CreateById<Anchor>("myAnchor");

            Assert.AreEqual("_self", anchorElement.Target);
        }

        [TestMethod]
        [TestCategory(Categories.CI)]
        [TestCategory(Categories.Edge), TestCategory(Categories.Windows)]
        public void ReturnNull_When_HrefNotSet_Edge()
        {
            var anchorElement = App.ElementCreateService.CreateById<Anchor>("myAnchor5");

            Assert.IsNull(anchorElement.Href);
        }

        [TestMethod]
        [TestCategory(Categories.CI)]
        [TestCategory(Categories.Edge), TestCategory(Categories.Windows)]
        public void ReturnAutomateThePlanetUrl_When_Href_Edge()
        {
            var anchorElement = App.ElementCreateService.CreateById<Anchor>("myAnchor");

            Assert.AreEqual("https://automatetheplanet.com/", anchorElement.Href);
        }
    }
}