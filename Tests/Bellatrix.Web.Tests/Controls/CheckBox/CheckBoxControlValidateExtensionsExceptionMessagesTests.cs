﻿// <copyright file="CheckBoxControlValidateExtensionsExceptionMessagesTests.cs" company="Automate The Planet Ltd.">
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

namespace Bellatrix.Web.Tests.Controls
{
    [TestClass]
    [Browser(BrowserType.Edge, BrowserBehavior.ReuseIfStarted)]
    [AllureSuite("CheckBox Control")]
    [AllureFeature("ValidateExtensions")]
    public class CheckBoxControlValidateExtensionsExceptionMessagesTests : WebTest
    {
        private string _url = ConfigurationService.GetSection<TestPagesSettings>().CheckBoxLocalPage;

        public override void TestInit()
        {
            App.NavigationService.NavigateToLocalPage(_url);
            ////_url = App.BrowserService.Url.ToString();
        }

        [TestMethod]
        [TestCategory(Categories.Edge), TestCategory(Categories.Windows)]
        public void CorrectExceptionMessageSet_When_ValidateCheckedThrowsException()
        {
            var checkBoxElement = App.ElementCreateService.CreateById<CheckBox>("myCheckbox");

            checkBoxElement.Uncheck();

            try
            {
                checkBoxElement.ValidateIsChecked();
            }
            catch (ElementPropertyValidateException e)
            {
                string expectedExceptionMessage = $"The control should be checked but was NOT. The test failed on URL:";
                Assert.AreEqual(true, e.Message.Contains(expectedExceptionMessage), $"Should be {expectedExceptionMessage} but was {e.Message}");
            }
        }

        [TestMethod]
        [TestCategory(Categories.Edge), TestCategory(Categories.Windows)]
        public void CorrectExceptionMessageSet_When_ValidateNotCheckedThrowsException()
        {
            var checkBoxElement = App.ElementCreateService.CreateById<CheckBox>("myCheckbox");

            checkBoxElement.Check();
            try
            {
                checkBoxElement.ValidateIsNotChecked();
            }
            catch (ElementPropertyValidateException e)
            {
                string expectedExceptionMessage = $"The control should be not checked but it WAS. The test failed on URL:";
                Assert.AreEqual(true, e.Message.Contains(expectedExceptionMessage), $"Should be {expectedExceptionMessage} but was {e.Message}");
            }
        }
    }
}