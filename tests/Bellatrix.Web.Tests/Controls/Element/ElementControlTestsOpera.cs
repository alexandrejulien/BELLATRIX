﻿// <copyright file="ElementControlTestsOpera.cs" company="Automate The Planet Ltd.">
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
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bellatrix.Web.Tests.Controls.Element
{
    [TestClass]
    [Browser(BrowserType.Opera, Lifecycle.ReuseIfStarted)]
    [AllureSuite("Element Control")]
    public class ElementControlTestsOpera : MSTest.WebTest
    {
        public override void TestInit() => App.NavigationService.NavigateToLocalPage(SettingsService.GetSection<TestPagesSettings>().ElementLocalPage);

        [TestMethod]
        [TestCategory(Categories.Opera)]
        public void IsVisibleReturnsTrue_When_ElementIsPresent_Opera()
        {
            var urlElement = App.ElementCreateService.CreateById<Url>("myURL");

            Assert.IsTrue(urlElement.IsVisible);
        }

        [TestMethod]
        [TestCategory(Categories.Opera)]
        public void IsVisibleReturnsFalse_When_ElementIsHidden_Opera()
        {
            var urlElement = App.ElementCreateService.CreateById<Url>("myURL11");

            Assert.IsFalse(urlElement.IsVisible);
        }

        [TestMethod]
        [TestCategory(Categories.Opera)]
        public void SetAttributeChangesAttributeValue_Opera()
        {
            var urlElement = App.ElementCreateService.CreateById<Url>("myURL");

            urlElement.SetAttribute("class", "myTestClass1");
            var cssClass = urlElement.GetAttribute("class");

            Assert.AreEqual("myTestClass1", cssClass);
        }

        [TestMethod]
        [TestCategory(Categories.Opera)]
        public void GetAttributeReturnsName_When_NameAttributeIsSet_Opera()
        {
            var urlElement = App.ElementCreateService.CreateById<Url>("myURL");

            var nameValue = urlElement.GetAttribute("name");

            Assert.AreEqual("myURL", nameValue);
        }

        [TestMethod]
        [TestCategory(Categories.Opera)]
        public void GetAttributeReturnsEmpty_When_NameAttributeIsNotPresent_Opera()
        {
            var urlElement = App.ElementCreateService.CreateById<Url>("myURL");

            var nameValue = urlElement.GetAttribute("style");

            Assert.AreEqual(string.Empty, nameValue);
        }

        [TestMethod]
        [TestCategory(Categories.Opera)]
        public void CssClassReturnsMyTestClass_When_ClassAttributeIsSet_Opera()
        {
            var urlElement = App.ElementCreateService.CreateById<Url>("myURL");

            var cssClass = urlElement.CssClass;

            Assert.AreEqual("myTestClass", cssClass);
        }

        [TestMethod]
        [TestCategory(Categories.Opera)]
        public void CssClassReturnsNull_When_ClassAttributeIsNotPresent_Opera()
        {
            var urlElement = App.ElementCreateService.CreateById<Url>("myURL1");

            var cssClass = urlElement.CssClass;

            Assert.IsNull(cssClass);
        }

        [TestMethod]
        [TestCategory(Categories.Opera)]
        public void ElementVisible_AfterCallingScrollToVisible_Opera()
        {
            var urlElement = App.ElementCreateService.CreateById<Url>("myURL12");

            urlElement.ScrollToVisible();

            Assert.AreEqual("color: red;", urlElement.GetStyle());
        }

        [TestMethod]
        [TestCategory(Categories.Opera)]
        public void CreateElement_When_InsideAnotherElementAndIsPresent_Opera()
        {
            var wrapperDiv = App.ElementCreateService.CreateById<Div>("myURL10Wrapper");

            var urlElement = wrapperDiv.CreateById<Url>("myURL10");

            Assert.IsTrue(urlElement.IsDisabled);
        }

        [TestMethod]
        [TestCategory(Categories.Opera)]
        public void GetTitle_When_TitleAttributeIsPresent_Opera()
        {
            var element = App.ElementCreateService.CreateById<Bellatrix.Web.Element>("myURL13");

            string title = element.GetTitle();

            Assert.AreEqual("bellatrix.solutions", title);
        }

        [TestMethod]
        [TestCategory(Categories.Opera)]
        public void GetNull_When_TitleAttributeIsNotPresent_Opera()
        {
            var element = App.ElementCreateService.CreateById<Bellatrix.Web.Element>("myURL12");

            string title = element.GetTitle();

            Assert.IsNull(title);
        }

        [TestMethod]
        [TestCategory(Categories.Opera)]
        public void GetTabIndexOne_When_TabIndexAttributeIsPresent_Opera()
        {
            var element = App.ElementCreateService.CreateById<Bellatrix.Web.Element>("myURL14");

            string tabIndex = element.GetTabIndex();

            Assert.AreEqual("1", tabIndex);
        }

        [TestMethod]
        [TestCategory(Categories.Opera)]
        public void ReturnsNull_When_TabIndexAttributeIsNotPresent_Opera()
        {
            var element = App.ElementCreateService.CreateById<Bellatrix.Web.Element>("myURL12");

            string tabIndex = element.GetTabIndex();

            Assert.IsNull(tabIndex);
        }

        [TestMethod]
        [TestCategory(Categories.Opera)]
        public void GetStyle_When_StyleAttributeIsPresent_Opera()
        {
            var element = App.ElementCreateService.CreateById<Bellatrix.Web.Element>("myURL16");

            var style = element.GetStyle();

            Assert.AreEqual("color: green;", style);
        }

        [TestMethod]
        [TestCategory(Categories.Opera)]
        public void ReturnsNull_When_StyleAttributeIsNotPresent_Opera()
        {
            var element = App.ElementCreateService.CreateById<Bellatrix.Web.Element>("myURL");

            string style = element.GetStyle();

            Assert.AreEqual(null, style);
        }

        [TestMethod]
        [TestCategory(Categories.Opera)]
        public void GetDir_When_DirAttributeIsPresent_Opera()
        {
            var element = App.ElementCreateService.CreateById<Bellatrix.Web.Element>("myURL19");

            var dir = element.GetDir();

            Assert.AreEqual("rtl", dir);
        }

        [TestMethod]
        [TestCategory(Categories.Opera)]
        public void ReturnsNull_When_DirAttributeIsNotPresent_Opera()
        {
            var element = App.ElementCreateService.CreateById<Bellatrix.Web.Element>("myURL12");

            string dir = element.GetDir();

            Assert.IsNull(dir);
        }

        [TestMethod]
        [TestCategory(Categories.Opera)]
        public void GetLang_When_LangAttributeIsPresent_Opera()
        {
            var element = App.ElementCreateService.CreateById<Bellatrix.Web.Element>("myURL20");

            var lang = element.GetLang();

            Assert.AreEqual("en", lang);
        }

        [TestMethod]
        [TestCategory(Categories.Opera)]
        public void ReturnsNull_When_LangAttributeIsNotPresent_Opera()
        {
            var element = App.ElementCreateService.CreateById<Bellatrix.Web.Element>("myURL12");

            string lang = element.GetLang();

            Assert.IsNull(lang);
        }
    }
}