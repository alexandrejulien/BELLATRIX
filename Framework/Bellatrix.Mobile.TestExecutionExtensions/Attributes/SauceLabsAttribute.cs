﻿// <copyright file="SauceLabsAttribute.cs" company="Automate The Planet Ltd.">
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
using System;
using System.Reflection;
using Bellatrix.Mobile.Enums;
using Bellatrix.Mobile.TestExecutionExtensions;
using Bellatrix.Mobile.TestExecutionExtensions.Attributes;
using OpenQA.Selenium.Appium;

namespace Bellatrix.Mobile
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public abstract class SauceLabsAttribute : AppAttribute, IAppiumOptionsFactory
    {
        protected SauceLabsAttribute(
            string appPath,
            string platformVersion,
            string deviceName,
            AppBehavior behavior = AppBehavior.NotSet,
            bool recordVideo = false,
            bool recordScreenshots = false)
            : base(appPath, platformVersion, deviceName, behavior)
        {
            RecordVideo = recordVideo;
            RecordScreenshots = recordScreenshots;
            AppConfiguration.ExecutionType = ExecutionType.SauceLabs;
        }

        public bool RecordVideo { get; }

        public bool RecordScreenshots { get; }

        public AppiumOptions CreateAppiumOptions(MemberInfo memberInfo, Type testClassType)
        {
            var appiumOptions = new AppiumOptions();
            AddAdditionalCapabilities(testClassType, appiumOptions);

            appiumOptions.AddAdditionalCapability("browserName", string.Empty);
            appiumOptions.AddAdditionalCapability("deviceName", AppConfiguration.DeviceName);
            appiumOptions.AddAdditionalCapability("app", AppConfiguration.AppPath);
            appiumOptions.AddAdditionalCapability("platformVersion", AppConfiguration.PlatformVersion);
            appiumOptions.AddAdditionalCapability("recordVideo", RecordVideo);
            appiumOptions.AddAdditionalCapability("recordScreenshots", RecordScreenshots);
            appiumOptions.AddAdditionalCapability("appiumVersion", "1.8.1");

            var sauceLabsCredentialsResolver = new SauceLabsCredentialsResolver();
            var credentials = sauceLabsCredentialsResolver.GetCredentials();
            appiumOptions.AddAdditionalCapability("username", credentials.Item1);
            appiumOptions.AddAdditionalCapability("accessKey", credentials.Item2);
            appiumOptions.AddAdditionalCapability("name", testClassType.FullName);

            return appiumOptions;
        }
    }
}