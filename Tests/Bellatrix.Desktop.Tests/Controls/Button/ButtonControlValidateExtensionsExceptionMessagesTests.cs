﻿// <copyright file="ButtonControlValidateExtensionsExceptionMessagesTests.cs" company="Automate The Planet Ltd.">
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
using Bellatrix.Desktop.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bellatrix.Desktop.Tests
{
    [TestClass]
    [App(Constants.WpfAppPath, AppBehavior.RestartEveryTime)]
    [AllureSuite("Button Control")]
    [AllureFeature("ValidateExtensionsExceptionMessages")]
    [AllureTag("WPF")]
    public class ButtonControlValidateExtensionsExceptionMessagesTests : BellatrixBaseTest
    {
        [TestMethod]
        [TestCategory(Categories.CI)]
        [TestCategory(Categories.Desktop)]
        public void ValidateInnerTextIs_ThrowException_When_ButtonInnerTextIsAsExpected()
        {
            try
            {
                var button = App.ElementCreateService.CreateByName<Button>("E Button");
                button.ValidateInnerTextIs("ebuttonHovered");
            }
            catch (ElementPropertyValidateException e)
            {
                string expectedExceptionMessage = "The control's inner text should be 'ebuttonHovered'";
                Assert.AreEqual(true, e.Message.Contains(expectedExceptionMessage), $"Should be {expectedExceptionMessage} but was {e.Message}");
            }
        }

        [TestMethod]
        [TestCategory(Categories.CI)]
        [TestCategory(Categories.Desktop)]
        public void ValidateIsNotDisabled_ThrowException_When_ButtonNotDisabled()
        {
            var button = App.ElementCreateService.CreateByName<Button>("E Button");

            try
            {
                button.ValidateIsDisabled();
            }
            catch (ElementPropertyValidateException e)
            {
                string expectedExceptionMessage = "The control should be disabled but it was NOT.";
                Assert.AreEqual(true, e.Message.Contains(expectedExceptionMessage), $"Should be {expectedExceptionMessage} but was {e.Message}");
            }
        }

        [TestMethod]
        [TestCategory(Categories.CI)]
        [TestCategory(Categories.Desktop)]
        public void ValidateIsDisabled_ThrowException_When_ButtonDisabled()
        {
            var button = App.ElementCreateService.CreateByName<Button>("D Button");

            try
            {
                button.ValidateIsNotDisabled();
            }
            catch (ElementPropertyValidateException e)
            {
                string expectedExceptionMessage = "The control should NOT be disabled but it was.";
                Assert.AreEqual(true, e.Message.Contains(expectedExceptionMessage), $"Should be {expectedExceptionMessage} but was {e.Message}");
            }
        }
    }
}