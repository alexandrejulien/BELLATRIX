﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bellatrix.Mobile.IOS.GettingStarted
{
    // 1. To test web apps, you can start Safari browser using the IOSWeb attribute.
    [TestClass]
    [IOSWebAttribute(Constants.IOSNativeAppPath,
        Constants.IOSDefaultVersion,
        Constants.IOSDefaultDeviceName,
        Lifecycle.ReuseIfStarted)]
    public class WebServiceTests : MSTest.IOSTest
    {
        // 2. BELLATRIX gives you an interface for easier work with web apps. Using it, you can access most of the features
        // of BELLATRIX web APIs.
        // Note: First of all, make sure developer mode is turned on in your Safari preferences so that the remote debugger port is open.
        // Note 2: For iOS 9.3 and below follow the following instructions: http://appium.io/docs/en/writing-running-appium/web/mobile-web/
        [TestMethod]
        [Timeout(180000)]
        [Ignore]
        [TestCategory(Categories.KnownIssue)]
        public void HtmlSourceContainsShop_When_OpenWebPageWithChrome()
        {
            App.Web.NavigationService.Navigate("http://demos.bellatrix.solutions/");
            Assert.IsTrue(App.Web.BrowserService.HtmlSource.Contains("Shop"));
        }
    }
}